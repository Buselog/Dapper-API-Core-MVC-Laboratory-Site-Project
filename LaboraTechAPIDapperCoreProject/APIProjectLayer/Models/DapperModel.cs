using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace APIProjectLayer.Models
{
    public class DapperModel
    {

        private readonly string _connectionString;
        public DapperModel(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }


        // Ekleme silme güncelleme
        //Sadece işlem yapar ama geriye nesne ya da liste dönmez.

        /*
         Task sadece “bir işi yap ve bitir” anlamına gelir.
         Hiçbir şey döndürmek zorunda değildir.
         Aynı void gibidir ama await edilebilir versiyonudur. Api için void değil, Task tipi daha doğrudur.
         Task<T> -> return olması gerekir
         */
        public async Task Operations(string procedureName, DynamicParameters parameters = null)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                await db.OpenAsync();
                await db.ExecuteAsync(procedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        //DynamicParameters, used with Dapper library
        //Veri listelemek (SELECT)
        //Belirli kriterlere göre veri sorgulamak
        //Geriye bir nesne listesi(IEnumerable<T>) döndürmek
        public async Task<IEnumerable<T>> List<T>(string procedureName, DynamicParameters parameters = null)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                await db.OpenAsync();
                return await db.QueryAsync<T>(procedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }


        // İlişkili tablolar için Map fonksiyonu, gerekli Controller'da bunu kullanacağız:

        public async Task<IEnumerable<T1>> MultiMap<T1, T2>(
          string procedureName,
          Func<T1, T2, T1> map,
          string splitOn,
          DynamicParameters parameters = null)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                await db.OpenAsync();
                return await db.QueryAsync<T1, T2, T1>(
                    procedureName,
                    map,
                    splitOn: splitOn,
                    param: parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }

        public async Task<int> ExecuteScalarIntAsync(string procedureName, DynamicParameters parameters = null)
        {
            using (SqlConnection db = new SqlConnection(_connectionString))
            {
                await db.OpenAsync();
                return await db.ExecuteScalarAsync<int>(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }


    }
}
