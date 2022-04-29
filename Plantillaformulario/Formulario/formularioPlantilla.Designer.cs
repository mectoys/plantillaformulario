
namespace Plantillaformulario.Formulario
{
    partial class formularioPlantilla
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.grupodatos = new System.Windows.Forms.GroupBox();
            this.sololectura = new System.Windows.Forms.GroupBox();
            this.Nuevo = new System.Windows.Forms.Button();
            this.cerrar = new System.Windows.Forms.Button();
            this.aceptar = new System.Windows.Forms.Button();
            this.Descripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.datos = new System.Windows.Forms.DataGridView();
            this.busqueda = new System.Windows.Forms.TextBox();
            this.grupodatos.SuspendLayout();
            this.sololectura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datos)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Busqueda Descripción :";
            // 
            // grupodatos
            // 
            this.grupodatos.Controls.Add(this.sololectura);
            this.grupodatos.Controls.Add(this.Descripcion);
            this.grupodatos.Controls.Add(this.label2);
            this.grupodatos.Controls.Add(this.Codigo);
            this.grupodatos.Controls.Add(this.label1);
            this.grupodatos.Location = new System.Drawing.Point(364, 7);
            this.grupodatos.Name = "grupodatos";
            this.grupodatos.Size = new System.Drawing.Size(286, 292);
            this.grupodatos.TabIndex = 7;
            this.grupodatos.TabStop = false;
            this.grupodatos.Text = "Datos";
            // 
            // sololectura
            // 
            this.sololectura.Controls.Add(this.Nuevo);
            this.sololectura.Controls.Add(this.cerrar);
            this.sololectura.Controls.Add(this.aceptar);
            this.sololectura.Location = new System.Drawing.Point(6, 102);
            this.sololectura.Name = "sololectura";
            this.sololectura.Size = new System.Drawing.Size(275, 46);
            this.sololectura.TabIndex = 7;
            this.sololectura.TabStop = false;
            // 
            // Nuevo
            // 
            this.Nuevo.Location = new System.Drawing.Point(12, 12);
            this.Nuevo.Name = "Nuevo";
            this.Nuevo.Size = new System.Drawing.Size(75, 23);
            this.Nuevo.TabIndex = 9;
            this.Nuevo.Text = "Nuevo";
            this.Nuevo.UseVisualStyleBackColor = true;
            this.Nuevo.Click += new System.EventHandler(this.Nuevo_Click);
            // 
            // cerrar
            // 
            this.cerrar.Location = new System.Drawing.Point(187, 12);
            this.cerrar.Name = "cerrar";
            this.cerrar.Size = new System.Drawing.Size(75, 23);
            this.cerrar.TabIndex = 8;
            this.cerrar.Text = "Cerrar";
            this.cerrar.UseVisualStyleBackColor = true;
            this.cerrar.Click += new System.EventHandler(this.cerrar_Click);
            // 
            // aceptar
            // 
            this.aceptar.Location = new System.Drawing.Point(100, 12);
            this.aceptar.Name = "aceptar";
            this.aceptar.Size = new System.Drawing.Size(75, 23);
            this.aceptar.TabIndex = 7;
            this.aceptar.Text = "Aceptar";
            this.aceptar.UseVisualStyleBackColor = true;
            this.aceptar.Click += new System.EventHandler(this.aceptar_Click);
            // 
            // Descripcion
            // 
            this.Descripcion.Location = new System.Drawing.Point(83, 56);
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Size = new System.Drawing.Size(178, 20);
            this.Descripcion.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción :";
            // 
            // Codigo
            // 
            this.Codigo.BackColor = System.Drawing.SystemColors.Info;
            this.Codigo.Enabled = false;
            this.Codigo.Location = new System.Drawing.Point(83, 30);
            this.Codigo.Name = "Codigo";
            this.Codigo.Size = new System.Drawing.Size(42, 20);
            this.Codigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código :";
            // 
            // datos
            // 
            this.datos.AllowUserToAddRows = false;
            this.datos.AllowUserToDeleteRows = false;
            this.datos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.datos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datos.Location = new System.Drawing.Point(12, 37);
            this.datos.Name = "datos";
            this.datos.ReadOnly = true;
            this.datos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datos.Size = new System.Drawing.Size(334, 262);
            this.datos.TabIndex = 6;
            this.datos.Click += new System.EventHandler(this.datos_Click);
            // 
            // busqueda
            // 
            this.busqueda.Location = new System.Drawing.Point(138, 11);
            this.busqueda.Name = "busqueda";
            this.busqueda.Size = new System.Drawing.Size(208, 20);
            this.busqueda.TabIndex = 9;
            this.busqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.busqueda_KeyPress);
            // 
            // formularioPlantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 313);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.grupodatos);
            this.Controls.Add(this.datos);
            this.Controls.Add(this.busqueda);
            this.KeyPreview = true;
            this.Name = "formularioPlantilla";
            this.Text = "formularioPlantilla";
            this.Load += new System.EventHandler(this.formularioPlantilla_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.formularioPlantilla_KeyPress);
            this.grupodatos.ResumeLayout(false);
            this.grupodatos.PerformLayout();
            this.sololectura.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grupodatos;
        private System.Windows.Forms.GroupBox sololectura;
        private System.Windows.Forms.Button Nuevo;
        private System.Windows.Forms.Button cerrar;
        private System.Windows.Forms.Button aceptar;
        private System.Windows.Forms.TextBox Descripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Codigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView datos;
        private System.Windows.Forms.TextBox busqueda;
    }
}