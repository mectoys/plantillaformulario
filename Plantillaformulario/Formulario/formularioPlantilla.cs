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
        DataSet dsdatos;

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
            CargarDatos();
            Codigo.Text=  ObtainLastID().ToString();
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
            if (Codigo.Text.Trim().Length == 0)
            {
                MessageBox.Show("Código no generado", ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Descripcion.Focus();
                return;
            }

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
            CargarDatos();

        }

        private void cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CargarDatos( )
        {
            string QueryAccion = $"SELECT {columnname1},{columnname2} FROM {tableName}";
            conec.ConectarSistema();

            SqlDataAdapter adaptador = new SqlDataAdapter(QueryAccion, conec.CON);

            dsdatos = new DataSet();
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
            CargarDatos( );
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

        private void busqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) BuscarInformacion(busqueda);
        }

        private void BuscarInformacion(TextBox valorBuscar)
        {
            DataView dv;
            dv = new DataView(dsdatos.Tables["Datos"], columnname2 + " LIKE '*" + valorBuscar.Text.Replace("'", "") + "*' ", columnname2 + " Desc", DataViewRowState.CurrentRows);
            datos.DataSource = dv;
            datos.Columns[0].Visible = false;
        }
        private int ObtainLastID()
        {
          int lastID;
                conec.ConectarSistema();
                SqlCommand sqlCommand = new SqlCommand($"Select Ident_Current('{tableName}')+1 AS ID", conec.CON);

                sqlCommand.CommandType = CommandType.Text;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    lastID = Convert.ToInt32( reader["ID"]);
                }
                else
                {
                    lastID = 0;
                }
                reader.Close();
                sqlCommand.Dispose();
                conec.DesconectarSistema();

            return lastID;
        }
    }
}
