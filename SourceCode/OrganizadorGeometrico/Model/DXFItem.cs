using netDxf;
using netDxf.Blocks;
using netDxf.Entities;
using netDxf.Header;
using netDxf.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DXFItem(string path)
        {
            this.path = path;
            BuscarAquivo();
        }

        private void BuscarAquivo()
        {
            docFigura = DxfDocument.Load(path);
            nome = docFigura.Name;

            BuscarDimensoes();
            GerarBitmap();
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

        private void GerarBitmap()
        {
            bitmap = new Bitmap((int)(maiorX - menorX) + 2, (int)(maiorY - menorY) + 2);
            bitmap = new Bitmap(300, 300);

            desenhador = Graphics.FromImage(bitmap);
            desenhador.TranslateTransform((float)Origem[0] * -1, (float)Origem[1] * -1 - 0);

            desenhador.ScaleTransform(50, 50);

            var entities = docFigura.Blocks[Block.DefaultModelSpaceName].Entities;

            DesenharCirculos(entities.OfType<Circle>());

            DesenharRetangulos(entities.OfType<Rectangle>());
            
            DesenharLinhas(entities.OfType<Line>());
            
            DesenharEllipses(entities.OfType<Ellipse>());
            
            DesenharImagem(entities.OfType<netDxf.Entities.Image>());
            
            DesenharMultiLinhas(entities.OfType<MLine>());
            
            DesenharTexto(entities.OfType<Text>());
            
            DesenharPolilinhas(entities.OfType<Polyline>());

            DesenharLwPolilinhas(entities.OfType<LwPolyline>()); //Texto

            DesenharArcos(entities.OfType<Arc>());

        }

        private void DesenharArcos(IEnumerable<Arc> arcs)
        {
            foreach (var arc in arcs)
            {
                desenhador.DrawArc(new Pen(Color.Black), 
                    (float) arc.Center.X, 
                    (float) arc.Center.Y, 
                    (float) arc.Radius, 
                    (float) arc.Radius, 
                    (float) arc.StartAngle, 
                    (float) arc.EndAngle);
            }
        }

        private void DesenharLwPolilinhas(IEnumerable<LwPolyline> lwPolylines)
        {
            foreach (var lwPolyline in lwPolylines)
            {
                foreach (var item in lwPolyline.Explode())
                {
                    if (item.Type == EntityType.Arc)
                    {
                        Arc arc = (Arc)item;
                        desenhador.DrawArc(new Pen(Color.Black),
                            (float)arc.Center.X,
                            (float)arc.Center.Y,
                            (float)arc.Radius,
                            (float)arc.Radius,
                            (float)arc.StartAngle,
                            (float)arc.EndAngle);
                    }
                    else if (item.Type == EntityType.Line)
                    {
                        Line linha = (Line)item;
                        desenhador.DrawLine(new Pen(Color.Black), 
                            (float)linha.StartPoint[0], 
                            (float)linha.StartPoint[1], 
                            (float)linha.EndPoint[0], 
                            (float)linha.EndPoint[1]);
                    }
                    else
                    {
                        throw new Exception("Tipo nao suportado");
                    }
                } 
            }
        }

        private void DesenharRetangulos(IEnumerable<Rectangle> rectangles)
        {
            foreach (var rectangle in rectangles)
            {
                desenhador.DrawRectangle(new Pen(Color.Black), rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
            }
        }

        private void DesenharPolilinhas(IEnumerable<Polyline> polylines)
        {
            foreach (var line in polylines)
            {
                foreach(Line linha in line.Explode())
                {
                    desenhador.DrawLine(new Pen(Color.Black), (float)linha.StartPoint[0], (float)linha.StartPoint[1], (float)linha.EndPoint[0], (float)linha.EndPoint[1]);
                }
            }
        }

        private void DesenharTexto(IEnumerable<Text> texts)
        {
            foreach (var item in texts)
            {
                throw new NotImplementedException();
            }   
        }

        private void DesenharMultiLinhas(IEnumerable<MLine> mLines)
        {
            foreach (var item in mLines)
            {
                throw new NotImplementedException();
            }
        }

        private void DesenharImagem(IEnumerable<netDxf.Entities.Image> images)
        {
            foreach (var item in images)
            {
                throw new NotImplementedException();
            }
        }

        private void DesenharEllipses(IEnumerable<Ellipse> ellipses)
        {
            foreach (var ellipse in ellipses)
            {
                desenhador.RotateTransform((float) ellipse.Rotation);
                desenhador.DrawArc(new Pen(Color.Black), (float)ellipse.Center[0], (float)ellipse.Center[1], (float)ellipse.MajorAxis, (float) ellipse.MinorAxis , (float)ellipse.StartAngle, (float)ellipse.StartAngle);
            }
            desenhador.RotateTransform(0f);
        }

        private void DesenharLinhas(IEnumerable<Line> lines)
        {
            foreach (var line in lines)
            {
                desenhador.DrawLine(new Pen(Color.Black), (float) line.StartPoint[0], (float) line.StartPoint[1], (float) line.EndPoint[0], (float) line.EndPoint[1]);
            }

        }

        private void DesenharCirculos(IEnumerable<Circle> circles)
        {
            foreach (var circle in circles)
            {
                desenhador.DrawEllipse(new Pen(Color.Black), (float) circle.Center[0], (float) circle.Center[1], (float) circle.Radius, (float) circle.Radius);
            }
        }

        public Bitmap GetBitmap()
        {
            return bitmap;
        }

        private void AnalisarLinhas(IEnumerable<Line> linhas)
        {
            foreach (var linha in linhas)
            {
                
                //Verifica Min X
                VerificaMinX(linha.StartPoint[0] > linha.EndPoint[0] ? linha.EndPoint[0] : linha.StartPoint[0]);

                //Verifica Min Y
                VerificaMinY(linha.StartPoint[1] > linha.EndPoint[1] ? linha.EndPoint[1] : linha.StartPoint[1]);

                //Verifica Max X
                VerificaMaxX(linha.StartPoint[0] < linha.EndPoint[0] ? linha.EndPoint[0] : linha.StartPoint[0]);

                //Verifica Max Y
                VerificaMaxY(linha.StartPoint[1] < linha.EndPoint[1] ? linha.EndPoint[1] : linha.StartPoint[1]);
            }
        }

        private void AnalisarPolilinhas(IEnumerable<Polyline> polylines)
        {
            foreach (Polyline polyline in polylines)
            {
                AnalisarLinhas((IEnumerable<Line>) polyline.Explode());
            }
        }

        private void AnalisarTexto(IEnumerable<Text> texts)
        {
            foreach (var text in texts)
            {
                //Verifica Min X
                VerificaMinX(text.Position[0]);

                //Verifica Min Y
                VerificaMinY(text.Position[1]);

                //Verifica Max X
                VerificaMaxX(text.Position[0] + text.Width);

                //Verifica Max Y
                VerificaMaxY(text.Position[1] + text.Height);
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
                VerificaMinX(image.Position[0]);

                //Verifica Min Y
                VerificaMinY(image.Position[1]);

                //Verifica Max X
                VerificaMaxX(image.Position[0] + image.Width);

                //Verifica Max Y
                VerificaMaxX(image.Position[1] + image.Height);
            }
        }

        private void AnalisarElipses(IEnumerable<Ellipse> ellipses)
        {
            foreach (var ellipse  in ellipses)
            {
                //Verifica Min X
                VerificaMinX(ellipse.Center[0] - ellipse.MajorAxis);

                //Verifica Min Y
                VerificaMinY(ellipse.Center[1] - ellipse.MajorAxis);

                //Verifica Max X
                VerificaMaxX(ellipse.Center[0] + ellipse.MajorAxis);

                //Verifica Max Y
                VerificaMaxX(ellipse.Center[1] + ellipse.MajorAxis);
            }
        }

        private void AnalisarCirculos(IEnumerable<Circle> circulos)
        {
            foreach (var circulo in circulos)
            {
                //Verifica Min X
                VerificaMinX(circulo.Center[0] - circulo.Radius);

                //Verifica Min Y
                VerificaMinY(circulo.Center[1] - circulo.Radius);

                //Verifica Max X
                VerificaMaxX(circulo.Center[0] + circulo.Radius);

                //Verifica Max Y
                VerificaMaxY(circulo.Center[1] + circulo.Radius);
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
