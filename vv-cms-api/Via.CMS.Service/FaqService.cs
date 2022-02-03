using System.Collections.Generic;
using System.Threading.Tasks;
using Via.CMS.Business;
using Via.CMS.Business.Business;
using Via.CMS.Domain;
using Via.CMS.Domain.Models;
using Via.CMS.DTO;
using Via.CMS.Infra.Repository.Interface;
using Via.CMS.Service.Interface;

namespace Via.CMS.Service
{
    public class FaqService : IFaqService
    {

        #region Propriedades Privadas

        private readonly IFaqBusiness FaqBusiness;

        #endregion


        #region Construtores

        public FaqService(IFaqBusiness faqBusiness)
        {
            FaqBusiness = faqBusiness;
        }

        #endregion


        #region Métodos Publicos

        public async Task<Result<List<FAQComponentDTO>>> Listar(int page)
        {
            var result = await FaqBusiness.ListaComPaginacao(page);
            return Result<List<FAQComponentDTO>>.CreateSuccess(result);
        }

        public async Task<Result<FAQComponentDTO>> RetornarPorId(string id)
        {
            var result = await FaqBusiness.RetornarPorId(id);
            return Result<FAQComponentDTO>.CreateSuccess(result);
        }

        public async Task<Result<List<FAQComponentDTO>>> FiltrarPorTitulo(string text, int page)
        {
            var result = await FaqBusiness.FiltrarPorTitulo(text, page);
            return Result<List<FAQComponentDTO>>.CreateSuccess(result);
        }


        #endregion
    }
}
