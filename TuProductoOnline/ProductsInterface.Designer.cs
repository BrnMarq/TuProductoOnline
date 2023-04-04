
namespace TuProductoOnline
{
    partial class ProductsInterface
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridProducts = new System.Windows.Forms.DataGridView();
            this.GridCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // GridProducts
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.GridProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GridCode,
            this.GridType,
            this.GridName,
            this.GridModel,
            this.GridDescription,
            this.GridPrice});
            this.GridProducts.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridProducts.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridProducts.EnableHeadersVisualStyles = false;
            this.GridProducts.Location = new System.Drawing.Point(23, 12);
            this.GridProducts.Name = "GridProducts";
            this.GridProducts.RowHeadersVisible = false;
            this.GridProducts.Size = new System.Drawing.Size(565, 58);
            this.GridProducts.TabIndex = 1;
            // 
            // GridCode
            // 
            this.GridCode.HeaderText = "Código";
            this.GridCode.Name = "GridCode";
            this.GridCode.ReadOnly = true;
            this.GridCode.Width = 60;
            // 
            // GridType
            // 
            this.GridType.HeaderText = "Tipo";
            this.GridType.Name = "GridType";
            this.GridType.ReadOnly = true;
            // 
            // GridName
            // 
            this.GridName.HeaderText = "Nombre";
            this.GridName.Name = "GridName";
            this.GridName.ReadOnly = true;
            // 
            // GridModel
            // 
            this.GridModel.HeaderText = "Modelo";
            this.GridModel.Name = "GridModel";
            this.GridModel.ReadOnly = true;
            // 
            // GridDescription
            // 
            this.GridDescription.HeaderText = "Descripción";
            this.GridDescription.Name = "GridDescription";
            this.GridDescription.ReadOnly = true;
            this.GridDescription.Width = 150;
            // 
            // GridPrice
            // 
            this.GridPrice.HeaderText = "Precio";
            this.GridPrice.Name = "GridPrice";
            this.GridPrice.ReadOnly = true;
            this.GridPrice.Width = 55;
            // 
            // ProductsInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 413);
            this.Controls.Add(this.GridProducts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProductsInterface";
            this.Text = "ProductsInterface";
            ((System.ComponentModel.ISupportInitialize)(this.GridProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView GridProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridType;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridPrice;
    }
}