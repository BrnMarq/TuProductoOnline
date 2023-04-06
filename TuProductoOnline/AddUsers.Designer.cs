namespace TuProductoOnline
{
    partial class AddUsers
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
            this.AddressInput = new System.Windows.Forms.TextBox();
            this.PhoneNumberInput = new System.Windows.Forms.TextBox();
            this.LastNameInput = new System.Windows.Forms.TextBox();
            this.NameInput = new System.Windows.Forms.TextBox();
            this.Addresslbl = new System.Windows.Forms.Label();
            this.Phonenumberlbl = new System.Windows.Forms.Label();
            this.Lastnamelbl = new System.Windows.Forms.Label();
            this.Namelbl = new System.Windows.Forms.Label();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.Passwordlbl = new System.Windows.Forms.Label();
            this.Accessbutton = new System.Windows.Forms.Button();
            this.EmailInput = new System.Windows.Forms.TextBox();
            this.Emaillbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AddressInput
            // 
            this.AddressInput.AllowDrop = true;
            this.AddressInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddressInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressInput.Location = new System.Drawing.Point(136, 220);
            this.AddressInput.Multiline = true;
            this.AddressInput.Name = "AddressInput";
            this.AddressInput.Size = new System.Drawing.Size(232, 25);
            this.AddressInput.TabIndex = 27;
            this.AddressInput.TextChanged += new System.EventHandler(this.AddressInput_TextChanged);
            this.AddressInput.Enter += new System.EventHandler(this.AddressInput_Enter);
            this.AddressInput.Leave += new System.EventHandler(this.AddressInput_Leave);
            // 
            // PhoneNumberInput
            // 
            this.PhoneNumberInput.AllowDrop = true;
            this.PhoneNumberInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PhoneNumberInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PhoneNumberInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneNumberInput.Location = new System.Drawing.Point(136, 170);
            this.PhoneNumberInput.Multiline = true;
            this.PhoneNumberInput.Name = "PhoneNumberInput";
            this.PhoneNumberInput.Size = new System.Drawing.Size(232, 25);
            this.PhoneNumberInput.TabIndex = 26;
            this.PhoneNumberInput.TextChanged += new System.EventHandler(this.PhoneNumberInput_TextChanged);
            this.PhoneNumberInput.Enter += new System.EventHandler(this.PhoneNumberInput_Enter);
            this.PhoneNumberInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PhoneNumberInput_KeyPress);
            this.PhoneNumberInput.Leave += new System.EventHandler(this.PhoneNumberInput_Leave);
            // 
            // LastNameInput
            // 
            this.LastNameInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LastNameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LastNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastNameInput.Location = new System.Drawing.Point(136, 70);
            this.LastNameInput.Multiline = true;
            this.LastNameInput.Name = "LastNameInput";
            this.LastNameInput.Size = new System.Drawing.Size(232, 25);
            this.LastNameInput.TabIndex = 24;
            this.LastNameInput.TextChanged += new System.EventHandler(this.LastNameInput_TextChanged);
            this.LastNameInput.Enter += new System.EventHandler(this.LastNameInput_Enter);
            this.LastNameInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LastNameInput_KeyPress);
            this.LastNameInput.Leave += new System.EventHandler(this.LastNameInput_Leave);
            // 
            // NameInput
            // 
            this.NameInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NameInput.BackColor = System.Drawing.Color.White;
            this.NameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameInput.Location = new System.Drawing.Point(136, 20);
            this.NameInput.Multiline = true;
            this.NameInput.Name = "NameInput";
            this.NameInput.Size = new System.Drawing.Size(232, 25);
            this.NameInput.TabIndex = 23;
            this.NameInput.TextChanged += new System.EventHandler(this.NameInput_TextChanged);
            this.NameInput.Enter += new System.EventHandler(this.NameInput_Enter);
            this.NameInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NameInput_KeyPress);
            this.NameInput.Leave += new System.EventHandler(this.NameInput_Leave);
            // 
            // Addresslbl
            // 
            this.Addresslbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Addresslbl.AutoSize = true;
            this.Addresslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Addresslbl.Location = new System.Drawing.Point(30, 223);
            this.Addresslbl.Name = "Addresslbl";
            this.Addresslbl.Size = new System.Drawing.Size(84, 20);
            this.Addresslbl.TabIndex = 21;
            this.Addresslbl.Text = "Dirección";
            // 
            // Phonenumberlbl
            // 
            this.Phonenumberlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Phonenumberlbl.AutoSize = true;
            this.Phonenumberlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Phonenumberlbl.Location = new System.Drawing.Point(30, 173);
            this.Phonenumberlbl.Name = "Phonenumberlbl";
            this.Phonenumberlbl.Size = new System.Drawing.Size(79, 20);
            this.Phonenumberlbl.TabIndex = 20;
            this.Phonenumberlbl.Text = "Teléfono";
            // 
            // Lastnamelbl
            // 
            this.Lastnamelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Lastnamelbl.AutoSize = true;
            this.Lastnamelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lastnamelbl.Location = new System.Drawing.Point(30, 73);
            this.Lastnamelbl.Name = "Lastnamelbl";
            this.Lastnamelbl.Size = new System.Drawing.Size(73, 20);
            this.Lastnamelbl.TabIndex = 18;
            this.Lastnamelbl.Text = "Apellido";
            // 
            // Namelbl
            // 
            this.Namelbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Namelbl.AutoSize = true;
            this.Namelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Namelbl.Location = new System.Drawing.Point(30, 23);
            this.Namelbl.Name = "Namelbl";
            this.Namelbl.Size = new System.Drawing.Size(71, 20);
            this.Namelbl.TabIndex = 17;
            this.Namelbl.Text = "Nombre";
            // 
            // PasswordInput
            // 
            this.PasswordInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordInput.Location = new System.Drawing.Point(136, 270);
            this.PasswordInput.Multiline = true;
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(232, 25);
            this.PasswordInput.TabIndex = 32;
            this.PasswordInput.UseSystemPasswordChar = true;
            this.PasswordInput.TextChanged += new System.EventHandler(this.PasswordInput_TextChanged);
            this.PasswordInput.Enter += new System.EventHandler(this.PasswordInput_Enter);
            this.PasswordInput.Leave += new System.EventHandler(this.PasswordInput_Leave);
            // 
            // Passwordlbl
            // 
            this.Passwordlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Passwordlbl.AutoSize = true;
            this.Passwordlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Passwordlbl.Location = new System.Drawing.Point(30, 273);
            this.Passwordlbl.Name = "Passwordlbl";
            this.Passwordlbl.Size = new System.Drawing.Size(102, 20);
            this.Passwordlbl.TabIndex = 31;
            this.Passwordlbl.Text = "Contraseña";
            // 
            // Accessbutton
            // 
            this.Accessbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Accessbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.Accessbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Accessbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Accessbutton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Accessbutton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Accessbutton.Location = new System.Drawing.Point(33, 327);
            this.Accessbutton.Name = "Accessbutton";
            this.Accessbutton.Size = new System.Drawing.Size(335, 32);
            this.Accessbutton.TabIndex = 33;
            this.Accessbutton.Text = "Aceptar";
            this.Accessbutton.UseVisualStyleBackColor = false;
            // 
            // EmailInput
            // 
            this.EmailInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.EmailInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EmailInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailInput.Location = new System.Drawing.Point(136, 120);
            this.EmailInput.Multiline = true;
            this.EmailInput.Name = "EmailInput";
            this.EmailInput.Size = new System.Drawing.Size(232, 25);
            this.EmailInput.TabIndex = 35;
            this.EmailInput.TextChanged += new System.EventHandler(this.EmailInput_TextChanged);
            this.EmailInput.Enter += new System.EventHandler(this.EmailInput_Enter);
            this.EmailInput.Leave += new System.EventHandler(this.EmailInput_Leave);
            // 
            // Emaillbl
            // 
            this.Emaillbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Emaillbl.AutoSize = true;
            this.Emaillbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Emaillbl.Location = new System.Drawing.Point(30, 123);
            this.Emaillbl.Name = "Emaillbl";
            this.Emaillbl.Size = new System.Drawing.Size(63, 20);
            this.Emaillbl.TabIndex = 34;
            this.Emaillbl.Text = "Correo";
            // 
            // AddUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 393);
            this.Controls.Add(this.EmailInput);
            this.Controls.Add(this.Emaillbl);
            this.Controls.Add(this.Accessbutton);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.Passwordlbl);
            this.Controls.Add(this.AddressInput);
            this.Controls.Add(this.PhoneNumberInput);
            this.Controls.Add(this.LastNameInput);
            this.Controls.Add(this.NameInput);
            this.Controls.Add(this.Addresslbl);
            this.Controls.Add(this.Phonenumberlbl);
            this.Controls.Add(this.Lastnamelbl);
            this.Controls.Add(this.Namelbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUsers";
            this.Load += new System.EventHandler(this.AddUsers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox AddressInput;
        private System.Windows.Forms.TextBox PhoneNumberInput;
        private System.Windows.Forms.TextBox LastNameInput;
        private System.Windows.Forms.TextBox NameInput;
        private System.Windows.Forms.Label Addresslbl;
        private System.Windows.Forms.Label Phonenumberlbl;
        private System.Windows.Forms.Label Lastnamelbl;
        private System.Windows.Forms.Label Namelbl;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Label Passwordlbl;
        private System.Windows.Forms.Button Accessbutton;
        private System.Windows.Forms.TextBox EmailInput;
        private System.Windows.Forms.Label Emaillbl;
    }
}