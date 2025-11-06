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

namespace Aprendendo_a_Contar
{
    public partial class jogo_contagem : Form
    {
        public jogo_contagem()
        {
            InitializeComponent();
        }
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

        private void button3_Click(object sender, EventArgs e)
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

            }
        }
        #endregion

        private void txt_joogador_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
