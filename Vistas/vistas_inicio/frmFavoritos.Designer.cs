namespace CR_YPTO_TPF.Vistas.vistas_inicio
{
	partial class frmFavoritos
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
			label2 = new Label();
			label1 = new Label();
			formsPlotFav = new ScottPlot.FormsPlot();
			label3 = new Label();
			textidCryptoFav = new TextBox();
			btnElimCryptoFav = new Button();
			label4 = new Label();
			dataGridFav = new DataGridView();
			label5 = new Label();
			panel1 = new Panel();
			btnCryptoFav = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridFav).BeginInit();
			SuspendLayout();
			// 
			// label2
			// 
			label2.BackColor = Color.SteelBlue;
			label2.Dock = DockStyle.Top;
			label2.Location = new Point(0, 0);
			label2.Name = "label2";
			label2.Size = new Size(1482, 54);
			label2.TabIndex = 1;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.BackColor = Color.SteelBlue;
			label1.ForeColor = Color.White;
			label1.Location = new Point(12, 19);
			label1.Name = "label1";
			label1.Size = new Size(136, 20);
			label1.TabIndex = 2;
			label1.Text = "CR-YPTOS favoritas";
			// 
			// formsPlotFav
			// 
			formsPlotFav.Location = new Point(12, 43);
			formsPlotFav.Margin = new Padding(5, 4, 5, 4);
			formsPlotFav.Name = "formsPlotFav";
			formsPlotFav.Size = new Size(1456, 459);
			formsPlotFav.TabIndex = 3;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(1003, 517);
			label3.Name = "label3";
			label3.Size = new Size(83, 20);
			label3.TabIndex = 4;
			label3.Text = "ID CRYPTO:";
			// 
			// textidCryptoFav
			// 
			textidCryptoFav.Location = new Point(1092, 514);
			textidCryptoFav.Name = "textidCryptoFav";
			textidCryptoFav.Size = new Size(272, 27);
			textidCryptoFav.TabIndex = 5;
			// 
			// btnElimCryptoFav
			// 
			btnElimCryptoFav.Location = new Point(1221, 581);
			btnElimCryptoFav.Name = "btnElimCryptoFav";
			btnElimCryptoFav.Size = new Size(133, 55);
			btnElimCryptoFav.TabIndex = 7;
			btnElimCryptoFav.Text = "Eliminar de favoritos";
			btnElimCryptoFav.UseVisualStyleBackColor = true;
			btnElimCryptoFav.Click += btnElimCryptoFav_Click;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(684, 234);
			label4.Name = "label4";
			label4.Size = new Size(0, 20);
			label4.TabIndex = 8;
			// 
			// dataGridFav
			// 
			dataGridFav.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridFav.Location = new Point(57, 522);
			dataGridFav.Name = "dataGridFav";
			dataGridFav.RowHeadersWidth = 51;
			dataGridFav.Size = new Size(878, 133);
			dataGridFav.TabIndex = 9;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.BackColor = Color.CornflowerBlue;
			label5.Font = new Font("Segoe UI", 10F);
			label5.ForeColor = Color.White;
			label5.Location = new Point(57, 498);
			label5.Name = "label5";
			label5.Size = new Size(323, 23);
			label5.TabIndex = 10;
			label5.Text = "Cripotomedas guardadas como favoritas:";
			// 
			// panel1
			// 
			panel1.Location = new Point(1003, 547);
			panel1.Name = "panel1";
			panel1.Size = new Size(479, 28);
			panel1.TabIndex = 11;
			// 
			// btnCryptoFav
			// 
			btnCryptoFav.Location = new Point(1016, 581);
			btnCryptoFav.Name = "btnCryptoFav";
			btnCryptoFav.Size = new Size(133, 55);
			btnCryptoFav.TabIndex = 14;
			btnCryptoFav.Text = "Guardar como favorito";
			btnCryptoFav.UseVisualStyleBackColor = true;
			btnCryptoFav.Click += btnCryptoFav_Click;
			// 
			// frmFavoritos
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1482, 653);
			Controls.Add(btnCryptoFav);
			Controls.Add(panel1);
			Controls.Add(label5);
			Controls.Add(dataGridFav);
			Controls.Add(label4);
			Controls.Add(btnElimCryptoFav);
			Controls.Add(textidCryptoFav);
			Controls.Add(label3);
			Controls.Add(label1);
			Controls.Add(label2);
			Controls.Add(formsPlotFav);
			Name = "frmFavoritos";
			Text = "frmFavoritos";
			((System.ComponentModel.ISupportInitialize)dataGridFav).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label2;
		private Label label1;
		private ScottPlot.FormsPlot formsPlotFav;
		private Label label3;
		private TextBox textidCryptoFav;
		private Button btnElimCryptoFav;
		private Label label4;
		private DataGridView dataGridFav;
		private Label label5;
		private Panel panel1;
		private Button btnCryptoFav;
	}
}


