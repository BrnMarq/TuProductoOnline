
namespace TuProductoOnline
{
    partial class CustomerProperties
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
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblId = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblDirection = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.TitleCustomers = new System.Windows.Forms.Label();
            this.TxtNameErrorlbl = new System.Windows.Forms.Label();
            this.TxtLastNameErrorlbl = new System.Windows.Forms.Label();
            this.TxtIdErrorlbl = new System.Windows.Forms.Label();
            this.TxtPhoneNumberErrorlbl = new System.Windows.Forms.Label();
            this.TxtAddressErrorlbl = new System.Windows.Forms.Label();
            this.TxtEmailErrorlbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(28, 97);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(68, 18);
            this.lblName.TabIndex = 10;
            this.lblName.Text = "Nombre";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(28, 146);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(67, 18);
            this.lblLastName.TabIndex = 11;
            this.lblLastName.Text = "Apellido";
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(28, 195);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(91, 18);
            this.lblId.TabIndex = 12;
            this.lblId.Text = "Cédula/RIF";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(29, 243);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(74, 18);
            this.lblPhoneNumber.TabIndex = 13;
            this.lblPhoneNumber.Text = "Teléfono";
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDirection.Location = new System.Drawing.Point(29, 291);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(80, 18);
            this.lblDirection.TabIndex = 14;
            this.lblDirection.Text = "Dirección";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(29, 394);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(41, 18);
            this.lblType.TabIndex = 16;
            this.lblType.Text = "Tipo";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtName.Location = new System.Drawing.Point(134, 95);
            this.txtName.MaxLength = 100;
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(232, 25);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // txtLastName
            // 
            this.txtLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(134, 143);
            this.txtLastName.MaxLength = 100;
            this.txtLastName.Multiline = true;
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(232, 25);
            this.txtLastName.TabIndex = 1;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtLastName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // txtId
            // 
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(134, 192);
            this.txtId.MaxLength = 20;
            this.txtId.Multiline = true;
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(232, 25);
            this.txtId.TabIndex = 2;
            this.txtId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtId_KeyPress);
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(134, 240);
            this.txtPhoneNumber.MaxLength = 20;
            this.txtPhoneNumber.Multiline = true;
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(232, 25);
            this.txtPhoneNumber.TabIndex = 3;
            this.txtPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhoneNumber_KeyPress);
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(134, 288);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(232, 25);
            this.txtAddress.TabIndex = 4;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddress_KeyPress);
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Ordinario",
            "Contribuyente especial"});
            this.cbType.Location = new System.Drawing.Point(134, 390);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(232, 24);
            this.cbType.TabIndex = 6;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAccept.Location = new System.Drawing.Point(31, 438);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(334, 32);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(134, 337);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(232, 25);
            this.txtEmail.TabIndex = 5;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(29, 340);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(50, 18);
            this.lblEmail.TabIndex = 15;
            this.lblEmail.Text = "Email";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.White;
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Location = new System.Drawing.Point(133, 59);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(232, 25);
            this.txtCode.TabIndex = 9;
            this.txtCode.Visible = false;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(27, 60);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(62, 18);
            this.lblCode.TabIndex = 8;
            this.lblCode.Tag = "";
            this.lblCode.Text = "Código";
            this.lblCode.Visible = false;
            // 
            // TitleCustomers
            // 
            this.TitleCustomers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TitleCustomers.AutoSize = true;
            this.TitleCustomers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleCustomers.Location = new System.Drawing.Point(109, 28);
            this.TitleCustomers.Name = "TitleCustomers";
            this.TitleCustomers.Size = new System.Drawing.Size(176, 25);
            this.TitleCustomers.TabIndex = 17;
            this.TitleCustomers.Text = "Agregar Cliente";
            this.TitleCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtNameErrorlbl
            // 
            this.TxtNameErrorlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtNameErrorlbl.AutoSize = true;
            this.TxtNameErrorlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNameErrorlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TxtNameErrorlbl.Location = new System.Drawing.Point(29, 125);
            this.TxtNameErrorlbl.Name = "TxtNameErrorlbl";
            this.TxtNameErrorlbl.Size = new System.Drawing.Size(269, 16);
            this.TxtNameErrorlbl.TabIndex = 18;
            this.TxtNameErrorlbl.Text = "Ingrese el Nombre (Maximo 100 Carácteres)";
            this.TxtNameErrorlbl.Visible = false;
            // 
            // TxtLastNameErrorlbl
            // 
            this.TxtLastNameErrorlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtLastNameErrorlbl.AutoSize = true;
            this.TxtLastNameErrorlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLastNameErrorlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TxtLastNameErrorlbl.Location = new System.Drawing.Point(29, 173);
            this.TxtLastNameErrorlbl.Name = "TxtLastNameErrorlbl";
            this.TxtLastNameErrorlbl.Size = new System.Drawing.Size(270, 16);
            this.TxtLastNameErrorlbl.TabIndex = 19;
            this.TxtLastNameErrorlbl.Text = "Ingrese el Apellido (Maximo 100 Carácteres)";
            this.TxtLastNameErrorlbl.Visible = false;
            // 
            // TxtIdErrorlbl
            // 
            this.TxtIdErrorlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtIdErrorlbl.AutoSize = true;
            this.TxtIdErrorlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIdErrorlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TxtIdErrorlbl.Location = new System.Drawing.Point(29, 222);
            this.TxtIdErrorlbl.Name = "TxtIdErrorlbl";
            this.TxtIdErrorlbl.Size = new System.Drawing.Size(261, 16);
            this.TxtIdErrorlbl.TabIndex = 20;
            this.TxtIdErrorlbl.Text = "Ingrese el Correo (Maximo 200 Carácteres)";
            this.TxtIdErrorlbl.Visible = false;
            // 
            // TxtPhoneNumberErrorlbl
            // 
            this.TxtPhoneNumberErrorlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPhoneNumberErrorlbl.AutoSize = true;
            this.TxtPhoneNumberErrorlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPhoneNumberErrorlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TxtPhoneNumberErrorlbl.Location = new System.Drawing.Point(29, 270);
            this.TxtPhoneNumberErrorlbl.Name = "TxtPhoneNumberErrorlbl";
            this.TxtPhoneNumberErrorlbl.Size = new System.Drawing.Size(267, 16);
            this.TxtPhoneNumberErrorlbl.TabIndex = 21;
            this.TxtPhoneNumberErrorlbl.Text = "Ingrese el Teléfono (Maximo 50 Carácteres)";
            this.TxtPhoneNumberErrorlbl.Visible = false;
            // 
            // TxtAddressErrorlbl
            // 
            this.TxtAddressErrorlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtAddressErrorlbl.AutoSize = true;
            this.TxtAddressErrorlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAddressErrorlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TxtAddressErrorlbl.Location = new System.Drawing.Point(29, 318);
            this.TxtAddressErrorlbl.Name = "TxtAddressErrorlbl";
            this.TxtAddressErrorlbl.Size = new System.Drawing.Size(277, 16);
            this.TxtAddressErrorlbl.TabIndex = 22;
            this.TxtAddressErrorlbl.Text = "Ingrese la Direccion (Maximo 250 Carácteres)";
            this.TxtAddressErrorlbl.Visible = false;
            // 
            // TxtEmailErrorlbl
            // 
            this.TxtEmailErrorlbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtEmailErrorlbl.AutoSize = true;
            this.TxtEmailErrorlbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmailErrorlbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.TxtEmailErrorlbl.Location = new System.Drawing.Point(28, 368);
            this.TxtEmailErrorlbl.Name = "TxtEmailErrorlbl";
            this.TxtEmailErrorlbl.Size = new System.Drawing.Size(261, 16);
            this.TxtEmailErrorlbl.TabIndex = 23;
            this.TxtEmailErrorlbl.Text = "Ingrese el Correo (Maximo 200 Carácteres)";
            this.TxtEmailErrorlbl.Visible = false;
            // 
            // CustomerProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(396, 492);
            this.Controls.Add(this.TxtEmailErrorlbl);
            this.Controls.Add(this.TxtAddressErrorlbl);
            this.Controls.Add(this.TxtPhoneNumberErrorlbl);
            this.Controls.Add(this.TxtIdErrorlbl);
            this.Controls.Add(this.TxtLastNameErrorlbl);
            this.Controls.Add(this.TxtNameErrorlbl);
            this.Controls.Add(this.TitleCustomers);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CustomerProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "customerProperties";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CustomerProperties_FormClosed);
            this.Load += new System.EventHandler(this.CustomerProperties_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label TitleCustomers;
        private System.Windows.Forms.Label TxtNameErrorlbl;
        private System.Windows.Forms.Label TxtLastNameErrorlbl;
        private System.Windows.Forms.Label TxtIdErrorlbl;
        private System.Windows.Forms.Label TxtPhoneNumberErrorlbl;
        private System.Windows.Forms.Label TxtAddressErrorlbl;
        private System.Windows.Forms.Label TxtEmailErrorlbl;
    }
}