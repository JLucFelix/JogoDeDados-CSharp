using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ClasseDado;
using Timer = System.Windows.Forms.Timer;

namespace JogoDado_p1
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private Dado dadoAtual;
        private PictureBox pictureBoxAtual;
        private int faceFinal;
        private int passosAtual;
        private int animacaoPassos = 15;
        private string pastaFotos;

        private int vezJogador = 1; 
        private int jogadorAtual;
        private int rodadaAtual = 0;
        private int maxRodadas = 3;

        private List<int> historicoJogador1 = new List<int>();
        private List<int> historicoJogador2 = new List<int>();

        public Form1()
        {
            InitializeComponent();
            pastaFotos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fotos_dados");
            if (!Directory.Exists(pastaFotos))
            {
                MessageBox.Show("Pasta 'fotos_dados' não encontrada. Coloque as imagens nela (dado1.png a dado6.png).");
            }

            for (int i = 0; i < maxRodadas; i++)
            {
                dataGridViewHistorico.Rows.Add();
            }
        }


        #region Handlers de Clique dos Botões
        private void btnJogador1Normal_Click(object sender, EventArgs e)
        {
            if (vezJogador != 1) return;
            dadoAtual = new DadoNormal();
            JogarDado(pictureBox1, 1);
        }

        private void btnJogador1Viciado_Click(object sender, EventArgs e)
        {
            if (vezJogador != 1) return;
            dadoAtual = new DadoViciado();
            JogarDado(pictureBox1, 1);
        }

        private void btnJogador2Normal_Click(object sender, EventArgs e)
        {
            if (vezJogador != 2) return;
            dadoAtual = new DadoNormal();
            JogarDado(pictureBox2, 2);
        }

        private void btnJogador2Viciado_Click(object sender, EventArgs e)
        {
            if (vezJogador != 2) return;
            dadoAtual = new DadoViciado();
            JogarDado(pictureBox2, 2);
        }
        #endregion

        private void JogarDado(PictureBox pb, int jogador)
        {
            btnJogador1Normal.Enabled = false;
            btnJogador1Viciado.Enabled = false;
            btnJogador2Normal.Enabled = false;
            btnJogador2Viciado.Enabled = false;

            pictureBoxAtual = pb;
            jogadorAtual = jogador;
            faceFinal = dadoAtual.Roll();
            passosAtual = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBoxAtual == null) return;

            passosAtual++;


            int faceAnimada;
            if (dadoAtual is DadoNormal)
                faceAnimada = random.Next(1, 7);
            else
            {
                int numero = random.Next(1, 10);
                faceAnimada = numero <= 5 ? 6 : random.Next(1, 6);
            }
            string caminhoImg = Path.Combine(pastaFotos, $"dado{faceAnimada}.png");
            if (File.Exists(caminhoImg))
            {
                pictureBoxAtual.Image?.Dispose();
                pictureBoxAtual.Image = Image.FromFile(caminhoImg);
            }


            if (passosAtual >= animacaoPassos)
            {
                timer1.Stop();

                string caminhoFinal = Path.Combine(pastaFotos, $"dado{faceFinal}.png");
                if (File.Exists(caminhoFinal))
                {
                    pictureBoxAtual.Image?.Dispose();
                    pictureBoxAtual.Image = Image.FromFile(caminhoFinal);
                }

                if (jogadorAtual == 1)
                {
                    historicoJogador1.Add(faceFinal);
                    vezJogador = 2;
                }
                else 
                {
                    historicoJogador2.Add(faceFinal);
                    vezJogador = 1;

                }


                AtualizarGridFixo();


                if (jogadorAtual == 2)
                {
                    rodadaAtual++;
                }


                ChecarFimDeJogo();
            }
        }
  
        private void AtualizarGridFixo()
        {

            if (rodadaAtual >= maxRodadas) return;


            if (jogadorAtual == 1)
            {
                int ultimoResultado = historicoJogador1[historicoJogador1.Count - 1];
                dataGridViewHistorico.Rows[rodadaAtual].Cells[0].Value = ultimoResultado;
            }
            else 
            {
                int ultimoResultado = historicoJogador2[historicoJogador2.Count - 1];
                dataGridViewHistorico.Rows[rodadaAtual].Cells[1].Value = ultimoResultado;
            }
        }

        private void ChecarFimDeJogo()
        {
            if (rodadaAtual >= maxRodadas)
            {
                int vitorias1 = 0;
                int vitorias2 = 0;
                int rodadasRegistradas = Math.Min(historicoJogador1.Count, historicoJogador2.Count);

                for (int i = 0; i < rodadasRegistradas; i++)
                {
                    if (historicoJogador1[i] > historicoJogador2[i]) vitorias1++;
                    else if (historicoJogador2[i] > historicoJogador1[i]) vitorias2++;
                }

                string vencedor;
                if (vitorias1 > vitorias2) vencedor = "Jogador 1 é o vencedor!";
                else if (vitorias2 > vitorias1) vencedor = "Jogador 2 é o vencedor!";
                else vencedor = "Empate!";

                MessageBox.Show(vencedor, "Fim de Jogo");

                rodadaAtual = 0;
                vezJogador = 1;
                historicoJogador1.Clear();
                historicoJogador2.Clear();


                foreach (DataGridViewRow row in dataGridViewHistorico.Rows)
                {
                    row.Cells[0].Value = null;
                    row.Cells[1].Value = null;
                }

                btnJogador1Normal.Enabled = true;
                btnJogador1Viciado.Enabled = true;
                btnJogador2Normal.Enabled = false;
                btnJogador2Viciado.Enabled = false;
            }
            else
            {
                if (vezJogador == 1)
                {
                    btnJogador1Normal.Enabled = true;
                    btnJogador1Viciado.Enabled = true;
                }
                else
                {
                    btnJogador2Normal.Enabled = true;
                    btnJogador2Viciado.Enabled = true;
                }
            }
        }
    }
}