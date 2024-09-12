namespace CR_YPTO_TPF.Vistas
{
	partial class inicio
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
			menu = new MenuStrip();
			menuUsuario = new FontAwesome.Sharp.IconMenuItem();
			menuAvisos = new FontAwesome.Sharp.IconMenuItem();
			menuFavoritos = new FontAwesome.Sharp.IconMenuItem();
			menuCrypto = new FontAwesome.Sharp.IconMenuItem();
			cerrarS = new FontAwesome.Sharp.IconMenuItem();
			contenedor = new Panel();
			menuTitulo = new MenuStrip();
			menu.SuspendLayout();
			SuspendLayout();
			// 
			// menu
			// 
			menu.BackColor = Color.White;
			menu.ImageScalingSize = new Size(20, 20);
			menu.Items.AddRange(new ToolStripItem[] { menuUsuario, menuAvisos, menuFavoritos, menuCrypto, cerrarS });
			menu.Location = new Point(0, 56);
			menu.Name = "menu";
			menu.Size = new Size(1482, 78);
			menu.TabIndex = 4;
			menu.Text = "menuStrip1";
			// 
			// menuUsuario
			// 
			menuUsuario.AutoSize = false;
			menuUsuario.IconChar = FontAwesome.Sharp.IconChar.User;
			menuUsuario.IconColor = Color.Black;
			menuUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
			menuUsuario.IconSize = 50;
			menuUsuario.ImageScaling = ToolStripItemImageScaling.None;
			menuUsuario.Name = "menuUsuario";
			menuUsuario.Size = new Size(80, 74);
			menuUsuario.Text = "Usuario";
			menuUsuario.TextImageRelation = TextImageRelation.ImageAboveText;
			menuUsuario.Click += menuUsuario_Click;
			// 
			// menuAvisos
			// 
			menuAvisos.AutoSize = false;
			menuAvisos.IconChar = FontAwesome.Sharp.IconChar.Bell;
			menuAvisos.IconColor = Color.Black;
			menuAvisos.IconFont = FontAwesome.Sharp.IconFont.Auto;
			menuAvisos.IconSize = 50;
			menuAvisos.ImageScaling = ToolStripItemImageScaling.None;
			menuAvisos.Name = "menuAvisos";
			menuAvisos.Size = new Size(80, 74);
			menuAvisos.Text = "Avisos";
			menuAvisos.TextImageRelation = TextImageRelation.ImageAboveText;
			menuAvisos.Click += menuAvisos_Click;
			// 
			// menuFavoritos
			// 
			menuFavoritos.AutoSize = false;
			menuFavoritos.IconChar = FontAwesome.Sharp.IconChar.Star;
			menuFavoritos.IconColor = Color.Black;
			menuFavoritos.IconFont = FontAwesome.Sharp.IconFont.Auto;
			menuFavoritos.IconSize = 50;
			menuFavoritos.ImageScaling = ToolStripItemImageScaling.None;
			menuFavoritos.Name = "menuFavoritos";
			menuFavoritos.Size = new Size(80, 74);
			menuFavoritos.Text = "Favoritos";
			menuFavoritos.TextImageRelation = TextImageRelation.ImageAboveText;
			menuFavoritos.Click += menuFavoritos_Click;
			// 
			// menuCrypto
			// 
			menuCrypto.AutoSize = false;
			menuCrypto.IconChar = FontAwesome.Sharp.IconChar.Bitcoin;
			menuCrypto.IconColor = Color.Black;
			menuCrypto.IconFont = FontAwesome.Sharp.IconFont.Auto;
			menuCrypto.IconSize = 50;
			menuCrypto.ImageScaling = ToolStripItemImageScaling.None;
			menuCrypto.Name = "menuCrypto";
			menuCrypto.Size = new Size(80, 74);
			menuCrypto.Text = "Crypto";
			menuCrypto.TextImageRelation = TextImageRelation.ImageAboveText;
			menuCrypto.Click += menuCrypto_Click;
			// 
			// cerrarS
			// 
			cerrarS.AutoSize = false;
			cerrarS.ForeColor = Color.Red;
			cerrarS.IconChar = FontAwesome.Sharp.IconChar.DoorClosed;
			cerrarS.IconColor = Color.DarkRed;
			cerrarS.IconFont = FontAwesome.Sharp.IconFont.Auto;
			cerrarS.IconSize = 50;
			cerrarS.ImageScaling = ToolStripItemImageScaling.None;
			cerrarS.Name = "cerrarS";
			cerrarS.Size = new Size(152, 74);
			cerrarS.Text = "Cerrar sesión";
			cerrarS.TextImageRelation = TextImageRelation.ImageAboveText;
			cerrarS.Click += cerrarS_Click;
			// 
			// contenedor
			// 
			contenedor.Dock = DockStyle.Fill;
			contenedor.Location = new Point(0, 134);
			contenedor.Name = "contenedor";
			contenedor.Size = new Size(1482, 669);
			contenedor.TabIndex = 5;
			// 
			// menuTitulo
			// 
			menuTitulo.AutoSize = false;
			menuTitulo.BackColor = Color.SteelBlue;
			menuTitulo.ImageScalingSize = new Size(20, 20);
			menuTitulo.Location = new Point(0, 0);
			menuTitulo.Name = "menuTitulo";
			menuTitulo.RightToLeft = RightToLeft.Yes;
			menuTitulo.Size = new Size(1482, 56);
			menuTitulo.TabIndex = 3;
			menuTitulo.Text = "menuStrip2";
			menuTitulo.ItemClicked += menuTitulo_ItemClicked;
			// 
			// inicio
			// 
			AutoScaleDimensions = new SizeF(120F, 120F);
			AutoScaleMode = AutoScaleMode.Dpi;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			AutoValidate = AutoValidate.EnableAllowFocusChange;
			BackColor = SystemColors.Control;
			ClientSize = new Size(1482, 803);
			Controls.Add(contenedor);
			Controls.Add(menu);
			Controls.Add(menuTitulo);
			FormBorderStyle = FormBorderStyle.None;
			Name = "inicio";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "inicio";
			Load += inicio_Load;
			menu.ResumeLayout(false);
			menu.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private MenuStrip menu;
		private FontAwesome.Sharp.IconMenuItem menuUsuario;
		private FontAwesome.Sharp.IconMenuItem menuAvisos;
		private FontAwesome.Sharp.IconMenuItem menuFavoritos;
		private Panel contenedor;
		private MenuStrip menuTitulo;
		private FontAwesome.Sharp.IconMenuItem cerrarS;
		private FontAwesome.Sharp.IconMenuItem menuCrypto;
	}
}