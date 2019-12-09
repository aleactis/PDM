using AppContatoTeste.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AppContatoTeste.Datas
{
    class EnderecoData
    {
        //Atributos
        List<Endereco> listaContatos;
        //Acesso ao banco de dados
        SQLiteAsyncConnection bancodados;

        //Metodo construtor
        public EnderecoData(SQLiteAsyncConnection sqliteAsyncConnection)
        {
            //Instancia a lista em memoria
            listaContatos = new List<Endereco>();

            //Instancia o banco de dados em memoria
            bancodados = sqliteAsyncConnection;
        }

        //Metodos auxiliares

        public Task<List<Endereco>> ListarAsync()
        {
            //Tratamento de erros
            try
            {
                //Comando de consulta e retorna a lista de dados
                var select = bancodados.Table<Endereco>().ToListAsync();
                return select;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public Task<int> InserirAsync(Endereco endereco)
        {
            try
            {
                //Comando de inclusão de dados
                var insert = bancodados.InsertAsync(endereco);
                return insert;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public Task AlterarAsync(Endereco endereco)
        {
            try
            {
                //Comando de alteração de dados
                var update = bancodados.UpdateAsync(endereco);
                return update;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public Task ExcluirAsync(Endereco endereco)
        {
            try
            {
                //Comando de exclusão de dados
                var delete = bancodados.DeleteAsync(endereco);
                return delete;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public Task<Endereco> BuscarAsync(int id, Guid codigo)
        {
            try
            {
                //Comando de consulta e retorna a um registro de dados
                var select = bancodados
                    .Table<Endereco>() //Tabela 
                    .Where(o => o.Codigo == codigo || o.Id == id) //Codicao de filtro ||ou &&e
                    .FirstOrDefaultAsync(); //Tipo de retorno
                return select;
            }
            catch (Exception erro)
            {
                //throw new Exception(erro.Message);
                //Faz o log do erro e nao trava a execucao do aplicativo
                Debug.WriteLine($"Erro: {erro.Message}");
                return null;
            }
        }
    }
}
