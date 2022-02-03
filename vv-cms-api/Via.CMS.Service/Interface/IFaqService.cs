using System.Collections.Generic;
using System.Threading.Tasks;
using Via.CMS.Domain;
using Via.CMS.Domain.Models;
using Via.CMS.DTO;

namespace Via.CMS.Service.Interface
{
    public interface IFaqService
    {
        Task<Result<List<FAQComponentDTO>>> Listar(int page);
        Task<Result<FAQComponentDTO>> RetornarPorId(string id);
        Task<Result<List<FAQComponentDTO>>> FiltrarPorTitulo(string text, int page);
    }
}
