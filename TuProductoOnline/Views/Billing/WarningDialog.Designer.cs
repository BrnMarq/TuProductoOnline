namespace TuProductoOnline
{
    partial class WarningDialog
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
            this.bntAñadirProduct = new System.Windows.Forms.Button();
            this.txtTitulo = new System.Windows.Forms.Label();
            this.mensajeBox = new System.Windows.Forms.GroupBox();
            this.txtbox = new System.Windows.Forms.GroupBox();
            this.txtAdvertencia = new System.Windows.Forms.Label();
            this.mensajeBox.SuspendLayout();
            this.txtbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // bntAñadirProduct
            // 
            this.bntAñadirProduct.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bntAñadirProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.bntAñadirProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bntAñadirProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntAñadirProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntAñadirProduct.ForeColor = System.Drawing.Color.White;
            this.bntAñadirProduct.Location = new System.Drawing.Point(191, 140);
            this.bntAñadirProduct.Name = "bntAñadirProduct";
            this.bntAñadirProduct.Size = new System.Drawing.Size(83, 33);
            this.bntAñadirProduct.TabIndex = 16;
            this.bntAñadirProduct.Text = "Ok";
            this.bntAñadirProduct.UseVisualStyleBackColor = false;
            this.bntAñadirProduct.Click += new System.EventHandler(this.bntAñadirProduct_Click);
            // 
            // txtTitulo
            // 
            this.txtTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTitulo.AutoSize = true;
            this.txtTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitulo.Location = new System.Drawing.Point(204, 16);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(57, 20);
            this.txtTitulo.TabIndex = 17;
            this.txtTitulo.Text = "Aviso:";
            // 
            // mensajeBox
            // 
            this.mensajeBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mensajeBox.Controls.Add(this.txtbox);
            this.mensajeBox.Controls.Add(this.bntAñadirProduct);
            this.mensajeBox.Controls.Add(this.txtTitulo);
            this.mensajeBox.Location = new System.Drawing.Point(12, 12);
            this.mensajeBox.Name = "mensajeBox";
            this.mensajeBox.Size = new System.Drawing.Size(461, 179);
            this.mensajeBox.TabIndex = 19;
            this.mensajeBox.TabStop = false;
            // 
            // txtbox
            // 
            this.txtbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbox.Controls.Add(this.txtAdvertencia);
            this.txtbox.Location = new System.Drawing.Point(6, 39);
            this.txtbox.Name = "txtbox";
            this.txtbox.Size = new System.Drawing.Size(449, 80);
            this.txtbox.TabIndex = 19;
            this.txtbox.TabStop = false;
            // 
            // txtAdvertencia
            // 
            this.txtAdvertencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdvertencia.AutoSize = true;
            this.txtAdvertencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdvertencia.Location = new System.Drawing.Point(103, 28);
            this.txtAdvertencia.Name = "txtAdvertencia";
            this.txtAdvertencia.Size = new System.Drawing.Size(124, 20);
            this.txtAdvertencia.TabIndex = 19;
            this.txtAdvertencia.Text = "txtAdvertencia";
            this.txtAdvertencia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtAdvertencia.Click += new System.EventHandler(this.label1_Click);
            // 
            // WarningDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 203);
            this.Controls.Add(this.mensajeBox);
            this.Name = "WarningDialog";
            this.Text = "WarningDialog";
            this.Load += new System.EventHandler(this.WarningDialog_Load);
            this.mensajeBox.ResumeLayout(false);
            this.mensajeBox.PerformLayout();
            this.txtbox.ResumeLayout(false);
            this.txtbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bntAñadirProduct;
        private System.Windows.Forms.Label txtTitulo;
        private System.Windows.Forms.GroupBox mensajeBox;
        private System.Windows.Forms.GroupBox txtbox;
        private System.Windows.Forms.Label txtAdvertencia;
    }
}