using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Via.CMS.Business.Business;
using Via.CMS.DTO;
using Via.CMS.Infra.Repository.Interface;

namespace Via.CMS.Business
{
    public class FaqBusiness : IFaqBusiness
    {
        #region Propriedades Privadas

        private readonly IFaqRepository FaqRepository;

        #endregion

        #region Construtores

        public FaqBusiness(IFaqRepository faqRepository)
        {
            FaqRepository = faqRepository;
        }

        #endregion

        #region Métodos Publicos

        public async Task<List<FAQComponentDTO>> ListaComPaginacao(int page)
        {
            var result = new List<FAQComponentDTO>();

            if (page == 0)
                page = 1;


            var entitys = await FaqRepository.GetAll(page);

            foreach (var entity in entitys)
            {
                var component = new FAQComponentDTO
                {
                    Id = entity._Id.ToString(),
                    Titulo = entity.Titulo,
                    Bandeira = entity.Bandeira,
                    CriadoEm = entity.CriadoEm,
                    AlteradoEm = entity.AlteradoEm,
                    Filtro = entity.Filtro
                };

                if (entity.Faqs != null && entity.Faqs.Count > 0)
                    entity.Faqs.ForEach(faq =>
                    {
                        component.Faqs.Add(new FAQItemDTO
                        {
                            Ask = faq.Ask,
                            Answer = faq.Answer
                        });
                    });

                result.Add(component);

            }

            return result;
        }

        public async Task<FAQComponentDTO> RetornarPorId(string id)
        {
            var result = new FAQComponentDTO();

            var entity = await FaqRepository.GetById(id);

            if (entity != null)
            {

                result = new FAQComponentDTO
                {
                    Id = entity._Id.ToString(),
                    Titulo = entity.Titulo,
                    Bandeira = entity.Bandeira,
                    CriadoEm = entity.CriadoEm,
                    AlteradoEm = entity.AlteradoEm,
                    Filtro = entity.Filtro
                };

                if (entity.Faqs != null && entity.Faqs.Count > 0)
                    entity.Faqs.ForEach(faq =>
                    {
                        result.Faqs.Add(new FAQItemDTO
                        {
                            Ask = faq.Ask,
                            Answer = faq.Answer
                        });
                    });
            }

            return result;

        }

        public async Task<List<FAQComponentDTO>> FiltrarPorTitulo(string texto, int page)
        {
            var result = new List<FAQComponentDTO>();

            if (page == 0)
                page = 1;

            var entitys = await FaqRepository.GetBySentenceFilter(texto, page);

            if (entitys != null && entitys.Count > 0)
            {
                foreach (var entity in entitys)
                {
                    var component = new FAQComponentDTO
                    {
                        Id = entity._Id.ToString(),
                        Titulo = entity.Titulo,
                        Bandeira = entity.Bandeira,
                        CriadoEm = entity.CriadoEm,
                        AlteradoEm = entity.AlteradoEm,
                        Filtro = entity.Filtro
                    };

                    if (entity.Faqs != null && entity.Faqs.Count > 0)
                        entity.Faqs.ForEach(faq =>
                        {
                            component.Faqs.Add(new FAQItemDTO
                            {
                                Ask = faq.Ask,
                                Answer = faq.Answer
                            });
                        });

                    result.Add(component);

                }
            }

            return result;

        }

        #endregion

        #region Propriedades Privadas

        #endregion

    }
}
