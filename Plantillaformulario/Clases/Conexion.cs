using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plantillaformulario.Clases
{
    public class Conexion
    {
        public SqlConnection CON = null;

        public SqlConnection CONIIS = null;

        public string CadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["CadenaACIMECT"].ConnectionString;

        public void ConectarSistema()
        {
            CON = new SqlConnection(CadenaConexion);

            CON.Open();
        }
        public void DesconectarSistema()
        {
            CON.Close();
        }

    }
}
