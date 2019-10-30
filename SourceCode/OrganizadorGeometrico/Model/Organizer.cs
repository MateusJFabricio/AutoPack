using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorGeometrico.Model
{
    class Organizer
    {
        DXFItem PlacaCalibracao;
        List<DXFItem> FigurasGeometricas = new List<DXFItem>();
           
        public void Exportar(string pathDestino)
        {

        }

        public void IniciarOrganizador(DXFItem placaCalibracao, List<DXFItem> figurasGeometricas)
        {
            this.PlacaCalibracao = placaCalibracao;
            this.FigurasGeometricas = figurasGeometricas;
        }

        public Bitmap BitmapResultado()
        {
            return new Bitmap(100, 100);
        }

    }
}
