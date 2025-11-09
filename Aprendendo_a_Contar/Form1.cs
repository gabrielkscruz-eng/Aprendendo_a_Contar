using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;

namespace Aprendendo_a_Contar
{
    public partial class jogo_contagem : Form
    {
        public jogo_contagem()
        {
            InitializeComponent();
            atribuicao_img();
            txt_joogador.Enabled = false;
            txt_jogador2.Enabled = false;
            btn_iniciar.Enabled = false;

        }

        #region Vareaveis Globais
        
        Image[] img_array = new Image[30];
        int chute;
        bool vez_jogador1 = true;
        bool vez_jogador2 = false;
        bool acertou = false;
        int jogador1_pontos = 0;
        int jogador2_pontos = 0;
        int contador1 = 0;
        int contador2 = 0;
        // preservando sua lógica: listas por jogador para registrar índices já vistos
        List<int> listJog1 = new List<int>();
        List<int> listJog2 = new List<int>();

        // gerador único para evitar comportamento repetido por recriação do Random
        private Random rnd = new Random();
        #endregion

        #region load das img
        private void atribuicao_img()
        {
            for (int i = 0; i < 30; i++)
            {
                int f = (i / 3) + 1;       // muda a cada 3 imagens → 1 até 10
                int j = (i % 3) + 1;       // repete 1, 2, 3

                string caminho = Directory.GetCurrentDirectory() + "\\img_" + f + "_ (" + j + ").jpg";

                img_array[i] = Image.FromFile(caminho);
            }

        }


        #endregion

        #region Btn Autor
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Gabriel Kevin Ra: 24198 \nCaique Caruso Ra:240000", "Autores", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button2);
        }
        #endregion

        #region Lixo ou Acidente
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void txt_joogador_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void jogo_contagem_Load(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        #endregion

        #region Btn Sair
        private void jogo_contagem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Quer sair?", "Sair?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2)== DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region Troca do nome do jogador
        private void rtb_Ind_CheckedChanged(object sender, EventArgs e)
        {
            if (rtb_Ind.Checked == true)
            {
                gbx_jogador.Text = "Nome do jogador:";
                txt_joogador.Text = "Jogador 1";
                txt_joogador.Focus();
                txt_jogador2.Visible = false;
                vez_jogador2 = false;
                txt_joogador.Enabled = true;
                lbl_jogador2.Visible = false;
                lbl_pontos2.Visible = false;
                btn_iniciar.Enabled = true;
                
            }

        }

        private void rtb_dupla_CheckedChanged(object sender, EventArgs e)
        {
            if (rtb_dupla.Checked == true)
            {
                gbx_jogador.Text = "Nome do jogadores:";
                txt_jogador2.Visible = true;
                txt_joogador.Text = "Jogador 1"; txt_jogador2.Text = "Jogador 2";
                txt_joogador.Focus();
                vez_jogador2 = true;
                txt_joogador.Enabled = true;
                txt_jogador2.Enabled = true;
                lbl_jogador2.Visible = true;
                lbl_pontos2.Visible = true;
                btn_iniciar.Enabled = true;
                
            }
        }
        #endregion

