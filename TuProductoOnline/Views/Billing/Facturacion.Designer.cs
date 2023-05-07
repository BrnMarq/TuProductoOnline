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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ClientBox = new System.Windows.Forms.GroupBox();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.btnAñadirClient = new System.Windows.Forms.Button();
            this.ProductBox = new System.Windows.Forms.GroupBox();
            this.ProductBox2 = new System.Windows.Forms.TextBox();
            this.btnAgregarAlCarrito = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.Label();
            this.CantidadBox = new System.Windows.Forms.TextBox();
            this.txtDgv = new System.Windows.Forms.Label();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtTituloSubTotal = new System.Windows.Forms.Label();
            this.txtTituloTotal = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.Label();
            this.groupBoxSubtotal = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProducTable = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeleteCell = new System.Windows.Forms.DataGridViewImageColumn();
            this.DivisaGroup = new System.Windows.Forms.GroupBox();
            this.AlCambio = new System.Windows.Forms.Label();
            this.TituloAlCambio = new System.Windows.Forms.Label();
            this.DivisasBox = new System.Windows.Forms.ComboBox();
            this.RefreshAPIButton = new System.Windows.Forms.Button();
            this.Statuslbl = new System.Windows.Forms.Label();
            this.APIstatus = new System.Windows.Forms.Label();
            this.ClientBox.SuspendLayout();
            this.ProductBox.SuspendLayout();
            this.groupBoxSubtotal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProducTable)).BeginInit();
            this.DivisaGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientBox
            // 
            this.ClientBox.Controls.Add(this.TextBox);
            this.ClientBox.Controls.Add(this.btnAñadirClient);
            this.ClientBox.Location = new System.Drawing.Point(12, 14);
            this.ClientBox.Name = "ClientBox";
            this.ClientBox.Size = new System.Drawing.Size(184, 80);
            this.ClientBox.TabIndex = 3;
            this.ClientBox.TabStop = false;
            this.ClientBox.Text = "Cliente";
            // 
            // TextBox
            // 
            this.TextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.TextBox.Location = new System.Drawing.Point(6, 43);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(165, 20);
            this.TextBox.TabIndex = 15;
            // 
            // btnAñadirClient
            // 
            this.btnAñadirClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAñadirClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAñadirClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAñadirClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAñadirClient.ForeColor = System.Drawing.Color.White;
            this.btnAñadirClient.Location = new System.Drawing.Point(6, 16);
            this.btnAñadirClient.Name = "btnAñadirClient";
            this.btnAñadirClient.Size = new System.Drawing.Size(165, 23);
            this.btnAñadirClient.TabIndex = 14;
            this.btnAñadirClient.Text = "Añadir Nuevo Cliente";
            this.btnAñadirClient.UseVisualStyleBackColor = false;
            this.btnAñadirClient.Click += new System.EventHandler(this.btnAñadirClient_Click);
            // 
            // ProductBox
            // 
            this.ProductBox.Controls.Add(this.ProductBox2);
            this.ProductBox.Controls.Add(this.btnAgregarAlCarrito);
            this.ProductBox.Controls.Add(this.txtCantidad);
            this.ProductBox.Controls.Add(this.CantidadBox);
            this.ProductBox.Location = new System.Drawing.Point(202, 14);
            this.ProductBox.Name = "ProductBox";
            this.ProductBox.Size = new System.Drawing.Size(245, 80);
            this.ProductBox.TabIndex = 4;
            this.ProductBox.TabStop = false;
            this.ProductBox.Text = "Producto";
            // 
            // ProductBox2
            // 
            this.ProductBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ProductBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.ProductBox2.Location = new System.Drawing.Point(0, 16);
            this.ProductBox2.Name = "ProductBox2";
            this.ProductBox2.Size = new System.Drawing.Size(133, 20);
            this.ProductBox2.TabIndex = 17;
            // 
            // btnAgregarAlCarrito
            // 
            this.btnAgregarAlCarrito.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregarAlCarrito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAgregarAlCarrito.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarAlCarrito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarAlCarrito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarAlCarrito.ForeColor = System.Drawing.Color.White;
            this.btnAgregarAlCarrito.Location = new System.Drawing.Point(67, 42);
            this.btnAgregarAlCarrito.Name = "btnAgregarAlCarrito";
            this.btnAgregarAlCarrito.Size = new System.Drawing.Size(172, 23);
            this.btnAgregarAlCarrito.TabIndex = 16;
            this.btnAgregarAlCarrito.Text = "Agregar Producto Al Carrito";
            this.btnAgregarAlCarrito.UseVisualStyleBackColor = false;
            this.btnAgregarAlCarrito.Click += new System.EventHandler(this.btnAgregarAlCarrito_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.AutoSize = true;
            this.txtCantidad.Location = new System.Drawing.Point(164, 0);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(52, 13);
            this.txtCantidad.TabIndex = 6;
            this.txtCantidad.Text = "Cantidad:";
            // 
            // CantidadBox
            // 
            this.CantidadBox.Location = new System.Drawing.Point(139, 16);
            this.CantidadBox.MaxLength = 8;
            this.CantidadBox.Name = "CantidadBox";
            this.CantidadBox.Size = new System.Drawing.Size(100, 20);
            this.CantidadBox.TabIndex = 3;
            this.CantidadBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CantidadBox_KeyPress);
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
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click_1);
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
            this.txtTituloSubTotal.BackColor = System.Drawing.Color.White;
            this.txtTituloSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTituloSubTotal.ForeColor = System.Drawing.Color.Black;
            this.txtTituloSubTotal.Location = new System.Drawing.Point(3, 10);
            this.txtTituloSubTotal.Name = "txtTituloSubTotal";
            this.txtTituloSubTotal.Size = new System.Drawing.Size(82, 20);
            this.txtTituloSubTotal.TabIndex = 18;
            this.txtTituloSubTotal.Text = "Subtotal:";
            // 
            // txtTituloTotal
            // 
            this.txtTituloTotal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtTituloTotal.AutoSize = true;
            this.txtTituloTotal.BackColor = System.Drawing.Color.White;
            this.txtTituloTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTituloTotal.ForeColor = System.Drawing.Color.Black;
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
            this.txtSubTotal.Location = new System.Drawing.Point(95, 10);
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
            // 
            // groupBoxSubtotal
            // 
            this.groupBoxSubtotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxSubtotal.Controls.Add(this.txtTituloSubTotal);
            this.groupBoxSubtotal.Controls.Add(this.txtSubTotal);
            this.groupBoxSubtotal.Location = new System.Drawing.Point(12, 369);
            this.groupBoxSubtotal.Name = "groupBoxSubtotal";
            this.groupBoxSubtotal.Size = new System.Drawing.Size(224, 37);
            this.groupBoxSubtotal.TabIndex = 22;
            this.groupBoxSubtotal.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.txtTituloTotal);
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Location = new System.Drawing.Point(257, 369);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 37);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // ProducTable
            // 
            this.ProducTable.AllowUserToAddRows = false;
            this.ProducTable.AllowUserToDeleteRows = false;
            this.ProducTable.AllowUserToResizeColumns = false;
            this.ProducTable.AllowUserToResizeRows = false;
            this.ProducTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProducTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProducTable.BackgroundColor = System.Drawing.Color.White;
            this.ProducTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProducTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.NullValue = "System.Drawing.Bitmap";
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProducTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.ProducTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProducTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.name,
            this.Precio,
            this.Cantidad,
            this.DeleteCell});
            this.ProducTable.EnableHeadersVisualStyles = false;
            this.ProducTable.Location = new System.Drawing.Point(12, 118);
            this.ProducTable.MultiSelect = false;
            this.ProducTable.Name = "ProducTable";
            this.ProducTable.ReadOnly = true;
            this.ProducTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProducTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.ProducTable.RowHeadersVisible = false;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.White;
            this.ProducTable.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.ProducTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProducTable.Size = new System.Drawing.Size(584, 236);
            this.ProducTable.TabIndex = 23;
            this.ProducTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProducTable_CellClick);
            // 
            // ID
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ID.DefaultCellStyle = dataGridViewCellStyle12;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // name
            // 
            this.name.HeaderText = "Nombre";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Precio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Cantidad.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DeleteCell
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.NullValue = "-1";
            this.DeleteCell.DefaultCellStyle = dataGridViewCellStyle13;
            this.DeleteCell.HeaderText = "Eliminar";
            this.DeleteCell.Image = global::TuProductoOnline.Properties.Resources.deleteIcon1;
            this.DeleteCell.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.DeleteCell.Name = "DeleteCell";
            this.DeleteCell.ReadOnly = true;
            this.DeleteCell.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DivisaGroup
            // 
            this.DivisaGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DivisaGroup.Controls.Add(this.APIstatus);
            this.DivisaGroup.Controls.Add(this.Statuslbl);
            this.DivisaGroup.Controls.Add(this.RefreshAPIButton);
            this.DivisaGroup.Controls.Add(this.AlCambio);
            this.DivisaGroup.Controls.Add(this.TituloAlCambio);
            this.DivisaGroup.Controls.Add(this.DivisasBox);
            this.DivisaGroup.Location = new System.Drawing.Point(453, 14);
            this.DivisaGroup.Name = "DivisaGroup";
            this.DivisaGroup.Size = new System.Drawing.Size(149, 90);
            this.DivisaGroup.TabIndex = 24;
            this.DivisaGroup.TabStop = false;
            this.DivisaGroup.Text = "Tipo de Divisa";
            // 
            // AlCambio
            // 
            this.AlCambio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.AlCambio.AutoSize = true;
            this.AlCambio.Location = new System.Drawing.Point(60, 53);
            this.AlCambio.Name = "AlCambio";
            this.AlCambio.Size = new System.Drawing.Size(13, 13);
            this.AlCambio.TabIndex = 2;
            this.AlCambio.Text = "1";
            this.AlCambio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TituloAlCambio
            // 
            this.TituloAlCambio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TituloAlCambio.AutoSize = true;
            this.TituloAlCambio.Location = new System.Drawing.Point(-3, 53);
            this.TituloAlCambio.Name = "TituloAlCambio";
            this.TituloAlCambio.Size = new System.Drawing.Size(57, 13);
            this.TituloAlCambio.TabIndex = 1;
            this.TituloAlCambio.Text = "Al Cambio:";
            // 
            // DivisasBox
            // 
            this.DivisasBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DivisasBox.FormattingEnabled = true;
            this.DivisasBox.Location = new System.Drawing.Point(6, 18);
            this.DivisasBox.Name = "DivisasBox";
            this.DivisasBox.Size = new System.Drawing.Size(70, 21);
            this.DivisasBox.TabIndex = 0;
            this.DivisasBox.SelectedIndexChanged += new System.EventHandler(this.DivisasBox_SelectedIndexChanged);
            // 
            // RefreshAPIButton
            // 
            this.RefreshAPIButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.RefreshAPIButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RefreshAPIButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshAPIButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RefreshAPIButton.ForeColor = System.Drawing.Color.White;
            this.RefreshAPIButton.Location = new System.Drawing.Point(82, 16);
            this.RefreshAPIButton.Name = "RefreshAPIButton";
            this.RefreshAPIButton.Size = new System.Drawing.Size(61, 23);
            this.RefreshAPIButton.TabIndex = 15;
            this.RefreshAPIButton.Text = "Update";
            this.RefreshAPIButton.UseVisualStyleBackColor = false;
            this.RefreshAPIButton.Click += new System.EventHandler(this.RefreshAPIButton_Click);
            // 
            // Statuslbl
            // 
            this.Statuslbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Statuslbl.AutoSize = true;
            this.Statuslbl.Location = new System.Drawing.Point(-3, 74);
            this.Statuslbl.Name = "Statuslbl";
            this.Statuslbl.Size = new System.Drawing.Size(27, 13);
            this.Statuslbl.TabIndex = 16;
            this.Statuslbl.Text = "API:";
            // 
            // APIstatus
            // 
            this.APIstatus.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.APIstatus.AutoSize = true;
            this.APIstatus.Location = new System.Drawing.Point(21, 74);
            this.APIstatus.Name = "APIstatus";
            this.APIstatus.Size = new System.Drawing.Size(77, 13);
            this.APIstatus.TabIndex = 17;
            this.APIstatus.Text = "Desconectado";
            this.APIstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(614, 411);
            this.Controls.Add(this.DivisaGroup);
            this.Controls.Add(this.ProducTable);
            this.Controls.Add(this.ProductBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxSubtotal);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.txtDgv);
            this.Controls.Add(this.ClientBox);
            this.Name = "Facturacion";
            this.Text = "Facturacion";
            this.ClientBox.ResumeLayout(false);
            this.ClientBox.PerformLayout();
            this.ProductBox.ResumeLayout(false);
            this.ProductBox.PerformLayout();
            this.groupBoxSubtotal.ResumeLayout(false);
            this.groupBoxSubtotal.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProducTable)).EndInit();
            this.DivisaGroup.ResumeLayout(false);
            this.DivisaGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox ClientBox;
        private System.Windows.Forms.GroupBox ProductBox;
        private System.Windows.Forms.TextBox CantidadBox;
        private System.Windows.Forms.Label txtCantidad;
        private System.Windows.Forms.Label txtDgv;
        private System.Windows.Forms.Button btnAñadirClient;
        private System.Windows.Forms.Button btnAgregarAlCarrito;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.Label txtTituloSubTotal;
        private System.Windows.Forms.Label txtTituloTotal;
        private System.Windows.Forms.Label txtSubTotal;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.GroupBox groupBoxSubtotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView ProducTable;
        private System.Windows.Forms.GroupBox DivisaGroup;
        private System.Windows.Forms.ComboBox DivisasBox;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Label TituloAlCambio;
        private System.Windows.Forms.Label AlCambio;
        private System.Windows.Forms.TextBox ProductBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewImageColumn DeleteCell;
        private System.Windows.Forms.Button RefreshAPIButton;
        private System.Windows.Forms.Label APIstatus;
        private System.Windows.Forms.Label Statuslbl;
    }
}