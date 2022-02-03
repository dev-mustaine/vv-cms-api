using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Via.CMS.Domain;
using Via.CMS.Infra.Repository.Base.Mongo;
using Via.CMS.Infra.Repository.Interface;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Via.CMS.Infra.Repository
{
    public class FaqRepository : MongoRepository, IFaqRepository
    {
        #region Propriedades Privadas

        private readonly IMongoCollection<Faq> Collection;
        private int PageSize { get; set; }

        #endregion

        #region Construtores

        public FaqRepository(IConfiguration configuration, ILogger<FaqRepository> logger) : base(configuration)
        {
            Collection = Conexao.GetCollection<Faq>(nameof(Faq));
            PageSize = int.Parse(configuration["PageSize"]);
        }

        #endregion

        #region Métodos Publicos

        public async Task<List<Faq>> GetAll(int page = 0)
        {
            var filter = Builders<Faq>.Filter.Eq(x => x.DeletadoEm, null);
            var result = await Collection.Find(filter).Skip((page - 1) * page).Limit(PageSize).ToListAsync();
            return result;
        }

        public async Task<Faq> GetById(string _id)
        {
            var filter = Builders<Faq>.Filter.Eq(x => x._Id, ObjectId.Parse(_id)) & Builders<Faq>.Filter.Eq(x => x.DeletadoEm, null);
            var result = await Collection.Find(filter).SingleOrDefaultAsync();

            return result;
        }

        public async Task<List<Faq>> GetBySentenceFilter(string text, int page)
        {
            //var filter = Builders<Faq>.Filter.Eq(x => x.Titulo, text.ToLower()) & Builders<Faq>.Filter.Eq(x => x.DeletadoEm, null);
            var filter = Builders<Faq>.Filter.Regex("Titulo", text.ToLower()) & Builders<Faq>.Filter.Eq(x => x.DeletadoEm, null);
            var result = await Collection.Find(filter).Skip((page - 1) * page).Limit(PageSize).ToListAsync();
            return result;

        }

        public async Task InsertOne(Faq obj)
        {
            await Collection.InsertOneAsync(obj);
        }

        #endregion

    }
}
