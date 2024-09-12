namespace CR_YPTO_TPF.Vistas
{
	partial class Login
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
			iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
			label3 = new Label();
			label4 = new Label();
			textusuario = new TextBox();
			textclave = new TextBox();
			btningresar = new FontAwesome.Sharp.IconButton();
			btnregistrarse = new FontAwesome.Sharp.IconButton();
			btncancelar = new FontAwesome.Sharp.IconButton();
			panel1 = new Panel();
			label2 = new Label();
			((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.BackColor = Color.SteelBlue;
			label1.Dock = DockStyle.Left;
			label1.Location = new Point(0, 0);
			label1.Name = "label1";
			label1.Size = new Size(245, 243);
			label1.TabIndex = 0;
			// 
			// iconPictureBox1
			// 
			iconPictureBox1.BackColor = Color.SteelBlue;
			iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Bitcoin;
			iconPictureBox1.IconColor = Color.White;
			iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
			iconPictureBox1.IconSize = 128;
			iconPictureBox1.Location = new Point(49, 28);
			iconPictureBox1.Name = "iconPictureBox1";
			iconPictureBox1.Size = new Size(128, 133);
			iconPictureBox1.TabIndex = 2;
			iconPictureBox1.TabStop = false;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(275, 17);
			label3.Name = "label3";
			label3.Size = new Size(59, 20);
			label3.TabIndex = 3;
			label3.Text = "Usuario";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(279, 75);
			label4.Name = "label4";
			label4.Size = new Size(83, 20);
			label4.TabIndex = 4;
			label4.Text = "Contraseña";
			// 
			// textusuario
			// 
			textusuario.Location = new Point(279, 40);
			textusuario.Name = "textusuario";
			textusuario.Size = new Size(285, 27);
			textusuario.TabIndex = 5;
			// 
			// textclave
			// 
			textclave.Location = new Point(279, 98);
			textclave.Name = "textclave";
			textclave.PasswordChar = '*';
			textclave.Size = new Size(285, 27);
			textclave.TabIndex = 6;
			// 
			// btningresar
			// 
			btningresar.Cursor = Cursors.Hand;
			btningresar.IconChar = FontAwesome.Sharp.IconChar.None;
			btningresar.IconColor = Color.Black;
			btningresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
			btningresar.Location = new Point(275, 167);
			btningresar.Name = "btningresar";
			btningresar.Size = new Size(115, 29);
			btningresar.TabIndex = 17;
			btningresar.Text = "Ingresar";
			btningresar.UseVisualStyleBackColor = true;
			btningresar.Click += btningresar_Click;
			// 
			// btnregistrarse
			// 
			btnregistrarse.Cursor = Cursors.Hand;
			btnregistrarse.IconChar = FontAwesome.Sharp.IconChar.None;
			btnregistrarse.IconColor = Color.Black;
			btnregistrarse.IconFont = FontAwesome.Sharp.IconFont.Auto;
			btnregistrarse.Location = new Point(358, 204);
			btnregistrarse.Name = "btnregistrarse";
			btnregistrarse.Size = new Size(115, 29);
			btnregistrarse.TabIndex = 16;
			btnregistrarse.Text = "Registrarse";
			btnregistrarse.UseVisualStyleBackColor = true;
			btnregistrarse.Click += btnregistrarse_Click;
			// 
			// btncancelar
			// 
			btncancelar.Cursor = Cursors.Hand;
			btncancelar.IconChar = FontAwesome.Sharp.IconChar.None;
			btncancelar.IconColor = Color.Black;
			btncancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
			btncancelar.Location = new Point(437, 167);
			btncancelar.Name = "btncancelar";
			btncancelar.Size = new Size(115, 29);
			btncancelar.TabIndex = 15;
			btncancelar.Text = "Cancelar";
			btncancelar.UseVisualStyleBackColor = true;
			btncancelar.Click += btncancelar_Click;
			// 
			// panel1
			// 
			panel1.Location = new Point(275, 131);
			panel1.Name = "panel1";
			panel1.Size = new Size(289, 30);
			panel1.TabIndex = 18;
			// 
			// label2
			// 
			label2.BackColor = Color.SteelBlue;
			label2.ForeColor = Color.White;
			label2.Location = new Point(16, 181);
			label2.Name = "label2";
			label2.Size = new Size(226, 25);
			label2.TabIndex = 2;
			label2.Text = "SEGUIMIENTO DE CR-YPTO-SS";
			// 
			// Login
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(586, 243);
			Controls.Add(label2);
			Controls.Add(panel1);
			Controls.Add(btningresar);
			Controls.Add(btnregistrarse);
			Controls.Add(btncancelar);
			Controls.Add(textclave);
			Controls.Add(textusuario);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(iconPictureBox1);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedToolWindow;
			Name = "Login";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Login";
			((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
		private Label label3;
		private Label label4;
		private TextBox textusuario;
		private TextBox textclave;
		private FontAwesome.Sharp.IconButton btningresar;
		private FontAwesome.Sharp.IconButton btnregistrarse;
		private FontAwesome.Sharp.IconButton btncancelar;
		private Panel panel1;
		private Label label2;
	}
}