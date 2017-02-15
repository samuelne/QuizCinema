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
    public partial class Pergunta4 : Form
    {
        public int id_jogador_banco;
        public Pergunta4(int id_jogador)
        {
            InitializeComponent();
            id_jogador_banco = id_jogador;
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            

            if (rbnAlternativa3.Checked == true)
            {

                string pathServer = "Server = AME0556341W10-1\\SQLEXPRESS;";
                pathServer += "Database=db_QuizCinema;";
                pathServer += "Trusted_Connection=Yes;";

                int pontos = 10;
                string nivel = "dificil";

                string pathInsert = "INSERT INTO tb_perguntas ";
                pathInsert += "(pergunta, resposta_correta, nivel, pontos , id_jogador)";
                pathInsert += " VALUES ";
                pathInsert += " ( ";

                pathInsert += " '" + lblPergunta4.Text + "' ,";
                pathInsert += " '" + rbnAlternativa3.Text + "' ,";
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

                        //Mensagem Salvo no banco
                        //MessageBox.Show("Salvo no banco");

                        //FECHA A CONEXAO
                        conexao.Close();

                        this.Close();

                    }

                }


            }
            //MenuFinal final = new MenuFinal();
            //final.lblPontos.Text = " " + final.lblPontos.Text;
            
          //  final.Show();
            this.Close();
        }
    }
}
