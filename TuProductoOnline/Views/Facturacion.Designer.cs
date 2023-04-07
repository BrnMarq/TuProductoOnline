﻿namespace TuProductoOnline.Views
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ClientBox = new System.Windows.Forms.GroupBox();
            this.btnAñadirClient = new System.Windows.Forms.Button();
            this.ClientBox1 = new System.Windows.Forms.ComboBox();
            this.ProductBox = new System.Windows.Forms.GroupBox();
            this.btnAgregarAlCarrito = new System.Windows.Forms.Button();
            this.bntAñadirProduct = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.Label();
            this.CantidadBox = new System.Windows.Forms.TextBox();
            this.ProductBox2 = new System.Windows.Forms.ComboBox();
            this.txtDgv = new System.Windows.Forms.Label();
            this.ListProducTable = new System.Windows.Forms.DataGridView();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtTituloSubTotal = new System.Windows.Forms.Label();
            this.txtTituloTotal = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.Label();
            this.groupBoxSubtotal = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ClientBox.SuspendLayout();
            this.ProductBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListProducTable)).BeginInit();
            this.groupBoxSubtotal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientBox
            // 
            this.ClientBox.Controls.Add(this.btnAñadirClient);
            this.ClientBox.Controls.Add(this.ClientBox1);
            this.ClientBox.Location = new System.Drawing.Point(12, 14);
            this.ClientBox.Name = "ClientBox";
            this.ClientBox.Size = new System.Drawing.Size(184, 80);
            this.ClientBox.TabIndex = 3;
            this.ClientBox.TabStop = false;
            this.ClientBox.Text = "Cliente";
            // 
            // btnAñadirClient
            // 
            this.btnAñadirClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAñadirClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAñadirClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAñadirClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirClient.ForeColor = System.Drawing.Color.White;
            this.btnAñadirClient.Location = new System.Drawing.Point(17, 45);
            this.btnAñadirClient.Name = "btnAñadirClient";
            this.btnAñadirClient.Size = new System.Drawing.Size(137, 23);
            this.btnAñadirClient.TabIndex = 14;
            this.btnAñadirClient.Text = "Añadir Nuevo";
            this.btnAñadirClient.UseVisualStyleBackColor = false;
            // 
            // ClientBox1
            // 
            this.ClientBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ClientBox1.FormattingEnabled = true;
            this.ClientBox1.Location = new System.Drawing.Point(6, 18);
            this.ClientBox1.Name = "ClientBox1";
            this.ClientBox1.Size = new System.Drawing.Size(165, 21);
            this.ClientBox1.TabIndex = 0;
            this.ClientBox1.SelectedIndexChanged += new System.EventHandler(this.ClientBox1_SelectedIndexChanged);
            // 
            // ProductBox
            // 
            this.ProductBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProductBox.Controls.Add(this.btnAgregarAlCarrito);
            this.ProductBox.Controls.Add(this.bntAñadirProduct);
            this.ProductBox.Controls.Add(this.txtCantidad);
            this.ProductBox.Controls.Add(this.CantidadBox);
            this.ProductBox.Controls.Add(this.ProductBox2);
            this.ProductBox.Location = new System.Drawing.Point(329, 14);
            this.ProductBox.Name = "ProductBox";
            this.ProductBox.Size = new System.Drawing.Size(273, 89);
            this.ProductBox.TabIndex = 4;
            this.ProductBox.TabStop = false;
            this.ProductBox.Text = "Producto";
            // 
            // btnAgregarAlCarrito
            // 
            this.btnAgregarAlCarrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAgregarAlCarrito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarAlCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarAlCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAlCarrito.ForeColor = System.Drawing.Color.White;
            this.btnAgregarAlCarrito.Location = new System.Drawing.Point(141, 58);
            this.btnAgregarAlCarrito.Name = "btnAgregarAlCarrito";
            this.btnAgregarAlCarrito.Size = new System.Drawing.Size(117, 23);
            this.btnAgregarAlCarrito.TabIndex = 16;
            this.btnAgregarAlCarrito.Text = "Agregar al carrito";
            this.btnAgregarAlCarrito.UseVisualStyleBackColor = false;
            this.btnAgregarAlCarrito.Click += new System.EventHandler(this.btnAgregarAlCarrito_Click);
            // 
            // bntAñadirProduct
            // 
            this.bntAñadirProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.bntAñadirProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntAñadirProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntAñadirProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntAñadirProduct.ForeColor = System.Drawing.Color.White;
            this.bntAñadirProduct.Location = new System.Drawing.Point(148, 19);
            this.bntAñadirProduct.Name = "bntAñadirProduct";
            this.bntAñadirProduct.Size = new System.Drawing.Size(110, 23);
            this.bntAñadirProduct.TabIndex = 15;
            this.bntAñadirProduct.Text = "Añadir Nuevo Producto";
            this.bntAñadirProduct.UseVisualStyleBackColor = false;
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
            this.CantidadBox.Size = new System.Drawing.Size(126, 20);
            this.CantidadBox.TabIndex = 3;
            this.CantidadBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.CantidadBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CantidadBox_KeyPress);
            // 
            // ProductBox2
            // 
            this.ProductBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProductBox2.FormattingEnabled = true;
            this.ProductBox2.Location = new System.Drawing.Point(9, 20);
            this.ProductBox2.Name = "ProductBox2";
            this.ProductBox2.Size = new System.Drawing.Size(133, 21);
            this.ProductBox2.TabIndex = 0;
            // 
            // txtDgv
            // 
            this.txtDgv.AutoSize = true;
            this.txtDgv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDgv.Location = new System.Drawing.Point(16, 99);
            this.txtDgv.Name = "txtDgv";
            this.txtDgv.Size = new System.Drawing.Size(139, 16);
            this.txtDgv.TabIndex = 6;
            this.txtDgv.Text = "Lista de productos:";
            // 
            // ListProducTable
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
            // btnFacturar
            // 
            this.btnFacturar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFacturar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnFacturar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturar.ForeColor = System.Drawing.Color.White;
            this.btnFacturar.Location = new System.Drawing.Point(468, 369);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(128, 30);
            this.btnFacturar.TabIndex = 15;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = false;
            // 
            // dataGridViewImageColumn1
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
            this.txtTituloTotal.Location = new System.Drawing.Point(8, 10);
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
            this.txtTotal.Location = new System.Drawing.Point(68, 10);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(19, 20);
            this.txtTotal.TabIndex = 21;
            this.txtTotal.Text = "0";
            this.txtTotal.Click += new System.EventHandler(this.txtTotal_Click);
            // 
            // groupBoxSubtotal
            // 
            this.groupBoxSubtotal.Controls.Add(this.txtTituloSubTotal);
            this.groupBoxSubtotal.Controls.Add(this.txtSubTotal);
            this.groupBoxSubtotal.Location = new System.Drawing.Point(12, 369);
            this.groupBoxSubtotal.Name = "groupBoxSubtotal";
            this.groupBoxSubtotal.Size = new System.Drawing.Size(210, 37);
            this.groupBoxSubtotal.TabIndex = 22;
            this.groupBoxSubtotal.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTituloTotal);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Location = new System.Drawing.Point(270, 369);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 37);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
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
            // Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 411);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxSubtotal);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.ListProducTable);
            this.Controls.Add(this.txtDgv);
            this.Controls.Add(this.ProductBox);
            this.Controls.Add(this.ClientBox);
            this.Name = "Facturacion";
            this.Text = "Facturacion";
            this.Load += new System.EventHandler(this.Facturacion_Load);
            this.ClientBox.ResumeLayout(false);
            this.ProductBox.ResumeLayout(false);
            this.ProductBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListProducTable)).EndInit();
            this.groupBoxSubtotal.ResumeLayout(false);
            this.groupBoxSubtotal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox ClientBox;
        private System.Windows.Forms.ComboBox ClientBox1;
        private System.Windows.Forms.GroupBox ProductBox;
        private System.Windows.Forms.ComboBox ProductBox2;
        private System.Windows.Forms.TextBox CantidadBox;
        private System.Windows.Forms.Label txtCantidad;
        private System.Windows.Forms.Label txtDgv;
        private System.Windows.Forms.DataGridView ListProducTable;
        private System.Windows.Forms.Button btnAñadirClient;
        private System.Windows.Forms.Button btnAgregarAlCarrito;
        private System.Windows.Forms.Button bntAñadirProduct;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label txtTituloSubTotal;
        private System.Windows.Forms.Label txtTituloTotal;
        private System.Windows.Forms.Label txtSubTotal;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.GroupBox groupBoxSubtotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}