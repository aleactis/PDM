using SQLite;
using AppContatoTeste.Models;

namespace AppContatoTeste.Datas
{
    public class SQLiteData
    {
        readonly SQLiteAsyncConnection bancodades;

        //Mapeamento das operações para a tabela
        public ContatoData Contatos { get; set; }

        public SQLiteData(string pasta)
        {
            //instancia o BD na memória
            bancodades = new SQLiteAsyncConnection(pasta);

            //Cria a tabela do BD
            bancodades.CreateTableAsync<Contato>().Wait();
            bancodades.CreateTableAsync<Endereco>().Wait();

            //Mapear as instancias das tabelas fazendo injeção de dependência
            Contatos = new ContatoData(bancodades);
        }
    }
}
