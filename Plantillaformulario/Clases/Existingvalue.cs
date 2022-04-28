using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plantillaformulario.Clases
{
   public class Existingvalue
    {
        bool siEexiste = false;

        public bool ValorExiste(string cadena, int col, DataGridView datos)
        {
            siEexiste = false;
            for (int i = 0; i < datos.RowCount; i++)
            {
                if (datos[col, i].Value.ToString().ToLower().Contains(cadena.ToString().ToLower()))
                {
                    siEexiste = true;
                    break;
                }
            }

            return siEexiste;
        }
    }
}
