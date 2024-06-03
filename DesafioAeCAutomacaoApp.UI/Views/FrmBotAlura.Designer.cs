namespace DesafioAeCAutomacaoApp.UI.Views
{
    partial class FrmBotAlura
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
            groupBox1 = new GroupBox();
            BtnConsultar = new Button();
            txtCampoTermo = new TextBox();
            groupBox2 = new GroupBox();
            DgvBaseDados = new DataGridView();
            BtnDgv = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvBaseDados).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(BtnConsultar);
            groupBox1.Controls.Add(txtCampoTermo);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(400, 69);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Consultar Curso Alura";
            // 
            // BtnConsultar
            // 
            BtnConsultar.Location = new Point(270, 22);
            BtnConsultar.Name = "BtnConsultar";
            BtnConsultar.Size = new Size(101, 25);
            BtnConsultar.TabIndex = 2;
            BtnConsultar.Text = "Consultar";
            BtnConsultar.UseVisualStyleBackColor = true;
            BtnConsultar.Click += BtnConsultar_Click;
            // 
            // txtCampoTermo
            // 
            txtCampoTermo.Location = new Point(6, 22);
            txtCampoTermo.Name = "txtCampoTermo";
            txtCampoTermo.Size = new Size(258, 23);
            txtCampoTermo.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(DgvBaseDados);
            groupBox2.Location = new Point(12, 111);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(624, 240);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dados Pesquisados";
            // 
            // DgvBaseDados
            // 
            DgvBaseDados.BackgroundColor = Color.White;
            DgvBaseDados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvBaseDados.Location = new Point(6, 22);
            DgvBaseDados.Name = "DgvBaseDados";
            DgvBaseDados.Size = new Size(612, 212);
            DgvBaseDados.TabIndex = 0;
            // 
            // BtnDgv
            // 
            BtnDgv.Location = new Point(18, 357);
            BtnDgv.Name = "BtnDgv";
            BtnDgv.Size = new Size(161, 28);
            BtnDgv.TabIndex = 3;
            BtnDgv.Text = "Carregar Resultados";
            BtnDgv.UseVisualStyleBackColor = true;
            BtnDgv.Click += BtnDgv_Click;
            // 
            // FrmBotAlura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(648, 424);
            Controls.Add(BtnDgv);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmBotAlura";
            Text = "BOT - ALURA - AeC AUTOMAÇÃO";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvBaseDados).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private Button BtnConsultar;
        private TextBox txtCampoTermo;
        private GroupBox groupBox2;
        private DataGridView DgvBaseDados;
        private Button BtnDgv;
    }
}