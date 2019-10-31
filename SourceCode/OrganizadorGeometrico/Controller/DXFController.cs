using OrganizadorGeometrico.Model;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OrganizadorGeometrico.Controller
{
    class DXFController
    {
        private Organizer organizador = new Organizer();
        public DXFItem placaGravacao;
        public DXFItem figuraGeometricaAtual;
        public List<DXFItem> figurasGeometricas = new List<DXFItem>();

        public void IniciarOrganizador()
        {
            if (placaGravacao == null)
                throw new Exception("Atencao! Nao há placa de gravacao!");

            if (figurasGeometricas.Count == 0)
                throw new Exception("Atencao! Nao há figuras geometricas para organizar!");

            organizador.IniciarOrganizador(placaGravacao, figurasGeometricas);
        }

        public Bitmap AdicionarPlacaGravacao(string path, int largura, int altura)
        {
            DXFItem placaGravacao = new DXFItem(path, largura, altura);
            figuraGeometricaAtual = placaGravacao;
            return placaGravacao.GetBitmap();
        }

        public Bitmap AdicionarFiguraGeometrica(string path, int largura, int altura)
        {
            DXFItem item = new DXFItem(path, largura, altura);
            figurasGeometricas.Add(item);
            figuraGeometricaAtual = item;
            return item.GetBitmap();
        }

        public void RemoverPlacaGravacao()
        {
            placaGravacao = null;
            figuraGeometricaAtual = null;
        }

        public void RemoverFiguraGeometrica(string path)
        {
            foreach (var fg in figurasGeometricas)
            {
                if (fg.path == path)
                    figurasGeometricas.Remove(fg);
            }
            figuraGeometricaAtual = null;
        }

        public bool ValidarArquivoDXF(string path)
        {
            return true;
        }

        internal Bitmap ResizeFiguraAtual(float zoom, float offsetX, float offsetY, int largura, int altura)
        {
            if (figuraGeometricaAtual == null)
                return new Bitmap(0, 0);

            figuraGeometricaAtual.GerarBitmap(zoom, offsetX, offsetY, largura, altura);
            return figuraGeometricaAtual.GetBitmap();
        }
    }
}
