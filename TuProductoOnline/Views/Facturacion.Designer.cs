namespace TuProductoOnline.Views
{
    partial class Facturacion
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
            this.lblName = new System.Windows.Forms.Label();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.ClientBox = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.ProductBox = new System.Windows.Forms.GroupBox();
            this.txtCantidad = new System.Windows.Forms.Label();
            this.CantidadBox = new System.Windows.Forms.TextBox();
            this.btnAgregarCarrito = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.txtDgv = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.ClientBox.SuspendLayout();
            this.ProductBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(264, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 18);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Factura:";
            // 
            // dgvProductos
            // 
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(12, 136);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(590, 234);
            this.dgvProductos.TabIndex = 2;
            // 
            // ClientBox
            // 
            this.ClientBox.Controls.Add(this.button1);
            this.ClientBox.Controls.Add(this.comboBox1);
            this.ClientBox.Location = new System.Drawing.Point(12, 30);
            this.ClientBox.Name = "ClientBox";
            this.ClientBox.Size = new System.Drawing.Size(213, 57);
            this.ClientBox.TabIndex = 3;
            this.ClientBox.TabStop = false;
            this.ClientBox.Text = "Cliente";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(134, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Añadir";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(7, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // ProductBox
            // 
            this.ProductBox.Controls.Add(this.txtCantidad);
            this.ProductBox.Controls.Add(this.CantidadBox);
            this.ProductBox.Controls.Add(this.btnAgregarCarrito);
            this.ProductBox.Controls.Add(this.button2);
            this.ProductBox.Controls.Add(this.comboBox2);
            this.ProductBox.Location = new System.Drawing.Point(366, 30);
            this.ProductBox.Name = "ProductBox";
            this.ProductBox.Size = new System.Drawing.Size(236, 89);
            this.ProductBox.TabIndex = 4;
            this.ProductBox.TabStop = false;
            this.ProductBox.Text = "Producto";
            // 
            // txtCantidad
            // 
            this.txtCantidad.AutoSize = true;
            this.txtCantidad.Location = new System.Drawing.Point(6, 44);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(52, 13);
            this.txtCantidad.TabIndex = 6;
            this.txtCantidad.Text = "Cantidad:";
            // 
            // CantidadBox
            // 
            this.CantidadBox.Location = new System.Drawing.Point(9, 60);
            this.CantidadBox.Name = "CantidadBox";
            this.CantidadBox.Size = new System.Drawing.Size(117, 20);
            this.CantidadBox.TabIndex = 3;
            this.CantidadBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnAgregarCarrito
            // 
            this.btnAgregarCarrito.Location = new System.Drawing.Point(132, 57);
            this.btnAgregarCarrito.Name = "btnAgregarCarrito";
            this.btnAgregarCarrito.Size = new System.Drawing.Size(98, 23);
            this.btnAgregarCarrito.TabIndex = 2;
            this.btnAgregarCarrito.Text = "Agregar a factura";
            this.btnAgregarCarrito.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(162, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Añadir producto";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(7, 20);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(149, 21);
            this.comboBox2.TabIndex = 0;
            // 
            // btnFacturar
            // 
            this.btnFacturar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnFacturar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFacturar.Location = new System.Drawing.Point(534, 376);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(68, 26);
            this.btnFacturar.TabIndex = 5;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = false;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // txtDgv
            // 
            this.txtDgv.AutoSize = true;
            this.txtDgv.Location = new System.Drawing.Point(16, 106);
            this.txtDgv.Name = "txtDgv";
            this.txtDgv.Size = new System.Drawing.Size(97, 13);
            this.txtDgv.TabIndex = 6;
            this.txtDgv.Text = "Lista de productos:";
            // 
            // Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 411);
            this.Controls.Add(this.txtDgv);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.ProductBox);
            this.Controls.Add(this.ClientBox);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.lblName);
            this.Name = "Facturacion";
            this.Text = "Facturacion";
            this.Load += new System.EventHandler(this.Facturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ClientBox.ResumeLayout(false);
            this.ProductBox.ResumeLayout(false);
            this.ProductBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.GroupBox ClientBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox ProductBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox CantidadBox;
        private System.Windows.Forms.Button btnAgregarCarrito;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Label txtCantidad;
        private System.Windows.Forms.Label txtDgv;
    }
}