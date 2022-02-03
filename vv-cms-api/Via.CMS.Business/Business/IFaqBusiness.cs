using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Via.CMS.DTO;

namespace Via.CMS.Business.Business
{
    public interface IFaqBusiness
    {
        Task<List<FAQComponentDTO>> ListaComPaginacao(int page);
        Task<FAQComponentDTO> RetornarPorId(string id);
        Task<List<FAQComponentDTO>> FiltrarPorTitulo(string texto, int page);
    }
}
