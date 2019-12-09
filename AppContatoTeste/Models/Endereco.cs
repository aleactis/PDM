using SQLite;
using System;

namespace AppContatoTeste.Models
{
    //Nome da tabela
    [Table("Enderecos")]

    public class Endereco
    {
        //Chave primaria da tabela
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        //Relacinamento com a tabela de contatos
        [Indexed]
        public int ContatoId { get; set; }

        //Propriedades
        public Guid Codigo { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }

        //Metodo construtor
        public Endereco()
        {
            Codigo = Guid.NewGuid();
        }
    }
}