        #region Btn Iniciar Jogo
        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_joogador.Text.Length == 0)
            {
                MessageBox.Show("Insira o nome do jogador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                txt_joogador.Focus();
                return;
            }
            else {
                if (txt_jogador2.Visible == true && txt_jogador2.Text.Length == 0)
                {
                    MessageBox.Show("Insira o nome do segundo jogador!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                    txt_jogador2.Focus();
                    return;
                }
                else
                {
                    // resetar estado ao iniciar/reiniciar
                    jogador1_pontos = 0;
                    jogador2_pontos = 0;
                    contador1 = 0;
                    contador2 = 0;
                    listJog1.Clear();
                    listJog2.Clear();
                    lbl_pontos1.Text = "0";
                    lbl_pontos2.Text = "0";

                    if (btn_iniciar.Text == "Iniciar")
                    {
                        MessageBox.Show("Início do jogo", "", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                        gerarNumeroAletorio();
                        btn_iniciar.Text = "Reiniciar";
                        
                    }
                    else
                    {
                        MessageBox.Show("Renício do jogo", "", MessageBoxButtons.OK, MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                        gerarNumeroAletorio();
                        lbl_pontos1.Text = "0";
                        lbl_pontos2.Text = "0";
                    }

                    if (rtb_dupla.Checked == true)
                    {
                        gbx_jogador.Text = "Vez de: " + txt_joogador.Text;
                    }else
                    {
                        gbx_jogador.Text = "Pode jogar: " + txt_joogador.Text;
                    }
                    txt_joogador.Enabled = false;
                    txt_jogador2.Enabled = false;   
                }
        }
        }
        #endregion

        #region numero aleatorio
        private void gerarNumeroAletorio()
        {
            
            pbx_imagens.Image = null;
            int numero;
            // usa rnd único para evitar repetição por recriação
            numero = rnd.Next(0, 30);
            pbx_imagens.Image = img_array[numero];
            return;

        }
        #endregion

        #region Btns de Chute

        private void button3_Click(object sender, EventArgs e)
        {
            rotina_btn(1);
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            rotina_btn(2);
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            rotina_btn(3);
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            rotina_btn(4);
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            rotina_btn(5);
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            rotina_btn(6);
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            rotina_btn(7);
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            rotina_btn(8);
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            rotina_btn(9);
        }

        private void btn_10_Click(object sender, EventArgs e)
        {
            rotina_btn(10);
        }

        #endregion

        #region função de verificação do chute

        private void verificar_chute(int chute)
        {
            // identifica índice da imagem exibida no array
            int idx = Array.IndexOf(img_array, pbx_imagens.Image);
            if (idx < 0)
            {
                MessageBox.Show("Imagem atual não foi identificada no conjunto de imagens.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // número esperado correspondente (1..10)
            int esperado = (idx / 3) + 1;

            // registra índice para o jogador atual (mantendo sua lógica) e evita duplicação
            if (vez_jogador1)
            {
                if (!listJog1.Contains(idx))
                {
                    listJog1.Add(idx);
                    contador1++;
                }
            }
            else if (vez_jogador2)
            {
                if (!listJog2.Contains(idx))
                {
                    listJog2.Add(idx);
                    contador2++;
                }
            }

            // verifica acerto
            if (chute == esperado)
            {
                // acerto
                if (vez_jogador1)
                {
                    jogador1_pontos++;
                    lbl_pontos1.Text = jogador1_pontos.ToString();

                    if (rtb_Ind.Checked)
                    {
                        gbx_jogador.Text = "Pode jogar: " + txt_joogador.Text;
                        // modo individual: mantém vez_jogador1 true
                    }
                    else if (rtb_dupla.Checked)
                    {
                        // alterna para jogador 2
                        vez_jogador1 = false;
                        vez_jogador2 = true;
                        gbx_jogador.Text = "Vez de: " + txt_jogador2.Text;
                    }
                }
                else if (vez_jogador2 && rtb_dupla.Checked)
                {
                    jogador2_pontos++;
                    lbl_pontos2.Text = jogador2_pontos.ToString();
                    // volta a vez para jogador1
                    vez_jogador2 = false;
                    vez_jogador1 = true;
                    gbx_jogador.Text = "Vez de: " + txt_joogador.Text;
                }

                MessageBox.Show("Acertou!");
                acertou = true;
            }
            else
            {
                // erro: mostra resposta correta e alterna vez em modo dupla
                MessageBox.Show($"Errou! A resposta correta é {esperado}.", "Resposta");
                acertou = false;

                if (rtb_Ind.Checked)
                {
                    gbx_jogador.Text = "Pode jogar: " + txt_joogador.Text;
                }
                else if (rtb_dupla.Checked)
                {
                    if (vez_jogador1)
                    {
                        vez_jogador1 = false;
                        vez_jogador2 = true;
                        gbx_jogador.Text = "Vez de: " + txt_jogador2.Text;
                    }
                    else
                    {
                        vez_jogador2 = false;
                        vez_jogador1 = true;
                        gbx_jogador.Text = "Vez de: " + txt_joogador.Text;
                    }
                }
            }
        }

        #endregion

        #region rotina btn

        private void rotina_btn(int chute)
        {
            // verifica fim antes de executar a jogada
            if (contador1 >= 10 || contador2 >= 10)
            {
                FinalizarJogo();
                return;
            }

            // executa a verificação do chute
            verificar_chute(chute);

            // se após o chute alguém atingiu o limite, finaliza sem gerar nova imagem
            if (contador1 >= 10 || contador2 >= 10)
            {
                FinalizarJogo();
                return;
            }

            // caso contrário, prossegue com próxima imagem
            gerarNumeroAletorio();
        }
        #endregion

        #region Finalizar Jogo  

        private void FinalizarJogo()
        {
            string vencedor;
            if (jogador1_pontos > jogador2_pontos)
            {
                vencedor = txt_joogador.Text;
            }
            else if (jogador2_pontos > jogador1_pontos)
            {
                vencedor = txt_jogador2.Text;
            }
            else
            {
                vencedor = "Empate!";
            }
            MessageBox.Show($"Fim de jogo! O vencedor é: {vencedor}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // opcional: bloquear botões de chute (mantive comentado)
            // btn_iniciar.Enabled = true;
            // foreach (Control c in this.Controls) if (c is Button b && b.Name.StartsWith("btn_")) b.Enabled = false;
        }

        #endregion
    }
}
