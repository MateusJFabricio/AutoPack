using netDxf;
using netDxf.Blocks;
using netDxf.Collections;
using netDxf.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OrganizadorGeometrico.Model
{

    public class DXFItem
    {

        public bool figuraFechada = true;
        public int id;
        Bitmap bitmap;
        Graphics desenhador;
        public double Altura = 0, Largura = 0, Area = 0;
        private double menorX = 0, menorY = 0, maiorX = 0, maiorY = 0;
        public double[] Origem = new double[] { 0, 0 };
        DxfDocument docFigura;
        public string path;
        public string nome;
        public EntityCollection entities;
        public int Ordem = 0;

        public void InicializarDeArquivo(string path, int id, bool placaGravacao = false)
        {
            this.path = path;
            this.id = id;
            BuscarAquivo();

            //Identifica as dimensoes da figura geometrica
            //Verifica se a figura geometrica esta aberta ou fechada
            BuscarDimensoes();

            //Gera o Bitmap da figura geometrica para ser exibido em tela
            bool preencherInteriorFigura = placaGravacao;
            GerarBitmapInicial(preencherInteriorFigura);
            
            // !Problemas com regioes abertas quando deveriam estar fechadas
            //Identifica a quantidade de regioes da figura geometrica
            //if (figuraFechada)
            //    IdentificacaoRegioesFigura();
        }

        public void AtualizarInformacoes()
        {
            if (entities.Count > 0)
            {
                //Identifica as dimensoes da figura geometrica
                //Verifica se a figura geometrica esta aberta ou fechada
                BuscarDimensoes();

                //Gera o Bitmap da figura geometrica para ser exibido em tela
                GerarBitmapInicial(false);
            }
        }

        private void BuscarAquivo()
        {
            docFigura = DxfDocument.Load(path);
            nome = docFigura.Name;
            entities = docFigura.Blocks[Block.DefaultModelSpaceName].Entities;
        }

        private void GerarBitmapInicial(bool preencher)
        {
            GerarBitmap(1f, 0, 0, (int) Math.Round(Largura), (int) Math.Round(Altura), Color.Black, Color.White, preencher);
        }
        public void BuscarDimensoes()
        { 

            if (entities.Count <= 0)
                throw new Exception("Nao ha figura geometrica neste arquivo!");


            //Buscar a dimensao dos circulos
            AnalisarCirculos(entities.OfType<Circle>());

            AnalisarLinhas(entities.OfType<Line>());

            AnalisarElipses(entities.OfType<Ellipse>());

            AnalisarLwPolilinhas(entities.OfType<LwPolyline>());

            AnalisarArcos(entities.OfType<Arc>());

            //AnalisarArcos(entities.OfType<Arc>());

            if (menorY == 0 && maiorY == 0)
                menorY = maiorY - 1;

            if (menorY == 0 && maiorY == 0)
                maiorY = maiorY + 1;

            //Atualiza a origem
            Origem[0] = menorX;
            Origem[1] = menorY;

            //Atualiza a area ocupada
            Area = (maiorX - menorX) * (maiorY - menorY);
            Largura = maiorX - menorX;
            Altura = maiorY - menorY;
        }

        public void GerarBitmap(float zoom,float offsetX, float offsetY, int larguraBitmap, int alturaBitmap, Color corFundo, Color corLinha, bool preencherFigura = false)
        {
            if (zoom <= 0)
                zoom = 0f;

            bitmap = new Bitmap(larguraBitmap + 10, alturaBitmap + 10);


            desenhador = Graphics.FromImage(bitmap);
            desenhador.TranslateTransform((float) Origem[0] * -1 * zoom + offsetX, (float)Origem[1] * -1 * zoom + offsetY);
            //
            //  desenhador.ScaleTransform(10, 10);

            //Preenche o bitmap
            desenhador.Clear(corFundo);
            
            DesenharCirculos(entities.OfType<Circle>(), zoom, (float)alturaBitmap + (float)Origem[1] * 2, corLinha, preencherFigura);

            DesenharLinhas(entities.OfType<Line>(), zoom, (float)alturaBitmap + (float)Origem[1] * 2, corLinha, preencherFigura);

            DesenharEllipses(entities.OfType<Ellipse>(), zoom, (float)alturaBitmap + (float)Origem[1] * 2, corLinha, preencherFigura);

            DesenharLwPolilinhas(entities.OfType<LwPolyline>(), zoom, (float)alturaBitmap + (float)Origem[1] * 2, corLinha); //Texto

            DesenharArcos(entities.OfType<Arc>(), zoom, (float)alturaBitmap + (float)Origem[1] * 2, corLinha, preencherFigura);

        }

        #region Ferramentas de desenho
        private void DesenharArcos(IEnumerable<Arc> arcs, float zoom, float deslocamentoOrigem, Color cor, bool preencher)
        {
            foreach (var arc in arcs)
            {
                if (!preencher)
                {
                    desenhador.DrawArc(new Pen(cor),
                        (float)arc.Center.X * zoom,
                        deslocamentoOrigem - (float)arc.Center.Y * zoom,
                        (float)arc.Radius * zoom,
                        (float)arc.Radius * zoom,
                        (float)arc.StartAngle * zoom,
                        (float)arc.EndAngle * zoom
                        );
                }
            }
        }

        private void DesenharLwPolilinhas(IEnumerable<LwPolyline> lwPolylines, float zoom, float deslocamento, Color cor)
        {
            foreach (var lwPolyline in lwPolylines)
            {

                for (int i = 0; i < lwPolyline.Vertexes.Count; i+=2)
                {
                    if (i == lwPolyline.Vertexes.Count - 1)
                        break;

                    if (lwPolyline.Vertexes[i].Bulge != 0 || lwPolyline.Vertexes[i+1].Bulge != 0)
                        throw new Exception("O bulge ainda nao foi implementado");

                    desenhador.DrawLine(new Pen(cor),
                            (float)lwPolyline.Vertexes[i].Position.X * zoom,
                            deslocamento - (float)lwPolyline.Vertexes[i].Position.Y * zoom,
                            (float)lwPolyline.Vertexes[i+1].Position.X * zoom,
                            deslocamento - (float)lwPolyline.Vertexes[i+1].Position.Y * zoom
                            );
                }
            }
        }

        private void DesenharEllipses(IEnumerable<Ellipse> ellipses, float zoom, float deslocamentoOrigem, Color cor, bool preencher)
        {
            foreach (var ellipse in ellipses)
            {
                desenhador.RotateTransform((float)ellipse.Rotation);

                if (!preencher)
                {
                    desenhador.DrawEllipse(new Pen(cor),
                        (float)ellipse.Center.X * zoom,
                        deslocamentoOrigem - (float)ellipse.Center.Y * zoom,
                        (float)ellipse.MajorAxis * zoom,
                        (float)ellipse.MinorAxis * zoom
                        );
                }else
                {
                    desenhador.FillEllipse(new SolidBrush(cor),
                        (float)ellipse.Center.X,
                        deslocamentoOrigem - (float)ellipse.Center.Y,
                        (float)ellipse.MajorAxis,
                        (float)ellipse.MinorAxis
                        );
                }
            }
            desenhador.RotateTransform(0f);

            
        }

        private void DesenharLinhas(IEnumerable<Line> lines, float zoom, float deslocamentoOrigem, Color cor, bool preencher)
        {
            List<Line> linhas = lines.ToList();

            //Desenha as linhas normais, sem preencher o interior da figura
            if (!preencher)
            {
                foreach (var line in linhas)
                {
                
                    desenhador.DrawLine(new Pen(cor, 1),
                        (float)line.StartPoint.X * zoom,
                        deslocamentoOrigem - (float)line.StartPoint.Y * zoom,
                        (float)line.EndPoint.X * zoom,
                        deslocamentoOrigem - (float)line.EndPoint.Y * zoom
                        );
                }
             }else

            //Desenha a figura preenchida.
            //Para isto deve ser ordenado os vertices das linhas
            //Depois deve ser desenhado o preenchimento, com base no caminho dos vertices
            if (linhas.Count > 0 && preencher && figuraFechada)
            {
                List<Vector2> verticesOrdenados = new List<Vector2>();
                //Ordena os vertices
                verticesOrdenados = OrdenarVertices(linhas);

                //Popula o caminhos dos vertices
                PointF[] pontos = new PointF[verticesOrdenados.Count()];
                for (int i = 0; i < verticesOrdenados.Count(); i++)
                {
                    pontos[i] = new PointF((float)verticesOrdenados[i].X, deslocamentoOrigem - (float)verticesOrdenados[i].Y);
                }
                //Desenha a figura
                desenhador.FillPolygon(new SolidBrush(cor), pontos);
            }

        }

        private List<Vector2> OrdenarVertices(List<Line> linhas)
        {
            List<Vector2> verticesOrdenados = new List<Vector2>();
            Vector2 verticeAtual = new Vector2(0, 0);
            bool verticeEncontrado = false;
            do
            {
                if (verticesOrdenados.Count == 0)
                {
                    verticeAtual = new Vector2(linhas[0].EndPoint.X, linhas[0].EndPoint.Y);
                    verticesOrdenados.Add(new Vector2(linhas[0].StartPoint.X, linhas[0].StartPoint.Y));
                    verticesOrdenados.Add(verticeAtual);

                    linhas.Remove(linhas[0]);
                    verticeEncontrado = true;
                }
                else
                {
                    foreach (var linha in linhas)
                    {
                        verticeEncontrado = false;
                        //Endpoint do ultimo seja o Startpoint do atual
                        if (VerticesProximos(verticeAtual, new Vector2(linha.StartPoint.X, linha.StartPoint.Y), 1))
                        {
                            verticeAtual = new Vector2(linha.EndPoint.X, linha.EndPoint.Y);
                            verticesOrdenados.Add(verticeAtual);
                            linhas.Remove(linha);
                            verticeEncontrado = true;
                            break;
                        }
                        else
                        //Endpoint do ultimo seja o Startpoint do atual
                        if (VerticesProximos(verticeAtual, new Vector2(linha.EndPoint.X, linha.EndPoint.Y), 1))
                        {
                            verticeAtual = new Vector2(linha.StartPoint.X, linha.StartPoint.Y);
                            verticesOrdenados.Add(verticeAtual);
                            linhas.Remove(linha);
                            verticeEncontrado = true;
                            break;
                        }
                    }
                    if (!verticeEncontrado)
                        throw new Exception("O plano de gravacao deve possuir apenas uma figura geometrica");
                }

            } while (linhas.Count > 0);

            return verticesOrdenados;
        }

        private void DesenharCirculos(IEnumerable<Circle> circles, float zoom, float deslocamentoOrigem, Color cor, bool preencher)
        {
            if (circles.Count() > 1)
                figuraFechada = false;

            foreach (var circle in circles)
            {
                if (!preencher)
                {
                    desenhador.DrawEllipse(
                        new Pen(cor, 2),
                        (float)circle.Center.X - (float)circle.Radius * zoom, //x
                        deslocamentoOrigem - (float)circle.Center.Y - (float)circle.Radius * zoom, //y
                        (float)circle.Radius * 2 * zoom, //Deve ser multiplicado por 2
                        (float)circle.Radius * 2 * zoom
                        );
                }else
                {
                    desenhador.FillEllipse(new SolidBrush(cor),
                        (float)circle.Center.X - (float)circle.Radius * zoom, //x
                        deslocamentoOrigem - (float)circle.Center.Y - (float)circle.Radius * zoom, //y
                        (float)circle.Radius * 2 * zoom, //Deve ser multiplicado por 2
                        (float)circle.Radius * 2 * zoom
                        );
                }
            }
        }

#endregion

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        #region Analise de tamanho
        private void AnalisarLinhas(IEnumerable<Line> linhas)
        {
            List<Vector2> vertices = new List<Vector2>();
            foreach (var linha in linhas)
            {
                
                //Verifica Min X
                VerificaMinX(linha.StartPoint.X > linha.EndPoint.X ? linha.EndPoint.X : linha.StartPoint.X);

                //Verifica Min Y
                VerificaMinY(linha.StartPoint.Y > linha.EndPoint.Y ? linha.EndPoint.Y : linha.StartPoint.Y);

                //Verifica Max X
                VerificaMaxX(linha.StartPoint.X < linha.EndPoint.X ? linha.EndPoint.X : linha.StartPoint.X);

                //Verifica Max Y
                VerificaMaxY(linha.StartPoint.Y < linha.EndPoint.Y ? linha.EndPoint.Y : linha.StartPoint.Y);

                vertices.Add(new Vector2(linha.StartPoint.X, linha.StartPoint.Y));
                vertices.Add(new Vector2(linha.EndPoint.X, linha.EndPoint.Y));
            }

            if (!FiguraVerticesFechados(vertices))
            {
                figuraFechada = false;
            }
        }

        private void AnalisarLwPolilinhas(IEnumerable<LwPolyline> lwPolylines)
        {
            List<Vector2> vertices = new List<Vector2>();

            foreach (LwPolyline lwPolyline in lwPolylines)
            {
                foreach (LwPolylineVertex vertex in lwPolyline.Vertexes)
                {
                    if (vertex.Bulge == 0)
                    {
                        //Verifica Min X
                        VerificaMinX(vertex.Position.X);

                        //Verifica Min Y
                        VerificaMinY(vertex.Position.Y);

                        //Verifica Max X
                        VerificaMaxX(vertex.Position.X);

                        //Verifica Max Y
                        VerificaMaxY(vertex.Position.Y);
                    }else
                    {
                        throw new MethodAccessException("Falta implementar o Bulge");
                        //Formula -> raio = d(b^2 + 1) / 2 * b
                        //Distancia entre duas coordenadas -> d^2 AB = (XB – XA)^2 + (YB -YA)^2
                        //double raio = 
                        //double ang = Math.Atan(vertex.Bulge) * 4;
                    }

                    vertices.Add(new Vector2(vertex.Position.X, vertex.Position.Y));
                }
            }

            //Analisar se todos os vertices e uma figura fechada ou aberta
            if (!FiguraVerticesFechados(vertices))
                figuraFechada = false;

        }

        private void AnalisarElipses(IEnumerable<Ellipse> ellipses)
        {
            foreach (var ellipse  in ellipses)
            {
                if (ellipse.IsFullEllipse)
                {
                    //Verifica Min X
                    VerificaMinX(ellipse.Center.X - ellipse.MajorAxis);

                    //Verifica Min Y
                    VerificaMinY(ellipse.Center.Y - ellipse.MajorAxis);

                    //Verifica Max X
                    VerificaMaxX(ellipse.Center.X + ellipse.MajorAxis);

                    //Verifica Max Y
                    VerificaMaxX(ellipse.Center.Y + ellipse.MajorAxis);
                }

            }

            if (ellipses.Count() > 1)
                figuraFechada = false;
            
        }

        private void AnalisarCirculos(IEnumerable<Circle> circulos)
        {
            foreach (var circulo in circulos)
            {
                //Verifica Min X
                VerificaMinX(circulo.Center.X - circulo.Radius);

                //Verifica Min Y
                VerificaMinY(circulo.Center.Y - circulo.Radius);

                //Verifica Max X
                VerificaMaxX(circulo.Center.X + circulo.Radius);

                //Verifica Max Y
                VerificaMaxY(circulo.Center.Y + circulo.Radius);
            }

        }

        private void AnalisarArcos(IEnumerable<Arc> arcs)
        {
            foreach (Arc arc in arcs)
            {
                //Verifica Min X
                VerificaMinX(arc.Center.X - arc.Radius);

                //Verifica Min Y
                VerificaMinY(arc.Center.Y - arc.Radius);

                //Verifica Max X
                VerificaMaxX(arc.Center.X + arc.Radius);

                //Verifica Max Y
                VerificaMaxY(arc.Center.Y + arc.Radius);
            }
        }
        
        #endregion

        private void VerificaMinX(double val)
        {
            if (val < menorX)
                menorX = val;
        }

        private void VerificaMinY(double val)
        {
            if (val < menorY)
                menorY = val;
        }

        private void VerificaMaxX(double val)
        {
            if (val > maiorX)
                maiorX = val;
        }

        private void VerificaMaxY(double val)
        {
            if (val > maiorY)
                maiorY = val;
        }

        private bool FiguraVerticesFechados(List<Vector2> vertices)
        {
            
            foreach (var vertice1 in vertices)
            {
                int numeroVerticesProx = 0;
                foreach (var vertice2 in vertices)
                {
                    if (VerticesProximos(vertice1, vertice2, 1))
                        numeroVerticesProx++;
                }

                if (numeroVerticesProx != 2)
                    return false;
            }

            return true;
        }

        private bool VerticesProximos(Vector2 v1, Vector2 v2, double tolerancia)
        {
            if (Math.Abs(v1.X - v2.X) <= tolerancia)
                if (Math.Abs(v1.Y - v2.Y) <= tolerancia)
                    return true;

            return false;
        }

    }
}
