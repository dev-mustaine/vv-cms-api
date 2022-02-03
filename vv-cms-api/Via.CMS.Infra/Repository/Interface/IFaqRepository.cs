using System.Collections.Generic;
using System.Threading.Tasks;
using Via.CMS.Domain;

namespace Via.CMS.Infra.Repository.Interface
{
    public interface IFaqRepository
    {
        Task<List<Faq>> GetAll(int page = 0);
        Task<Faq> GetById(string _id);
        Task<List<Faq>> GetBySentenceFilter(string text, int page);
        Task InsertOne(Faq document);
    }
}
