using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorGeometrico.Model
{
    class Organizer
    {
        DXFItem PlacaCalibracao;
        List<DXFItem> FigurasGeometricas;

        public void Iniciar()
        {
            ValidarDados();


        }

        public void AdicionarPlacaCalibracao(string path)
        {
            PlacaCalibracao = new DXFItem(path);
        }

        public void AdicionarFiguraGeometrica(string path)
        {
            FigurasGeometricas.Add(new DXFItem(path));
        }

        private void ValidarDados()
        {
            throw new NotImplementedException();
        }
    }
}
