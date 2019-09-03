using OrganizadorGeometrico.Model;
using System.Collections.Generic;

namespace OrganizadorGeometrico.Controller
{
    class DXFController
    {
        private Validacoes validacoes = new Validacoes();

        public bool ValidarArquivoDXF(string path)
        {
            return validacoes.ValidarArquivoDXF(path);
        }

        public void IniciarOrganizador(string pathPlacaGravacao, List<string> pathFigurasGeometricas)
        {

        }

    }
}
