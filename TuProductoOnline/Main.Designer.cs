namespace TuProductoOnline
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panel1 = new System.Windows.Forms.Panel();
            this.CustomersTab = new System.Windows.Forms.Button();
            this.BillingTab = new System.Windows.Forms.Button();
            this.UsersTab = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ProductsTab = new System.Windows.Forms.Button();
            this.CompanyName = new System.Windows.Forms.Label();
            this.CompanyLogo = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Container = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.panel1.Controls.Add(this.CustomersTab);
            this.panel1.Controls.Add(this.BillingTab);
            this.panel1.Controls.Add(this.UsersTab);
            this.panel1.Controls.Add(this.ExitButton);
            this.panel1.Controls.Add(this.ProductsTab);
            this.panel1.Controls.Add(this.CompanyName);
            this.panel1.Controls.Add(this.CompanyLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 450);
            this.panel1.TabIndex = 0;
            // 
            // CustomersTab
            // 
            this.CustomersTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.CustomersTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CustomersTab.FlatAppearance.BorderSize = 0;
            this.CustomersTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CustomersTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomersTab.ForeColor = System.Drawing.Color.White;
            this.CustomersTab.Image = global::TuProductoOnline.Properties.Resources.ClientsIcon;
            this.CustomersTab.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CustomersTab.Location = new System.Drawing.Point(3, 161);
            this.CustomersTab.Name = "CustomersTab";
            this.CustomersTab.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.CustomersTab.Size = new System.Drawing.Size(167, 36);
            this.CustomersTab.TabIndex = 6;
            this.CustomersTab.Text = "   Clientes";
            this.CustomersTab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CustomersTab.UseVisualStyleBackColor = false;
            this.CustomersTab.Click += new System.EventHandler(this.CustomersTab_Click);
            // 
            // BillingTab
            // 
            this.BillingTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BillingTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BillingTab.FlatAppearance.BorderSize = 0;
            this.BillingTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BillingTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillingTab.ForeColor = System.Drawing.Color.White;
            this.BillingTab.Image = global::TuProductoOnline.Properties.Resources.BillingIcon;
            this.BillingTab.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BillingTab.Location = new System.Drawing.Point(0, 245);
            this.BillingTab.Name = "BillingTab";
            this.BillingTab.Size = new System.Drawing.Size(170, 36);
            this.BillingTab.TabIndex = 5;
            this.BillingTab.Text = "   Facturación";
            this.BillingTab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BillingTab.UseVisualStyleBackColor = false;
            // 
            // UsersTab
            // 
            this.UsersTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.UsersTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.UsersTab.FlatAppearance.BorderSize = 0;
            this.UsersTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UsersTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsersTab.ForeColor = System.Drawing.Color.White;
            this.UsersTab.Image = global::TuProductoOnline.Properties.Resources.UsersIcon;
            this.UsersTab.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.UsersTab.Location = new System.Drawing.Point(0, 203);
            this.UsersTab.Name = "UsersTab";
            this.UsersTab.Padding = new System.Windows.Forms.Padding(0, 0, 25, 0);
            this.UsersTab.Size = new System.Drawing.Size(170, 36);
            this.UsersTab.TabIndex = 4;
            this.UsersTab.Text = "   Usuarios";
            this.UsersTab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.UsersTab.UseVisualStyleBackColor = false;
            this.UsersTab.Click += new System.EventHandler(this.UsersTab_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.ExitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ExitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitButton.FlatAppearance.BorderSize = 0;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitButton.Location = new System.Drawing.Point(46, 402);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(63, 36);
            this.ExitButton.TabIndex = 3;
            this.ExitButton.Text = "Salir";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ProductsTab
            // 
            this.ProductsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.ProductsTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ProductsTab.FlatAppearance.BorderSize = 0;
            this.ProductsTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ProductsTab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductsTab.ForeColor = System.Drawing.Color.White;
            this.ProductsTab.Image = ((System.Drawing.Image)(resources.GetObject("ProductsTab.Image")));
            this.ProductsTab.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ProductsTab.Location = new System.Drawing.Point(0, 119);
            this.ProductsTab.Name = "ProductsTab";
            this.ProductsTab.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.ProductsTab.Size = new System.Drawing.Size(170, 36);
            this.ProductsTab.TabIndex = 1;
            this.ProductsTab.Text = "   Productos";
            this.ProductsTab.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ProductsTab.UseVisualStyleBackColor = false;
            this.ProductsTab.Click += new System.EventHandler(this.ProductsTab_Click);
            // 
            // CompanyName
            // 
            this.CompanyName.AutoSize = true;
            this.CompanyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompanyName.ForeColor = System.Drawing.Color.White;
            this.CompanyName.Location = new System.Drawing.Point(5, 85);
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.Size = new System.Drawing.Size(162, 20);
            this.CompanyName.TabIndex = 2;
            this.CompanyName.Text = "Tu Producto Online";
            // 
            // CompanyLogo
            // 
            this.CompanyLogo.Image = global::TuProductoOnline.Properties.Resources.TuProductoOnlineLogo;
            this.CompanyLogo.Location = new System.Drawing.Point(46, 7);
            this.CompanyLogo.Name = "CompanyLogo";
            this.CompanyLogo.Size = new System.Drawing.Size(75, 75);
            this.CompanyLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.CompanyLogo.TabIndex = 1;
            this.CompanyLogo.TabStop = false;
            // 
            // Container
            // 
            this.Container.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Container.Location = new System.Drawing.Point(170, 0);
            this.Container.Name = "Container";
            this.Container.Size = new System.Drawing.Size(630, 450);
            this.Container.TabIndex = 7;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Container);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Main";
            this.Text = "TuProductoOnline";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label CompanyName;
        private System.Windows.Forms.PictureBox CompanyLogo;
        private System.Windows.Forms.Button ProductsTab;
        private System.Windows.Forms.Button CustomersTab;
        private System.Windows.Forms.Button BillingTab;
        private System.Windows.Forms.Button UsersTab;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Panel Container;
    }
}