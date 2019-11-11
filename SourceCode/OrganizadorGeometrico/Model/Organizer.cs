using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorGeometrico.Model
{

    class ItemOrganizado
    {
        public DXFItem Figura;
        public int X = 0, Y = 0;
        public bool FiguraPosicionada = false;

        public ItemOrganizado(DXFItem figura)
        {
            Figura = figura;
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

        public void IniciarOrganizador(DXFItem placaGravacao, List<DXFItem> figurasGeometricas)
        {
            sucessoOrganizador = false;
            itemOrganizados.Clear();
            this.PlacaGravacao = placaGravacao;
            this.FigurasGeometricas = figurasGeometricas;

            //Atualiza o plano de gravacao para o tamanho original
            PlacaGravacao.GerarBitmap(1, 0, 0, (int)PlacaGravacao.Largura + 1, (int)PlacaGravacao.Altura + 1, Color.Black, Color.White, true);

            figurasGeometricas = RemoverFigurasIcompativeis(figurasGeometricas);
            
            if (figurasGeometricas.Count == 0)
            {
                log.Enqueue("Nao sobrou figura geometrica para organizar");
                return;
            }

            OrganizarFiguras(figurasGeometricas);

            figurasPosicionadas = new DXFItem();
            PosicionarFiguras(itemOrganizados);

        }

        private void PosicionarFiguras(List<ItemOrganizado> itemOrganizados)
        {
            figurasPosicionadas.entities = new netDxf.Collections.EntityCollection();
            foreach (var item in itemOrganizados)
            {
                figurasPosicionadas.entities.AddRange(item.Figura.entities);
                figurasPosicionadas.RefreshInformacoes();
                sucessoOrganizador = true;
            }
        }

        private void OrganizarFiguras(List<DXFItem> figuras)
        {
            Bitmap bitmapOcupacao = PlacaGravacao.GetBitmap();

            foreach (var figura in figuras)
            {
                int x = 0, y = 0;
                if (EncontrarPosicaoFiguraNoPlano(figura, out x, out y, bitmapOcupacao))
                {
                    //Adiciona o item na lista de itens organizado
                    ItemOrganizado item = new ItemOrganizado(figura);
                    item.X = x;
                    item.Y = y;
                    item.FiguraPosicionada = true;
                    itemOrganizados.Add(item);

                    //Ocupa a area do bitmap
                    PreencherAreaPosicionamento(item, ref bitmapOcupacao);
                }

            }
        }

        private void PreencherAreaPosicionamento(ItemOrganizado item, ref Bitmap bitmapOcupacao)
        {
            int largura =   (int) item.Figura.Largura;
            int altura =    (int) item.Figura.Altura;


            for (int x = item.X; x < item.X + largura; x++)
            {
                for (int y = item.Y; y < item.Y + altura; y++)
                {
                    bitmapOcupacao.SetPixel(x, y, Color.Red);
                }
            }
        }

        private bool EncontrarPosicaoFiguraNoPlano(DXFItem figura, out int PosX, out int PosY, Bitmap bitmapPlano)
        {
            PosX = 0;
            PosY = 0;

            for (int x = 0; x < PlacaGravacao.Altura; x++)
            {
                for (int y = 0; y < PlacaGravacao.Largura; y++)
                {
                    if (bitmapPlano.GetPixel(x, y).B == 255)
                    {
                        if (AnalisaPixel(x, y, bitmapPlano, figura.Largura, figura.Altura))
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

        private bool AnalisaPixel(int PosX, int PosY, Bitmap bitmapPlano, double largura, double altura)
        {
            for (int x = 0; x < largura; x++)
            {
                for (int y = 0; y < altura; y++)
                {
                    //Excede o limite do bitmap
                    if (x + PosX > bitmapPlano.Width || y + PosY > bitmapPlano.Height)
                        return false;

                    //Percorre cada pixel buscando por espacos nao ocupaveis
                    if (bitmapPlano.GetPixel(PosX + x, PosY + y) == Color.Black)
                        return false;
                }
            }

            return true;
        }

        private List<DXFItem> RemoverFigurasIcompativeis(List<DXFItem> figurasGeometricas)
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

        public List<DXFItem> OrdenarPorArea(List<DXFItem> figurasGeometricas)
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

        public List<DXFItem> OrdenarPorAltura(List<DXFItem> figurasGeometricas)
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

        public List<DXFItem> OrdenarPorLargura(List<DXFItem> figurasGeometricas)
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

        public List<DXFItem> OrdenarCustomizado(List<DXFItem> figurasGeometricas)
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

        public Bitmap BitmapResultado()
        {
            if (itemOrganizados.Count > 0)
                return figurasPosicionadas.GetBitmap();
            else
                return new Bitmap(1, 1);
        }

    }
}
