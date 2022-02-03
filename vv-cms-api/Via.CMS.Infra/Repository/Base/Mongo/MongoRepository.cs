using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Via.CMS.Infra.Repository.Base.Mongo
{
    public class MongoRepository
    {
        #region Propriedades Privadas

        protected readonly IMongoDatabase Conexao;

        private readonly IConfiguration Configuration;

        #endregion

        #region Construtores

        public MongoRepository(IConfiguration configuration)
        {
            Configuration = configuration;
            Conexao = CriarConexaoMongo();
        }

        #endregion

        #region Métodos Publicos
        #endregion

        #region Métodos Privados

        private IMongoDatabase CriarConexaoMongo()
        {
            var connectionString = Configuration[$"MONGO_CMS_SERVER"];
            var client = new MongoClient(connectionString);
            var databaseName = Configuration["MONGO_DATABASE"];

            return client.GetDatabase(databaseName);
        }

        #endregion

    }
}
