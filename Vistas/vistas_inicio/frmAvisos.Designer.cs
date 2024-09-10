namespace CR_YPTO_TPF.Vistas.vistas_inicio
{
	partial class frmAvisos
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
			notificiaciones = new ListBox();
			label3 = new Label();
			label4 = new Label();
			panel1 = new Panel();
			label5 = new Label();
			temp = new Label();
			panelFinCambios = new Panel();
			tiempoRestante = new Panel();
			SuspendLayout();
			// 
			// label1
			// 
			label1.BackColor = Color.SteelBlue;
			label1.Dock = DockStyle.Top;
			label1.Location = new Point(0, 0);
			label1.Name = "label1";
			label1.Size = new Size(1482, 79);
			label1.TabIndex = 0;
			// 
			// label2
			// 
			label2.BackColor = Color.SteelBlue;
			label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label2.ForeColor = Color.White;
			label2.Location = new Point(31, 24);
			label2.Name = "label2";
			label2.Size = new Size(197, 30);
			label2.TabIndex = 1;
			label2.Text = "NOTIFICACIONES";
			// 
			// notificiaciones
			// 
			notificiaciones.BackColor = SystemColors.ActiveCaption;
			notificiaciones.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			notificiaciones.FormattingEnabled = true;
			notificiaciones.ItemHeight = 25;
			notificiaciones.Location = new Point(236, 152);
			notificiaciones.Name = "notificiaciones";
			notificiaciones.Size = new Size(1038, 479);
			notificiaciones.TabIndex = 2;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label3.Location = new Point(615, 121);
			label3.Name = "label3";
			label3.Size = new Size(292, 28);
			label3.TabIndex = 3;
			label3.Text = "Cambios con respecto al umbral";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(31, 95);
			label4.Name = "label4";
			label4.Size = new Size(105, 20);
			label4.TabIndex = 4;
			label4.Text = "Umbral actual:";
			// 
			// panel1
			// 
			panel1.Location = new Point(142, 97);
			panel1.Name = "panel1";
			panel1.Size = new Size(86, 32);
			panel1.TabIndex = 5;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(195, 97);
			label5.Name = "label5";
			label5.Size = new Size(21, 20);
			label5.TabIndex = 6;
			label5.Text = "%";
			// 
			// temp
			// 
			temp.AutoSize = true;
			temp.Location = new Point(867, 126);
			temp.Name = "temp";
			temp.Size = new Size(0, 20);
			temp.TabIndex = 8;
			// 
			// panelFinCambios
			// 
			panelFinCambios.AutoSize = true;
			panelFinCambios.BackColor = Color.SteelBlue;
			panelFinCambios.ForeColor = Color.White;
			panelFinCambios.Location = new Point(217, 34);
			panelFinCambios.Name = "panelFinCambios";
			panelFinCambios.Size = new Size(553, 45);
			panelFinCambios.TabIndex = 9;
			// 
			// tiempoRestante
			// 
			tiempoRestante.Location = new Point(459, 91);
			tiempoRestante.Name = "tiempoRestante";
			tiempoRestante.Size = new Size(710, 32);
			tiempoRestante.TabIndex = 6;
			// 
			// frmAvisos
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1482, 653);
			Controls.Add(tiempoRestante);
			Controls.Add(panelFinCambios);
			Controls.Add(temp);
			Controls.Add(label5);
			Controls.Add(panel1);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(notificiaciones);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "frmAvisos";
			Text = "frmAvisos";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private ListBox notificiaciones;
		private Label label3;
		private Label label4;
		private Panel panel1;
		private Label label5;
		private Label temp;
		private Panel panelFinCambios;
		private Panel tiempoRestante;
	}
}