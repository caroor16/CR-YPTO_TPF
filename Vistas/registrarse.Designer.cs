namespace CR_YPTO_TPF.Vistas
{
	partial class registrarse
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
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label6 = new Label();
			textnombre = new TextBox();
			textapellido = new TextBox();
			textcorreo = new TextBox();
			btnregistrarse2 = new FontAwesome.Sharp.IconButton();
			btncancelar2 = new FontAwesome.Sharp.IconButton();
			textusuarioreg = new TextBox();
			textclavereg = new TextBox();
			label5 = new Label();
			label7 = new Label();
			panel1 = new Panel();
			iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
			((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(430, 4);
			label1.Name = "label1";
			label1.Size = new Size(59, 20);
			label1.TabIndex = 0;
			label1.Text = "Usuario";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(430, 61);
			label2.Name = "label2";
			label2.Size = new Size(64, 20);
			label2.TabIndex = 1;
			label2.Text = "Nombre";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(430, 134);
			label3.Name = "label3";
			label3.Size = new Size(66, 20);
			label3.TabIndex = 2;
			label3.Text = "Apellido";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(430, 197);
			label4.Name = "label4";
			label4.Size = new Size(54, 20);
			label4.TabIndex = 3;
			label4.Text = "Correo";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(430, 255);
			label6.Name = "label6";
			label6.Size = new Size(83, 20);
			label6.TabIndex = 5;
			label6.Text = "Contraseña";
			// 
			// textnombre
			// 
			textnombre.Location = new Point(430, 94);
			textnombre.Name = "textnombre";
			textnombre.Size = new Size(281, 27);
			textnombre.TabIndex = 7;
			// 
			// textapellido
			// 
			textapellido.Location = new Point(430, 157);
			textapellido.Name = "textapellido";
			textapellido.Size = new Size(281, 27);
			textapellido.TabIndex = 8;
			// 
			// textcorreo
			// 
			textcorreo.Location = new Point(430, 220);
			textcorreo.Name = "textcorreo";
			textcorreo.Size = new Size(281, 27);
			textcorreo.TabIndex = 10;
			// 
			// btnregistrarse2
			// 
			btnregistrarse2.IconChar = FontAwesome.Sharp.IconChar.None;
			btnregistrarse2.IconColor = Color.Black;
			btnregistrarse2.IconFont = FontAwesome.Sharp.IconFont.Auto;
			btnregistrarse2.Location = new Point(402, 382);
			btnregistrarse2.Name = "btnregistrarse2";
			btnregistrarse2.Size = new Size(149, 29);
			btnregistrarse2.TabIndex = 12;
			btnregistrarse2.Text = "Registrarse";
			btnregistrarse2.UseVisualStyleBackColor = true;
			btnregistrarse2.Click += btnregistrarse2_Click;
			// 
			// btncancelar2
			// 
			btncancelar2.IconChar = FontAwesome.Sharp.IconChar.None;
			btncancelar2.IconColor = Color.Black;
			btncancelar2.IconFont = FontAwesome.Sharp.IconFont.Auto;
			btncancelar2.Location = new Point(572, 382);
			btncancelar2.Name = "btncancelar2";
			btncancelar2.Size = new Size(149, 29);
			btncancelar2.TabIndex = 13;
			btncancelar2.Text = "Cancelar";
			btncancelar2.UseVisualStyleBackColor = true;
			btncancelar2.Click += btncancelar2_Click;
			// 
			// textusuarioreg
			// 
			textusuarioreg.Location = new Point(430, 31);
			textusuarioreg.Name = "textusuarioreg";
			textusuarioreg.Size = new Size(281, 27);
			textusuarioreg.TabIndex = 16;
			// 
			// textclavereg
			// 
			textclavereg.Location = new Point(430, 282);
			textclavereg.Name = "textclavereg";
			textclavereg.PasswordChar = '*';
			textclavereg.Size = new Size(281, 27);
			textclavereg.TabIndex = 15;
			// 
			// label5
			// 
			label5.BackColor = Color.SteelBlue;
			label5.Dock = DockStyle.Left;
			label5.Location = new Point(0, 0);
			label5.Name = "label5";
			label5.Size = new Size(338, 450);
			label5.TabIndex = 17;
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.BackColor = Color.SteelBlue;
			label7.Font = new Font("Arial Narrow", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label7.ForeColor = Color.White;
			label7.Location = new Point(52, 383);
			label7.Name = "label7";
			label7.Size = new Size(217, 24);
			label7.TabIndex = 18;
			label7.Text = "REGISTRO DE USUARIOS";
			// 
			// panel1
			// 
			panel1.Location = new Point(378, 315);
			panel1.Name = "panel1";
			panel1.Size = new Size(357, 61);
			panel1.TabIndex = 19;
			// 
			// iconPictureBox1
			// 
			iconPictureBox1.BackColor = Color.SteelBlue;
			iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Bitcoin;
			iconPictureBox1.IconColor = Color.White;
			iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
			iconPictureBox1.IconSize = 302;
			iconPictureBox1.Location = new Point(12, 74);
			iconPictureBox1.Name = "iconPictureBox1";
			iconPictureBox1.Size = new Size(314, 302);
			iconPictureBox1.TabIndex = 20;
			iconPictureBox1.TabStop = false;
			// 
			// registrarse
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(747, 450);
			Controls.Add(iconPictureBox1);
			Controls.Add(panel1);
			Controls.Add(label7);
			Controls.Add(label5);
			Controls.Add(textusuarioreg);
			Controls.Add(textclavereg);
			Controls.Add(btncancelar2);
			Controls.Add(btnregistrarse2);
			Controls.Add(textcorreo);
			Controls.Add(textapellido);
			Controls.Add(textnombre);
			Controls.Add(label6);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "registrarse";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "registrarse";
			((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label6;
		private TextBox textusuario;
		private TextBox textnombre;
		private TextBox textapellido;
		private TextBox textcorreo;
		private FontAwesome.Sharp.IconButton btnregistrarse2;
		private FontAwesome.Sharp.IconButton btncancelar2;
		private TextBox textusuarioreg;
		private TextBox textclavereg;
		private Label label5;
		private Label label7;
		private Panel panel1;
		private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
	}
}