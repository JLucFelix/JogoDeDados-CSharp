namespace JogoDado_p1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnJogador1Normal;
        private System.Windows.Forms.Button btnJogador1Viciado;
        private System.Windows.Forms.Button btnJogador2Normal;
        private System.Windows.Forms.Button btnJogador2Viciado;
        private System.Windows.Forms.DataGridView dataGridViewHistorico;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            btnJogador1Normal = new System.Windows.Forms.Button();
            btnJogador1Viciado = new System.Windows.Forms.Button();
            btnJogador2Normal = new System.Windows.Forms.Button();
            btnJogador2Viciado = new System.Windows.Forms.Button();
            dataGridViewHistorico = new System.Windows.Forms.DataGridView();
            timer1 = new System.Windows.Forms.Timer(components);

            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistorico).BeginInit();
            SuspendLayout();

            // pictureBox1
            pictureBox1.Location = new System.Drawing.Point(40, 20);
            pictureBox1.Size = new System.Drawing.Size(120, 120);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // pictureBox2
            pictureBox2.Location = new System.Drawing.Point(220, 20);
            pictureBox2.Size = new System.Drawing.Size(120, 120);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // btnJogador1Normal
            btnJogador1Normal.Location = new System.Drawing.Point(40, 150);
            btnJogador1Normal.Size = new System.Drawing.Size(120, 30);
            btnJogador1Normal.Text = "Jogador1 Normal";
            btnJogador1Normal.Click += new System.EventHandler(this.btnJogador1Normal_Click);

            // btnJogador1Viciado
            btnJogador1Viciado.Location = new System.Drawing.Point(40, 190);
            btnJogador1Viciado.Size = new System.Drawing.Size(120, 30);
            btnJogador1Viciado.Text = "Jogador1 Viciado";
            btnJogador1Viciado.Click += new System.EventHandler(this.btnJogador1Viciado_Click);

            // btnJogador2Normal
            btnJogador2Normal.Location = new System.Drawing.Point(220, 150);
            btnJogador2Normal.Size = new System.Drawing.Size(120, 30);
            btnJogador2Normal.Text = "Jogador2 Normal";
            btnJogador2Normal.Click += new System.EventHandler(this.btnJogador2Normal_Click);

            // btnJogador2Viciado
            btnJogador2Viciado.Location = new System.Drawing.Point(220, 190);
            btnJogador2Viciado.Size = new System.Drawing.Size(120, 30);
            btnJogador2Viciado.Text = "Jogador2 Viciado";
            btnJogador2Viciado.Click += new System.EventHandler(this.btnJogador2Viciado_Click);

            // dataGridViewHistorico
            dataGridViewHistorico.Location = new System.Drawing.Point(40, 230);
            dataGridViewHistorico.Size = new System.Drawing.Size(300, 120);
            dataGridViewHistorico.ColumnCount = 2;
            dataGridViewHistorico.Columns[0].Name = "Jogador 1";
            dataGridViewHistorico.Columns[1].Name = "Jogador 2";
            dataGridViewHistorico.ReadOnly = true;
            dataGridViewHistorico.AllowUserToAddRows = false;
            dataGridViewHistorico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // timer1
            timer1.Interval = 100;
            timer1.Tick += new System.EventHandler(this.timer1_Tick);

            // Form1
            ClientSize = new System.Drawing.Size(400, 370);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox2);
            Controls.Add(btnJogador1Normal);
            Controls.Add(btnJogador1Viciado);
            Controls.Add(btnJogador2Normal);
            Controls.Add(btnJogador2Viciado);
            Controls.Add(dataGridViewHistorico);
            Text = "Jogo de Dados";

            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistorico).EndInit();
            ResumeLayout(false);
        }
    }
}
