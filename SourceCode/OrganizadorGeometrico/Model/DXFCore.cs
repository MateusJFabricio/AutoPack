using netDxf;
using netDxf.Header;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorGeometrico.Model
{
    class DXF
    {
        public void Teste()
        {
            bool version;
            DxfDocument aquivoBase = DxfDocument.Load(@"C:\Users\ROBOSOFT_MATEUS\Desktop\Estagio Supervisionado\Estagio 1\Arquivo Morto\DXF\Peça1.DXF");
            DxfVersion a = DxfDocument.CheckDxfFileVersion("", out version);

            //Entender a estrutura do arquivo DXF

        }
    }
}
