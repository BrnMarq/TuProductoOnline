
namespace TuProductoOnline
{
    partial class Add
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
            this.txtId = new System.Windows.Forms.TextBox();
            this.TitleProduct = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.TxtNameErrorlbl = new System.Windows.Forms.Label();
            this.TxtBrandErrorlbl = new System.Windows.Forms.Label();
            this.TxtDescriptionErrorlbl = new System.Windows.Forms.Label();
            this.TxtPriceErrorlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.BackColor = System.Drawing.SystemColors.Window;
            this.txtId.Location = new System.Drawing.Point(32, 81);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(334, 20);
            this.txtId.TabIndex = 6;
            // 
            // TitleProduct
            // 
            this.TitleProduct.AutoSize = true;
            this.TitleProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TitleProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.TitleProduct.Location = new System.Drawing.Point(101, 10);
            this.TitleProduct.Name = "TitleProduct";
            this.TitleProduct.Size = new System.Drawing.Size(218, 29);
            this.TitleProduct.TabIndex = 6;
            this.TitleProduct.Text = "Agregar Producto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.label2.Location = new System.Drawing.Point(27, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Codigo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.label3.Location = new System.Drawing.Point(27, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Window;
            this.txtName.Location = new System.Drawing.Point(32, 229);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(334, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.label4.Location = new System.Drawing.Point(27, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nombre";
            // 
            // txtBrand
            // 
            this.txtBrand.BackColor = System.Drawing.SystemColors.Window;
            this.txtBrand.Location = new System.Drawing.Point(32, 303);
            this.txtBrand.MaxLength = 100;
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(334, 20);
            this.txtBrand.TabIndex = 2;
            this.txtBrand.TextChanged += new System.EventHandler(this.txtBrand_TextChanged);
            this.txtBrand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBrand_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.label5.Location = new System.Drawing.Point(27, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Marca";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.SystemColors.Window;
            this.txtDescription.Location = new System.Drawing.Point(32, 377);
            this.txtDescription.MaxLength = 250;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(334, 20);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtDescription_TextChanged);
            this.txtDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescription_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.label6.Location = new System.Drawing.Point(27, 350);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Descripcion";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrice.Location = new System.Drawing.Point(32, 451);
            this.txtPrice.MaxLength = 50;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ShortcutsEnabled = false;
            this.txtPrice.Size = new System.Drawing.Size(334, 20);
            this.txtPrice.TabIndex = 4;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.label7.Location = new System.Drawing.Point(27, 424);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Precio";
            // 
            // cmbType
            // 
            this.cmbType.BackColor = System.Drawing.SystemColors.Window;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Hardware",
            "Software",
            "Devices"});
            this.cmbType.Location = new System.Drawing.Point(32, 155);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(334, 21);
            this.cmbType.TabIndex = 0;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            this.cmbType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbType_KeyPress);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Enabled = false;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(117)))), ((int)(((byte)(214)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(143, 506);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 33);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click_1);
            // 
            // TxtNameErrorlbl
            // 
            this.TxtNameErrorlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNameErrorlbl.AutoSize = true;
            this.TxtNameErrorlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNameErrorlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TxtNameErrorlbl.Location = new System.Drawing.Point(32, 259);
            this.TxtNameErrorlbl.Name = "TxtNameErrorlbl";
            this.TxtNameErrorlbl.Size = new System.Drawing.Size(269, 16);
            this.TxtNameErrorlbl.TabIndex = 19;
            this.TxtNameErrorlbl.Text = "Ingrese el Nombre (Maximo 100 Carácteres)";
            this.TxtNameErrorlbl.Visible = false;
            // 
            // TxtBrandErrorlbl
            // 
            this.TxtBrandErrorlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBrandErrorlbl.AutoSize = true;
            this.TxtBrandErrorlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBrandErrorlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TxtBrandErrorlbl.Location = new System.Drawing.Point(32, 333);
            this.TxtBrandErrorlbl.Name = "TxtBrandErrorlbl";
            this.TxtBrandErrorlbl.Size = new System.Drawing.Size(258, 16);
            this.TxtBrandErrorlbl.TabIndex = 21;
            this.TxtBrandErrorlbl.Text = "Ingrese la Marca (Maximo 100 Carácteres)";
            this.TxtBrandErrorlbl.Visible = false;
            // 
            // TxtDescriptionErrorlbl
            // 
            this.TxtDescriptionErrorlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDescriptionErrorlbl.AutoSize = true;
            this.TxtDescriptionErrorlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDescriptionErrorlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TxtDescriptionErrorlbl.Location = new System.Drawing.Point(32, 407);
            this.TxtDescriptionErrorlbl.Name = "TxtDescriptionErrorlbl";
            this.TxtDescriptionErrorlbl.Size = new System.Drawing.Size(292, 16);
            this.TxtDescriptionErrorlbl.TabIndex = 23;
            this.TxtDescriptionErrorlbl.Text = "Ingrese la Descripcion (Maximo 250 Carácteres)";
            this.TxtDescriptionErrorlbl.Visible = false;
            // 
            // TxtPriceErrorlbl
            // 
            this.TxtPriceErrorlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPriceErrorlbl.AutoSize = true;
            this.TxtPriceErrorlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPriceErrorlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TxtPriceErrorlbl.Location = new System.Drawing.Point(32, 481);
            this.TxtPriceErrorlbl.Name = "TxtPriceErrorlbl";
            this.TxtPriceErrorlbl.Size = new System.Drawing.Size(252, 16);
            this.TxtPriceErrorlbl.TabIndex = 24;
            this.TxtPriceErrorlbl.Text = "Ingrese el Precio (Maximo 50 Carácteres)";
            this.TxtPriceErrorlbl.Visible = false;
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(412, 568);
            this.Controls.Add(this.TxtPriceErrorlbl);
            this.Controls.Add(this.TxtDescriptionErrorlbl);
            this.Controls.Add(this.TxtBrandErrorlbl);
            this.Controls.Add(this.TxtNameErrorlbl);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TitleProduct);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label TitleProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label TxtNameErrorlbl;
        private System.Windows.Forms.Label TxtBrandErrorlbl;
        private System.Windows.Forms.Label TxtDescriptionErrorlbl;
        private System.Windows.Forms.Label TxtPriceErrorlbl;
    }
}