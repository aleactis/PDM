using SQLite;
using System;

namespace AppContatoTeste.Models
{
    //Nome da tabea
    [Table("Contatos")]

    public class Contato
    {
        //Chave primária da tabela
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //Atributo
        string nome;
        //Propriedade
        public string Codigo { get; set; }

        [MaxLength(50)]
        public string Nome { get => nome; set => nome = value; }

        //Atributo + Propriedade
        public string Email { get; set; }
        public string Telefone { get; set; }
        public bool Favorito { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Foto { get; set; }
        public string Site { get; set; }

        //Métodos construtor
        public Contato()
        {
            //Inicializa propriedades com valor padrão
            Codigo = Guid.NewGuid().ToString(); //Codigo automatico
            Favorito = false;
        }

        //Métodos auxiliares
        public bool Validar()
        {
            bool retorno;
            //Verifica se foi preenchido o nome
            if (nome.Length > 0)
            {
                retorno = true;
            }
            else if (Email.Length > 0)
            {
                retorno = true;
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }

    }
}