namespace CR_YPTO_TPF.Vistas.vistas_inicio
{
	partial class frmCrypto
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
			textidcrypto = new TextBox();
			dataGridView1 = new DataGridView();
			PlotGeneral = new ScottPlot.FormsPlot();
			label3 = new Label();
			btnBuscarCrypto = new Button();
			panel1 = new Panel();
			btnMostrar = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			SuspendLayout();
			// 
			// label1
			// 
			label1.BackColor = Color.SteelBlue;
			label1.Dock = DockStyle.Top;
			label1.Location = new Point(0, 0);
			label1.Name = "label1";
			label1.Size = new Size(1432, 24);
			label1.TabIndex = 0;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.BackColor = Color.SteelBlue;
			label2.Font = new Font("Segoe UI", 11F);
			label2.ForeColor = Color.White;
			label2.Location = new Point(14, -1);
			label2.Name = "label2";
			label2.Size = new Size(173, 25);
			label2.TabIndex = 1;
			label2.Text = "Gráfico de cr-yptos";
			// 
			// textidcrypto
			// 
			textidcrypto.Location = new Point(1090, 507);
			textidcrypto.Name = "textidcrypto";
			textidcrypto.Size = new Size(194, 27);
			textidcrypto.TabIndex = 6;
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.AllowUserToOrderColumns = true;
			dataGridView1.BackgroundColor = Color.White;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Location = new Point(46, 510);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.Size = new Size(948, 200);
			dataGridView1.TabIndex = 7;
			// 
			// PlotGeneral
			// 
			PlotGeneral.Location = new Point(0, 12);
			PlotGeneral.Margin = new Padding(5, 4, 5, 4);
			PlotGeneral.Name = "PlotGeneral";
			PlotGeneral.Size = new Size(1443, 468);
			PlotGeneral.TabIndex = 8;
			PlotGeneral.Load += PlotGeneral_Load;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(1090, 484);
			label3.Name = "label3";
			label3.Size = new Size(124, 20);
			label3.TabIndex = 9;
			label3.Text = "Ingrese ID Crypto";
			// 
			// btnBuscarCrypto
			// 
			btnBuscarCrypto.Location = new Point(1034, 568);
			btnBuscarCrypto.Name = "btnBuscarCrypto";
			btnBuscarCrypto.Size = new Size(146, 29);
			btnBuscarCrypto.TabIndex = 10;
			btnBuscarCrypto.Text = "Buscar";
			btnBuscarCrypto.UseVisualStyleBackColor = false;
			btnBuscarCrypto.Click += btnBuscarCrypto_Click;
			// 
			// panel1
			// 
			panel1.Location = new Point(1010, 529);
			panel1.Name = "panel1";
			panel1.Size = new Size(402, 33);
			panel1.TabIndex = 12;
			// 
			// btnMostrar
			// 
			btnMostrar.Location = new Point(1215, 568);
			btnMostrar.Name = "btnMostrar";
			btnMostrar.Size = new Size(146, 29);
			btnMostrar.TabIndex = 14;
			btnMostrar.Text = "Mostrar todas";
			btnMostrar.UseVisualStyleBackColor = false;
			btnMostrar.Click += btnMostrar_Click;
			// 
			// frmCrypto
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1432, 703);
			Controls.Add(btnMostrar);
			Controls.Add(panel1);
			Controls.Add(btnBuscarCrypto);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(label3);
			Controls.Add(dataGridView1);
			Controls.Add(textidcrypto);
			Controls.Add(PlotGeneral);
			Name = "frmCrypto";
			Text = "frmCrypto";
			Load += frmCrypto_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private TextBox textidcrypto;
		private DataGridView dataGridView1;
		private ScottPlot.FormsPlot PlotGeneral;
		private Label label3;
		private Button btnBuscarCrypto;
		private Panel panel1;
		private Button btnMostrar;
	}
}

