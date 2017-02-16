using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuizCinema
{
    public partial class MenuFinal : Form
    {
        int pontos;
        public int id_jogador_banco;
        public int pontos_banco;
        public MenuFinal(int id_jogador)
            
        {
            InitializeComponent();

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
