using Plantillaformulario.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plantillaformulario.Formulario
{
    public partial class formularioPlantilla : Form
    {
        Conexion conec = new Conexion();
        Propiedades propiedades = new Propiedades();
        Existingvalue existingvalue = new Existingvalue();
        private int Tipo = 0;

        private string tableName;
        private string columnname1;
        private string columnname2;
        private string transacDatos;


        public formularioPlantilla()
        {
            InitializeComponent();
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            Codigo.Clear();
            Descripcion.Clear();
            CargarDatos(false, null);
            busqueda.Clear();
            Tipo = 0;
            Descripcion.Focus();
        }

        private void formularioPlantilla_Load(object sender, EventArgs e)
        {
            //  MessageBox.Show(propiedades.FullTableName);
            this.Text = propiedades.fullFormName;
            tableName = propiedades.FullTableName;
            columnname1 = propiedades.FullcolumnId;
            columnname2 = propiedades.FullcampoDescrip;
            Consultar();
        }
 
        private void aceptar_Click(object sender, EventArgs e)
        {
            if (Descripcion.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingresar valor", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Descripcion.Focus();
                return;
            }

            if (Tipo == 0)
            {
                //Insertar
                if (existingvalue.ValorExiste(Descripcion.Text.Trim(), 1, datos))
                {
                    MessageBox.Show("Descripción existe");
                    return;
                }
                //Insertar en la tabla                      
                transacDatos = $"INSERT INTO {tableName}  ({columnname2}) VALUES(@{columnname2})";
            }
            else
            {
                transacDatos = $"UPDATE  {tableName}  SET {columnname2} =@{columnname2} WHERE {columnname1}=@{columnname1}";
            }

            using (SqlConnection connection = new SqlConnection(conec.CadenaConexion))
            {
                connection.Open();
                SqlCommand sqlCommand = connection.CreateCommand();
                SqlTransaction sqlTransaction;
                sqlTransaction = connection.BeginTransaction("DATOS");
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.CommandText = transacDatos;
                sqlCommand.CommandType = CommandType.Text;
                if (Tipo == 1) sqlCommand.Parameters.Add(columnname1, SqlDbType.Int).Value = Codigo.Text;

                sqlCommand.Parameters.Add(columnname2, SqlDbType.NVarChar, 100).Value = Descripcion.Text;
                sqlCommand.ExecuteNonQuery();

                try
                {
                    MessageBox.Show("Realizado");
                    sqlTransaction.Commit();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Commit Exception Type: {0}" + ex.GetType(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show(" Message: {0}" + ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        MessageBox.Show("Commit Exception Type: {0}" + ex2.GetType(), ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MessageBox.Show(" Message: {0}" + ex2.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                connection.Close();
            }
            Tipo = 1;
            CargarDatos(false, null);

        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CargarDatos(bool tieneparametro, TextBox valorBuscar)
        {
            string QueryWhere = tieneparametro ? $"WHERE {columnname2} LIKE '{valorBuscar.Text}%'" : "";

            string QueryAccion = $"SELECT {columnname1},{columnname2} FROM {tableName} {QueryWhere}";
            conec.ConectarSistema();
            SqlDataAdapter adaptador = new SqlDataAdapter(QueryAccion, conec.CON);

            DataSet dsdatos = new DataSet();
            adaptador.Fill(dsdatos, "Datos");
            datos.DataSource = dsdatos;
            datos.DataMember = "Datos";
            adaptador.Dispose();
            dsdatos.Dispose();
            datos.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            datos.Columns[0].Visible = false;
            conec.DesconectarSistema();
        }
        private void Consultar()
        {
            CargarDatos(false, null);
        }

        private void formularioPlantilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)    this.Dispose();
        }

        private void datos_Click(object sender, EventArgs e)
        {
            Tipo = 1;
            Codigo.Text = datos[0, datos.CurrentCell.RowIndex].Value.ToString();
            Descripcion.Text = datos[1, datos.CurrentCell.RowIndex].Value.ToString();
            Descripcion.Focus();
        }
    }
}
