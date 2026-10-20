using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.classes
{
    internal class Empregado
    {
       public int Matricula { get; set; } = 0;
        public string? Nome { get; set; }
        public string? CPF { get; set; }

        public string? Endereco { get; set; }


        public Empregado(int matricula, string? nome, string? cpf, string? endereco)
        {
            
            Nome = nome;
            CPF = cpf;
            Endereco = endereco;
        }

        public override string ToString()
        {
            return  $"Empregado -> Matricula: {Matricula} | CPF: {CPF}" + $"Nome: {Nome} |  Endereco: {Endereco}";
        }


        public void Salvar(SqlConnection conexao)
        {
          Console.WriteLine("Salvando empregado no banco de dados...");
            if (Matricula == 0) {
                var Cmd = conexao.CreateCommand();
                Cmd.CommandText = "INSERT INTO Empregado (Nome, CPF, Endereco) VALUES (@Nome, @CPF, @Endereco)";
                Cmd.Parameters.Add(new SqlParameter("@Nome", Nome));
                Cmd.Parameters.Add(new SqlParameter("@CPF", CPF));
                Cmd.Parameters.Add(new SqlParameter("@Endereco", Endereco));

                Cmd.ExecuteNonQuery();
            }
        }
    }
}
