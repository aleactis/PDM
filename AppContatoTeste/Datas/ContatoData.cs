using AppContatoTeste.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppContatoTeste.Datas
{
    public class ContatoData
    {
        //Atributos
        List<Contato> listaContatos;
        //Acesso ao banco de dados
        SQLiteAsyncConnection bancodados;

        //Construtor
        public ContatoData(SQLiteAsyncConnection sqliteAsyncConnection)
        {
            //Instancia a lista na memória
            listaContatos = new List<Contato>();
            //Intancia o banco de dados em memória
            bancodados = sqliteAsyncConnection;
        }

        //Métodos auxiliares
        public IList<Contato> ListarContatos()
        {
            //Adicionar contatos na lista
            listaContatos.Add(
                new Contato()
                {
                    Nome = "Contato 1",
                    Email = "contato@teste.com.br",
                    Telefone = "(17) 99999-9999",
                    DataNascimento = Convert.ToDateTime("01/01/1986"),
                    Foto = @"http://lorempixel.com/32/32/sports/1"
                });
            listaContatos.Add(
                new Contato()
                {
                    Nome = "Contato 2",
                    Email = "contato@teste.com.br",
                    Telefone = "(17) 99999-9999",
                    DataNascimento = Convert.ToDateTime("01/01/1986"),
                    Foto = @"http://lorempixel.com/100/100/"
                });
            listaContatos.Add(
                new Contato()
                {
                    Nome = "Contato 3",
                    Email = "contato@teste.com.br",
                    Telefone = "(17) 99999-9999",
                    DataNascimento = Convert.ToDateTime("01/01/1986"),
                    Foto = @"http://lorempixel.com/100/100/"
                });
            listaContatos.Add(
                new Contato()
                {
                    Nome = "Contato 4",
                    Email = "contato@teste.com.br",
                    Telefone = "(17) 99999-9999",
                    DataNascimento = Convert.ToDateTime("01/01/1986"),
                    Foto = @"http://lorempixel.com/100/100/"
                });
            listaContatos.Add(
                new Contato()
                {
                    Nome = "Contato 5",
                    Email = "contato@teste.com.br",
                    Telefone = "(17) 99999-9999",
                    DataNascimento = Convert.ToDateTime("01/01/1986"),
                    Foto = @"http://lorempixel.com/100/100/"
                });

            return listaContatos;
        }

        public Task ListarContatoAsync()
        {
            //Tratamento de erros
            try
            {
                //Comando de consulta e retorna a lista de dados
                var select = bancodados.Table<Contato>().ToListAsync();
                return select;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public Task<int> InserirContatoAsync(Contato contato)
        {
            try
            {
                //Comando de inclusão de dados
                var insert = bancodados.InsertAsync(contato);
                return insert;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public Task AlterarContatoAsync(Contato contato)
        {
            try
            {
                //Comando de alteração de dados
                var update = bancodados.UpdateAsync(contato);
                return update;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public Task ExcluirContatoAsync(Contato contato)
        {
            try
            {
                //Comando de exclusão de dados
                var delete = bancodados.DeleteAsync(contato);
                return delete;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }

        }

        public Task BuscarContatoAsync(int id, string codigo)
        {
            try
            {
                //Comando de consulta e retorna a um registro de dados
                var select = bancodados
                    .Table<Contato>() //Tabela 
                    .Where(o => o.Codigo.Contains(codigo) || o.Id == id) //Codicao de filtro ||ou &&e
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
