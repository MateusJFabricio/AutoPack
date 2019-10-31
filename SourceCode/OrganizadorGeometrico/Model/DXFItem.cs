using netDxf;
using netDxf.Blocks;
using netDxf.Entities;
using netDxf.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OrganizadorGeometrico.Model
{
    class DXFItem
    {

        Bitmap bitmap;
        Graphics desenhador;
        public double Altura = 0, Largura = 0, Area = 0;
        private double menorX = 0, menorY = 0, maiorX = 0, maiorY = 0;
        public double[] Origem = new double[] { 0, 0 };
        public double[] NovaOrigem = new double[] { 0, 0 };
        DxfDocument docFigura;
        public string path;
        string nome;
        PlotPaperUnits unidadeMedida;

        public DXFItem(string path, int largura, int altura)
        {
            this.path = path;
            BuscarAquivo();
            BuscarDimensoes();
            GerarBitmap(1f, 0, 0, largura, altura);
        }

        private void BuscarAquivo()
        {
            docFigura = DxfDocument.Load(path);
            nome = docFigura.Name;
        }

        private void BuscarDimensoes()
        {
            unidadeMedida = docFigura.Layouts["Layout1"].PlotSettings.PaperUnits;

            var entities = docFigura.Blocks[Block.DefaultModelSpaceName].Entities;

            int quantidadeLay = docFigura.Layouts.Count;

            //Pegar a dimensao dos circulos
            AnalisarCirculos(entities.OfType<Circle>());

            AnalisarRetangulos(entities.OfType<Rectangle>());

            AnalisarLinhas(entities.OfType<Line>());

            AnalisarElipses(entities.OfType<Ellipse>());

            AnalisarImagem(entities.OfType<netDxf.Entities.Image>());

            AnalisarMultiLinhas(entities.OfType<MLine>());

            AnalisarTexto(entities.OfType<Text>());

            AnalisarPolilinhas(entities.OfType<Polyline>());

            AnalisarLwPolilinhas(entities.OfType<LwPolyline>());

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
        }

        public void GerarBitmap(float zoom,float offsetX, float offsetY, int largura, int altura)
        {
            if (zoom <= 0)
                zoom = 0f;

            int x = (int) ((maiorX - menorX + 2) * zoom);
            int y = (int)((maiorY - menorY + 2) * zoom);

            if (x <= 0)
                x = 1;

            if (y <= 0)
                y = 1;

            bitmap = new Bitmap(largura, altura);

            desenhador = Graphics.FromImage(bitmap);
            desenhador.TranslateTransform((float) Origem[0] * -1 * zoom + offsetX, (float)Origem[1] * -1 * zoom + offsetY);
            //
            //  desenhador.ScaleTransform(10, 10);

            var entities = docFigura.Blocks[Block.DefaultModelSpaceName].Entities;

            DesenharCirculos(entities.OfType<Circle>(), zoom, (float) altura / 2);

            DesenharRetangulos(entities.OfType<Rectangle>(), zoom, (float)altura / 2);
            
            DesenharLinhas(entities.OfType<Line>(), zoom, (float)altura / 2);
            
            DesenharEllipses(entities.OfType<Ellipse>(), zoom, (float)altura / 2);
            
            DesenharImagem(entities.OfType<netDxf.Entities.Image>(), zoom, (float)altura / 2);
            
            DesenharMultiLinhas(entities.OfType<MLine>(), zoom, (float)altura / 2);
            
            DesenharTexto(entities.OfType<Text>(), zoom, (float)altura / 2);
            
            DesenharPolilinhas(entities.OfType<Polyline>(), zoom, (float)altura / 2);

            DesenharLwPolilinhas(entities.OfType<LwPolyline>(), zoom, (float) altura / 2); //Texto

            DesenharArcos(entities.OfType<Arc>(), zoom, (float)altura / 2);

        }

        #region Ferramentas de desenho
        private void DesenharArcos(IEnumerable<Arc> arcs, float zoom, float deslocamentoOrigem)
        {
            foreach (var arc in arcs)
            {
                desenhador.DrawArc(new Pen(Color.Black), 
                    (float) arc.Center.X * zoom,
                    deslocamentoOrigem - (float) arc.Center.Y * zoom, 
                    (float) arc.Radius * zoom, 
                    (float) arc.Radius * zoom, 
                    (float) arc.StartAngle * zoom, 
                    (float) arc.EndAngle * zoom
                    );
            }
        }

        private void DesenharLwPolilinhas(IEnumerable<LwPolyline> lwPolylines, float zoom, float deslocamento)
        {
            foreach (var lwPolyline in lwPolylines)
            {

                for (int i = 0; i < lwPolyline.Vertexes.Count; i+=2)
                {
                    if (i == lwPolyline.Vertexes.Count - 1)
                        break;

                    if (lwPolyline.Vertexes[i].Bulge != 0 || lwPolyline.Vertexes[i+1].Bulge != 0)
                        throw new Exception("O bulge ainda nao foi implementado");

                    desenhador.DrawLine(new Pen(Color.Black),
                            (float)lwPolyline.Vertexes[i].Position.X * zoom,
                            deslocamento - (float)lwPolyline.Vertexes[i].Position.Y * zoom,
                            (float)lwPolyline.Vertexes[i+1].Position.X * zoom,
                            deslocamento - (float)lwPolyline.Vertexes[i+1].Position.Y * zoom
                            );
                }
            }
        }

        private void DesenharRetangulos(IEnumerable<Rectangle> rectangles, float zoom, float deslocamentoOrigem)
        {
            foreach (var rectangle in rectangles)
            {
                desenhador.DrawRectangle(new Pen(Color.Black), 
                    rectangle.X * zoom,
                    deslocamentoOrigem - rectangle.Y * zoom, 
                    rectangle.Width * zoom, 
                    rectangle.Height * zoom
                    );
            }
        }

        private void DesenharPolilinhas(IEnumerable<Polyline> polylines, float zoom, float deslocamentoOrigem)
        {
            foreach (var line in polylines)
            {
                foreach(Line linha in line.Explode())
                {
                    desenhador.DrawLine(new Pen(Color.Black), 
                        (float)linha.StartPoint.X * zoom,
                        deslocamentoOrigem - (float)linha.StartPoint.Y * zoom, 
                        (float)linha.EndPoint.X * zoom,
                        deslocamentoOrigem - (float)linha.EndPoint.Y * zoom
                        );
                }
            }
        }

        private void DesenharTexto(IEnumerable<Text> texts, float zoom, float v)
        {
            foreach (var item in texts)
            {
                throw new NotImplementedException();
            }   
        }

        private void DesenharMultiLinhas(IEnumerable<MLine> mLines, float zoom, float deslocamentoOrigem)
        {
            foreach (var item in mLines)
            {
                throw new NotImplementedException();
            }
        }

        private void DesenharImagem(IEnumerable<netDxf.Entities.Image> images, float zoom, float v)
        {
            foreach (var item in images)
            {
                throw new NotImplementedException();
            }
        }

        private void DesenharEllipses(IEnumerable<Ellipse> ellipses, float zoom, float deslocamentoOrigem)
        {
            foreach (var ellipse in ellipses)
            {
                desenhador.RotateTransform((float) ellipse.Rotation);
                desenhador.DrawArc(new Pen(Color.Black), 
                    (float)ellipse.Center.X * zoom,
                    deslocamentoOrigem - (float)ellipse.Center.Y * zoom, 
                    (float)ellipse.MajorAxis * zoom, 
                    (float) ellipse.MinorAxis * zoom, 
                    (float)ellipse.StartAngle * zoom, 
                    (float)ellipse.StartAngle * zoom
                    );
            }
            desenhador.RotateTransform(0f);
        }

        private void DesenharLinhas(IEnumerable<Line> lines, float zoom, float deslocamentoOrigem)
        {
            foreach (var line in lines)
            {
                desenhador.DrawLine(new Pen(Color.Black), 
                    (float) line.StartPoint.X * zoom,
                    deslocamentoOrigem - (float) line.StartPoint.Y * zoom, 
                    (float) line.EndPoint.X * zoom,
                    deslocamentoOrigem - (float) line.EndPoint.Y * zoom
                    );
            }

        }

        private void DesenharCirculos(IEnumerable<Circle> circles, float zoom, float deslocamentoOrigem)
        {
            foreach (var circle in circles)
            {
                desenhador.DrawEllipse(new Pen(Color.Black), 
                    (float) circle.Center.X * zoom,
                    deslocamentoOrigem - (float) circle.Center.Y * zoom,
                    (float) circle.Radius * zoom, 
                    (float) circle.Radius * zoom
                    );
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
            }
        }

        private void AnalisarPolilinhas(IEnumerable<Polyline> polylines)
        {

            foreach (Polyline polyline in polylines)
            {
                foreach (var vertex in polyline.Vertexes)
                {
                    //Verifica Min X
                    VerificaMinX(vertex.Position.X);

                    //Verifica Min Y
                    VerificaMinY(vertex.Position.Y);

                    //Verifica Max X
                    VerificaMaxX(vertex.Position.X);

                    //Verifica Max Y
                    VerificaMaxY(vertex.Position.Y);

                }
            }
        }

        private void AnalisarLwPolilinhas(IEnumerable<LwPolyline> lwPolylines)
        {
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
                }
            }
        }
        

        private void AnalisarTexto(IEnumerable<Text> texts)
        {
            foreach (var text in texts)
            {
                //Verifica Min X
                VerificaMinX(text.Position.X);

                //Verifica Min Y
                VerificaMinY(text.Position.Y);

                //Verifica Max X
                VerificaMaxX(text.Position.X + text.Width);

                //Verifica Max Y
                VerificaMaxY(text.Position.Y + text.Height);
            }
        }

        private void AnalisarMultiLinhas(IEnumerable<MLine> mLines)
        {
            foreach (var mLine in mLines)
            {
                AnalisarLinhas((IEnumerable<Line>)mLine.Explode());
            }
        }

        private void AnalisarImagem(IEnumerable<netDxf.Entities.Image> images)
        {
            foreach (var image in images)
            {
                //Verifica Min X
                VerificaMinX(image.Position.X);

                //Verifica Min Y
                VerificaMinY(image.Position.Y);

                //Verifica Max X
                VerificaMaxX(image.Position.X + image.Width);

                //Verifica Max Y
                VerificaMaxX(image.Position.Y + image.Height);
            }
        }

        private void AnalisarElipses(IEnumerable<Ellipse> ellipses)
        {
            foreach (var ellipse  in ellipses)
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

        private void AnalisarRetangulos(IEnumerable<Rectangle> rectangles)
        {
            foreach (var rectangle in rectangles)
            {
                //Verifica Min X
                VerificaMinX(rectangle.X - rectangle.Height);

                //Verifica Min Y
                VerificaMinY(rectangle.Y - rectangle.Width);

                //Verifica Max X
                VerificaMaxX(rectangle.X);

                //Verifica Max Y
                VerificaMaxY(rectangle.Y);
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

    }
}
