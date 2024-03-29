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
    public partial class Pergunta2 : Form
    {
        public int id_jogador_banco;
        public Pergunta2(int id_jogador)
        {
            InitializeComponent();
            id_jogador_banco = id_jogador;
        }

        private void btnPerg2_Click(object sender, EventArgs e)
        {
            if (rbnAlternativa4.Checked == true)
            {

                string pathServer = "Server = DESKTOP-V7V5L0R\\SQLEXPRESS;";
                pathServer += "Database=db_QuizCinema;";
                pathServer += "Trusted_Connection=Yes;";

                int pontos = 10;
                string nivel = "Moderado";

                string pathInsert = "INSERT INTO tb_perguntas ";
                pathInsert += "(pergunta, resposta_correta, nivel, pontos , id_jogador)";
                pathInsert += " VALUES ";
                pathInsert += " ( ";

                pathInsert += " '" + lblPergunta2.Text + "' ,";
                pathInsert += " '" + rbnAlternativa4.Text + "' ,";
                pathInsert += " '" + nivel + "' ,";
                pathInsert += " '" + pontos + "' ,";
                pathInsert += " '" + id_jogador_banco + "' ";

                pathInsert += " ) ";

                using (SqlConnection conexao = new SqlConnection(pathServer))
                {
                    using (SqlCommand cmd = new SqlCommand(pathInsert, conexao))
                    {
                        //ABRE A CONEXAO
                        conexao.Open();

                        //PASSA O COMANDO INSERT COMPLETO
                        cmd.CommandText = pathInsert;

                        //EXECUTA O INSERT
                        cmd.ExecuteNonQuery();

                        //FECHA A CONEXAO
                        conexao.Close();

                        this.Close();

                    }

                }


            }

            this.Close();

        }
    }
}
