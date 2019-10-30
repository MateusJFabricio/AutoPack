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
        public List<DXFItem> figurasGeometricas = new List<DXFItem>();

        public void IniciarOrganizador()
        {
            if (placaGravacao == null)
                throw new Exception("Atencao! Nao há placa de gravacao!");

            if (figurasGeometricas.Count == 0)
                throw new Exception("Atencao! Nao há figuras geometricas para organizar!");

            organizador.IniciarOrganizador(placaGravacao, figurasGeometricas);
        }

        public Bitmap AdicionarPlacaGravacao(string path)
        {
            DXFItem placaGravacao = new DXFItem(path);
            return placaGravacao.GetBitmap();
        }

        public Bitmap AdicionarFiguraGeometrica(string path)
        {
            DXFItem item = new DXFItem(path);
            figurasGeometricas.Add(item);
            return item.GetBitmap();
        }

        public void RemoverPlacaGravacao()
        {
            placaGravacao = null;
        }

        public void RemoverFiguraGeometrica(string path)
        {
            foreach (var fg in figurasGeometricas)
            {
                if (fg.path == path)
                    figurasGeometricas.Remove(fg);
            }
        }

        public bool ValidarArquivoDXF(string path)
        {
            return true;
        }

    }
}
