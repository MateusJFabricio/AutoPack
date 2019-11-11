using netDxf;
using netDxf.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizadorGeometrico.Model
{
    public static class DXFExport
    {
        public static void Exportar(string path, DXFItem item)
        {
            DxfDocument dxf = new DxfDocument();

            foreach (var c in item.entities.OfType<Circle>())
            {
                dxf.AddEntity((EntityObject)c.Clone());
            }

            dxf.Save(@"C:/Temp/teste.dxf");
        }
    }
}
