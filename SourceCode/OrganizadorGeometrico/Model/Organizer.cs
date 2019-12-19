using netDxf.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using netDxf;

namespace OrganizadorGeometrico.Model
{

    class ItemOrganizado
    {
        public DXFItem Figura;
        public int X = 0, Y = 0;
        public bool FiguraPosicionada = false;

        public ItemOrganizado(DXFItem figura)
        {
            Figura = new DXFItem(figura);
        }

    }

    class Organizer
    {
        DXFItem PlacaGravacao;
        List<DXFItem> FigurasGeometricas = new List<DXFItem>();
        public Queue<string> log = new Queue<string>();
        List<ItemOrganizado> itemOrganizados = new List<ItemOrganizado>();
        public DXFItem figurasPosicionadas;
        public bool sucessoOrganizador = false;
        internal int progressoAlgoritmo = 0; //valor de 0 a 4
        
        //Espacamento entre as figuras geometricas
        int espacamentoX = 3;
        int espacamentoY = 3;

        public void IniciarOrganizador(DXFItem placaGravacao, List<DXFItem> figurasGeometricas)
        {
            progressoAlgoritmo = 0;

            sucessoOrganizador = false;
            itemOrganizados.Clear();
            this.PlacaGravacao = placaGravacao;
            this.FigurasGeometricas = figurasGeometricas;

            //Atualiza o plano de gravacao para o tamanho original
            PlacaGravacao.GerarBitmap(1, 0, 0, (int)PlacaGravacao.Largura, (int)PlacaGravacao.Altura, Color.Black, Color.White, true);

            //Atualiza o progresso
            progressoAlgoritmo++;

            //Remove figuras com area maior que a area do plano de gravacao
            figurasGeometricas = RemoverFigurasAreaExcedente(figurasGeometricas);

            //Atualiza o progresso
            progressoAlgoritmo++;

            //Caso nao tenha sobrado figuras, interrompe a execucao do algoritmo
            if (figurasGeometricas.Count == 0)
            {
                log.Enqueue("Nao sobrou figura geometrica para organizar");
                //Atualiza o progresso
                progressoAlgoritmo = 4;
                return;
            }

            //Executa o algoritmo de organizacao das figuras geometricas dentro do plano
            OrganizarFiguras(figurasGeometricas);

            //Atualiza o progresso
            progressoAlgoritmo++;

            //Cria a posiciona cada entidade dentro do plano geometrico
            ReposicionarFiguraGeometrica(itemOrganizados);

            //Atualiza o progresso
            progressoAlgoritmo++;

            if (itemOrganizados.Count <= 0)
                log.Enqueue("Finalizado a organizacao sem sucesso em nenhuma figura");
            else if (sucessoOrganizador)
                log.Enqueue("Organizador concluido com sucesso");
            else
                log.Enqueue("Organizador concluido sem sucesso");

        }

        private void ReposicionarFiguraGeometrica(List<ItemOrganizado> itemOrganizados)
        {
            figurasPosicionadas = new DXFItem();
            figurasPosicionadas.entities = new netDxf.Collections.EntityCollection();
            figurasPosicionadas.entities.AddRange(PlacaGravacao.entities);
            foreach (var item in itemOrganizados)
            {
                ItemOrganizado itemPosicionar = item;
                DXFItem itemPosicionado = AtualizarPosicaoEntidades(itemPosicionar);
                figurasPosicionadas.entities.AddRange(itemPosicionado.entities);
                sucessoOrganizador = true;
            }
            figurasPosicionadas.AtualizarInformacoes();
        }

        private void OrganizarFiguras(List<DXFItem> figuras)
        {
            Bitmap bitmapOcupacao = PlacaGravacao.GetBitmap();

            foreach (var figura in figuras)
            {
                int x = 0, y = 0;
                if (EncontrarPosicaoFiguraNoPlano(figura, out x, out y, bitmapOcupacao))
                {
                    log.Enqueue("Alocado a figura " + figura.nome + " na posicao X: " + x.ToString() + " e Y: " + y.ToString());
                    //Adiciona o item na lista de itens organizado
                    ItemOrganizado item = new ItemOrganizado(figura);
                    item.X = x + espacamentoX;
                    item.Y = y + espacamentoY;
                    item.FiguraPosicionada = true;
                    itemOrganizados.Add(item);

                    //Ocupa a area do bitmap
                    PreencherAreaPosicionamento(item, ref bitmapOcupacao);
                }
                else
                    log.Enqueue("Nao foi possivel encontrar espaco para alocar a figura " + figura.nome);

            }
        }

