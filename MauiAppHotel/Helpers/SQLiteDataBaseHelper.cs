using MauiAppHotel.Models;
using SQLite;

namespace MauiAppHotel.Helpers
{
    public class SQLiteDataBaseHelper
    {
        //Habilita uma conexão com o banco de dados.
        readonly SQLiteAsyncConnection __conn;

        //Iniciar a conexão com o banco no construtor
        public SQLiteDataBaseHelper(string path)
        {
            __conn = new SQLiteAsyncConnection(path);
            __conn.CreateTableAsync<Hospedagem>().Wait();
            __conn.CreateTableAsync<Quarto>().Wait();
            __conn.CreateTableAsync<Historico>().Wait();
        }

        //Metodos de manipulação de dados recebem o produto como parametros
        public Task<int> Insert(Historico h)
        {
            return __conn.InsertAsync(h);
        }

        public Task<List<Historico>> GetAll()
        {
            return __conn.Table<Historico>().ToListAsync();
        }
         
    }
}
