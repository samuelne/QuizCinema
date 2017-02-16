using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizCinema
{
    public partial class MenuFinal : Form
    {
        public int id_jogador_banco;
        public int pontos_banco;
        public MenuFinal(int id_jogador, int pontos)
        {
            InitializeComponent();
            int ponto_banco = pontos;
        }


        private void btnJogarNovamente_Click(object sender, EventArgs e)
        {

            MenuInicial menu = new MenuInicial();
            menu.Show();
            this.Close();
        }

        private void btnEncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
