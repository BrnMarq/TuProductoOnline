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
            this.ClientBox1 = new System.Windows.Forms.ComboBox();
            this.ProductBox = new System.Windows.Forms.GroupBox();
            this.txtCantidad = new System.Windows.Forms.Label();
            this.CantidadBox = new System.Windows.Forms.TextBox();
            this.btnAgregarCarrito = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ProductBox2 = new System.Windows.Forms.ComboBox();
            this.txtDgv = new System.Windows.Forms.Label();
            this.ListProducTable = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtTituloSubTotal = new System.Windows.Forms.Label();
            this.txtTituloTotal = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.Label();
            this.groupBoxSubtotal = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ClientBox.SuspendLayout();
            this.ProductBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(264, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 18);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Factura:";
            // 
            // dgvProductos
            // 
            this.dgvProductos.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
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
            this.ClientBox.Controls.Add(this.ClientBox1);
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
            // ClientBox1
            // 
            this.ClientBox1.FormattingEnabled = true;
            this.ClientBox1.Location = new System.Drawing.Point(7, 20);
            this.ClientBox1.Name = "ClientBox1";
            this.ClientBox1.Size = new System.Drawing.Size(121, 21);
            this.ClientBox1.TabIndex = 0;
            // 
            // ProductBox
            // 
            this.ProductBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductBox.Controls.Add(this.btnAgregarAlCarrito);
            this.ProductBox.Controls.Add(this.bntAñadirProduct);
            this.ProductBox.Controls.Add(this.txtCantidad);
            this.ProductBox.Controls.Add(this.CantidadBox);
            this.ProductBox.Controls.Add(this.btnAgregarCarrito);
            this.ProductBox.Controls.Add(this.button2);
            this.ProductBox.Controls.Add(this.ProductBox2);
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
            this.btnAgregarCarrito.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAgregarCarrito.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAgregarCarrito.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAgregarCarrito.Location = new System.Drawing.Point(132, 57);
            this.btnAgregarCarrito.Name = "btnAgregarCarrito";
            this.btnAgregarCarrito.Size = new System.Drawing.Size(98, 23);
            this.btnAgregarCarrito.TabIndex = 2;
            this.btnAgregarCarrito.Text = "Agregar a factura";
            this.btnAgregarCarrito.UseVisualStyleBackColor = false;
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
            // ProductBox2
            // 
            this.ProductBox2.FormattingEnabled = true;
            this.ProductBox2.Location = new System.Drawing.Point(7, 20);
            this.ProductBox2.Name = "ProductBox2";
            this.ProductBox2.Size = new System.Drawing.Size(149, 21);
            this.ProductBox2.TabIndex = 0;
            this.ProductBox2.Text = "- Seleccionar -";
            // 
            this.ListProducTable.AllowUserToAddRows = false;
            this.ListProducTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListProducTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ListProducTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ListProducTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListProducTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListProducTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ListProducTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListProducTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.name,
            this.precio,
            this.Cantidad,
            this.delete});
            this.ListProducTable.EnableHeadersVisualStyles = false;
            this.ListProducTable.Location = new System.Drawing.Point(12, 125);
            this.ListProducTable.Name = "ListProducTable";
            this.ListProducTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ListProducTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ListProducTable.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.ListProducTable.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.ListProducTable.RowTemplate.DefaultCellStyle.NullValue = "1";
            this.ListProducTable.RowTemplate.DividerHeight = 2;
            this.ListProducTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ListProducTable.Size = new System.Drawing.Size(584, 235);
            this.ListProducTable.TabIndex = 7;
            this.ListProducTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ListProducTable_CellContentClick);
            // 
            // ID
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ID.DefaultCellStyle = dataGridViewCellStyle2;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // name
            // 
            this.name.HeaderText = "Nombre";
            this.name.Name = "name";
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // precio
            // 
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            this.precio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // delete
            // 
            this.delete.HeaderText = "Eliminar";
            this.delete.Name = "delete";
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.Text = "Eliminar";
            // 
            // btnFacturar
            // 
            this.btnFacturar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFacturar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
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
            this.dataGridViewImageColumn1.HeaderText = "Eliminar";
            this.dataGridViewImageColumn1.Image = global::TuProductoOnline.Properties.Resources.deleteIcon1;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 117;
            // 
            // txtTituloSubTotal
            // 
            this.txtTituloSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTituloSubTotal.AutoSize = true;
            this.txtTituloSubTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.txtTituloSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTituloSubTotal.ForeColor = System.Drawing.Color.White;
            this.txtTituloSubTotal.Location = new System.Drawing.Point(3, 10);
            this.txtTituloSubTotal.Name = "txtTituloSubTotal";
            this.txtTituloSubTotal.Size = new System.Drawing.Size(82, 20);
            this.txtTituloSubTotal.TabIndex = 18;
            this.txtTituloSubTotal.Text = "Subtotal:";
            // 
            // txtTituloTotal
            // 
            this.txtTituloTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTituloTotal.AutoSize = true;
            this.txtTituloTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.txtTituloTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTituloTotal.ForeColor = System.Drawing.Color.White;
            this.txtTituloTotal.Location = new System.Drawing.Point(8, 7);
            this.txtTituloTotal.Name = "txtTituloTotal";
            this.txtTituloTotal.Size = new System.Drawing.Size(54, 20);
            this.txtTituloTotal.TabIndex = 19;
            this.txtTituloTotal.Text = "Total:";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubTotal.AutoSize = true;
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(91, 10);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(19, 20);
            this.txtSubTotal.TabIndex = 20;
            this.txtSubTotal.Text = "0";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.AutoSize = true;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(68, 7);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(19, 20);
            this.txtTotal.TabIndex = 21;
            this.txtTotal.Text = "0";
            // 
            // groupBoxSubtotal
            // 
            this.groupBoxSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxSubtotal.Controls.Add(this.txtTituloSubTotal);
            this.groupBoxSubtotal.Controls.Add(this.txtSubTotal);
            this.groupBoxSubtotal.Location = new System.Drawing.Point(12, 366);
            this.groupBoxSubtotal.Name = "groupBoxSubtotal";
            this.groupBoxSubtotal.Size = new System.Drawing.Size(210, 37);
            this.groupBoxSubtotal.TabIndex = 22;
            this.groupBoxSubtotal.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.txtTituloTotal);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Location = new System.Drawing.Point(228, 369);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 34);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
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
        private System.Windows.Forms.ComboBox ClientBox1;
        private System.Windows.Forms.GroupBox ProductBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox ProductBox2;
        private System.Windows.Forms.TextBox CantidadBox;
        private System.Windows.Forms.Button btnAgregarCarrito;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Label txtCantidad;
        private System.Windows.Forms.Label txtDgv;
    }
}