        private DXFItem AtualizarPosicaoEntidades(ItemOrganizado item)
        {
            DXFItem figura = item.Figura;          

            //Circulos
            List<Circle> circles = figura.entities.OfType<Circle>().ToList();
            foreach (var circle in circles)
            {
                figura.entities.Remove(circle);
                Circle circleAtualizado = new Circle(
                    new Vector2(circle.Center.X + item.X - figura.Origem[0], circle.Center.Y + item.Y - figura.Origem[1]), //Centro
                    circle.Radius); //Raio
                figura.entities.Add(circleAtualizado);
            }

            //Linhas
            List<Line> lines = figura.entities.OfType<Line>().ToList();
            foreach (var line in lines)
            {
                figura.entities.Remove(line);
                Line linha = new Line(
                    new Vector2(line.StartPoint.X + item.X - figura.Origem[0], line.StartPoint.Y + item.Y - figura.Origem[1]), //Start
                    new Vector2(line.EndPoint.X + item.X - figura.Origem[0], line.EndPoint.Y + item.Y - figura.Origem[1]) //End
                    );
                figura.entities.Add(linha);
            }

            //Elipses
            List<Ellipse> ellipses = figura.entities.OfType<Ellipse>().ToList();
            foreach (var ellipse in ellipses)
            {
                figura.entities.Remove(ellipse);
                Ellipse ellipseAtualizado = new Ellipse(
                    new Vector2(ellipse.Center.X + item.X, ellipse.Center.Y + item.Y), 
                    ellipse.MajorAxis, 
                    ellipse.MinorAxis
                    );
                figura.entities.Add(ellipseAtualizado);
            }

            //LwPolilinhas
            List<LwPolyline> lwPolylines = figura.entities.OfType<LwPolyline>().ToList();
            foreach (var lwPolyline in lwPolylines)
            {
                figura.entities.Remove(lwPolyline);
                LwPolyline polyline = new LwPolyline();
                foreach (var vertex in lwPolyline.Vertexes)
                {
                    polyline.Vertexes.Add(new LwPolylineVertex(new Vector2(vertex.Position.X + item.X, vertex.Position.Y + item.Y), vertex.Bulge));
                }
                
                figura.entities.Add(polyline);
            }

            //Arcos(entities.OfType<Arc>());
            List<Arc> arcs = figura.entities.OfType<Arc>().ToList();
            foreach (var arc in arcs)
            {
                figura.entities.Remove(arc);
                Arc arco = new Arc(new Vector2(arc.Center.X + item.X, arc.Center.X + item.X), arc.Radius, arc.StartAngle, arc.EndAngle);
                figura.entities.Add(arco);
            }

            return figura;
        }

        private void PreencherAreaPosicionamento(ItemOrganizado item, ref Bitmap bitmapOcupacao)
        {
            int largura =   (int) item.Figura.Largura;
            int altura =    (int) item.Figura.Altura;


            for (int x = item.X; x < item.X + largura; x++)
            {
                for (int y = item.Y; y < item.Y + altura; y++)
                {
                    bitmapOcupacao.SetPixel(x, (int)PlacaGravacao.Altura - y - 1, Color.Red);
                }
            }
        }

        private bool EncontrarPosicaoFiguraNoPlano(DXFItem figura, out int PosX, out int PosY, Bitmap bitmapPlano)
        {
            PosX = 0;
            PosY = 0;

            for (int x = 0; x < PlacaGravacao.Largura; x++)
            {
                for (int y = 0; y < PlacaGravacao.Altura; y++)
                {
                    if (bitmapPlano.GetPixel(x, (int)PlacaGravacao.Altura - y - 1).B == 255)
                    {
                        if (AnalisarPixel(x, y, bitmapPlano, figura.Largura + espacamentoX, figura.Altura + espacamentoY))
                        {
                            PosX = x;
                            PosY = y;
                            return true;
                        }
                    }
                    
                }
            }

            return false;
        }

        private bool AnalisarPixel(int PosX, int PosY, Bitmap bitmapPlano, double largura, double altura)
        {
            for (int x = 0; x < largura; x++)
            {
                for (int y = 0; y < altura; y++)
                {
                    //Excede o limite do bitmap
                    if (x + PosX > bitmapPlano.Width - 1 || y + PosY > bitmapPlano.Height - 1)
                        return false;

                    //Percorre cada pixel buscando por espacos nao ocupaveis
                    if (bitmapPlano.GetPixel(PosX + x, bitmapPlano.Height - PosY - y - 1).G == 0)
                        return false;

                }
            }

            return true;
        }

