﻿using System;
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
    public partial class Pergunta3 : Form
    {
        public Pergunta3()
        {
            InitializeComponent();
        }

        private void btnPerg3_Click(object sender, EventArgs e)
        {

            string pathServer = "Server = AME0556341W10-1\\SQLEXPRESS;";
            pathServer += "Database=db_QuizCinema;";
            pathServer += "Trusted_Connection=Yes;";

            using (SqlConnection conexao = new SqlConnection(pathServer))
            {
                using (SqlCommand cmd = new SqlCommand("insert into tb_pergunta(id_jogador) OUTPUT INSERTED.ID values(@ID_JOGADOR)", conexao))
                {


                }

            }
            Pergunta4 perg4 = new Pergunta4();
            perg4.Show();
            this.Close();
        }
    }
}
