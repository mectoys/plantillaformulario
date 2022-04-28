using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Plantillaformulario.Clases;
using Plantillaformulario.Formulario;
namespace Plantillaformulario
{
    public partial class principal : Form
    {
        Propiedades propiedades = new Propiedades();
        public principal()
        {
            InitializeComponent();
        }

        private void plantillaFormularioToolStripMenuItem_Click(object sender, EventArgs e)
        {           

            propiedades.fullFormName = "Mantenimiento Tabla Plantilla ";
            propiedades.FullTableName = "TablaPlantilla";
            propiedades.FullcolumnId = "id";
            propiedades.FullcampoDescrip = "descripcion";

            formularioPlantilla  formulario = new formularioPlantilla();
            formulario.MdiParent = this;
            formulario.Show();
        }
    }
}