        private List<DXFItem> RemoverFigurasAreaExcedente(List<DXFItem> figurasGeometricas)
        {
            List<DXFItem> resultado = new List<DXFItem>();

            foreach (DXFItem figura in figurasGeometricas)
            {
                log.Enqueue("Iniciado a analise de area da figura " + figura.nome);
                if (ValidarAreaFiguras(figura))
                    resultado.Add(figura);
                else
                    log.Enqueue("A area da figura " + figura.nome + " e maior que a area da placa de gravacao");
            }

            return resultado;
        }

        //Verifica se a area da figura pode ser contida
        private bool ValidarAreaFiguras(DXFItem figura)
        {
            if (figura.Area > PlacaGravacao.Area)
            {
                return false;
            }
            else
                return true;
        }

        public List<DXFItem> OrganizarPorArea(List<DXFItem> figurasGeometricas)
        {
            List<DXFItem> listResultado = new List<DXFItem>();
            DXFItem[] ordenacao = new DXFItem[figurasGeometricas.Count];
            double[] vetorAreas = new double[figurasGeometricas.Count];

            for (int i = 0; i < figurasGeometricas.Count; i++)
            {
                vetorAreas[i] = figurasGeometricas[i].Area;
            }

            vetorAreas = InsertionSort(vetorAreas);

            foreach (var area in vetorAreas)
            {
                foreach (var figura in figurasGeometricas)
                {
                    if (figura.Area == area)
                    {
                        listResultado.Add(figura);
                        figurasGeometricas.Remove(figura);
                        break;
                    }
                }
            }

            return listResultado;
        }

        public List<DXFItem> OrganizarPorAltura(List<DXFItem> figurasGeometricas)
        {
            List<DXFItem> listResultado = new List<DXFItem>();
            DXFItem[] ordenacao = new DXFItem[figurasGeometricas.Count];
            double[] vetor = new double[figurasGeometricas.Count];

            for (int i = 0; i < figurasGeometricas.Count; i++)
            {
                vetor[i] = figurasGeometricas[i].Altura;
            }

            vetor = InsertionSort(vetor);

            foreach (var altura in vetor)
            {
                foreach (var figura in figurasGeometricas)
                {
                    if (figura.Altura == altura)
                    {
                        listResultado.Add(figura);
                        figurasGeometricas.Remove(figura);
                        break;
                    }
                }
            }

            return listResultado;
        }

        public List<DXFItem> OrganizarPorLargura(List<DXFItem> figurasGeometricas)
        {
            List<DXFItem> listResultado = new List<DXFItem>();
            DXFItem[] ordenacao = new DXFItem[figurasGeometricas.Count];
            double[] vetor = new double[figurasGeometricas.Count];

            for (int i = 0; i < figurasGeometricas.Count; i++)
            {
                vetor[i] = figurasGeometricas[i].Largura;
            }

            vetor = InsertionSort(vetor);

            foreach (var largura in vetor)
            {
                foreach (var figura in figurasGeometricas)
                {
                    if (figura.Largura == largura)
                    {
                        listResultado.Add(figura);
                        figurasGeometricas.Remove(figura);
                        break;
                    }
                }
            }

            return listResultado;
        }

        public List<DXFItem> OrganizarCustomizado(List<DXFItem> figurasGeometricas)
        {
            List<DXFItem> listResultado = new List<DXFItem>();
            DXFItem[] ordenacao = new DXFItem[figurasGeometricas.Count];
            double[] vetorOrdem = new double[figurasGeometricas.Count];

            for (int i = 0; i < figurasGeometricas.Count; i++)
            {
                vetorOrdem[i] = figurasGeometricas[i].Ordem;
            }

            vetorOrdem = InsertionSort(vetorOrdem);

            foreach (var ordem in vetorOrdem)
            {
                foreach (var figura in figurasGeometricas)
                {
                    if (figura.Ordem == ordem)
                    {
                        listResultado.Add(figura);
                        figurasGeometricas.Remove(figura);
                        break;
                    }
                }
            }

            return listResultado;
        }

        private double[] InsertionSort(double[] vetor)
        {
            for (var i = 1; i < vetor.Length; i++)
            {
                var aux = vetor[i];
                var j = i - 1;

                while (j >= 0 && vetor[j] > aux)
                {
                    vetor[j + 1] = vetor[j];
                    j -= 1;
                }
                vetor[j + 1] = aux;
            }

            return vetor;
        }

        public Bitmap GetBitmapResultado()
        {
            if (itemOrganizados.Count > 0)
                return figurasPosicionadas.GetBitmap();
            else
                return new Bitmap(1, 1);
        }

    }
}
