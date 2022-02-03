using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Via.CMS.API.Results;
using Via.CMS.Domain.Models;
using Via.CMS.DTO;
using Via.CMS.Service;
using Via.CMS.Service.Interface;

namespace Via.CMS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FaqController : AbstractController<FaqController>
    {

        #region Propriedades Publicas

        public IFaqService FaqService;

        #endregion

        #region Construtores

        public FaqController(IFaqService faqService, ILogger<FaqController> logger, IConfiguration configuration) : base(logger, configuration)
        {
            FaqService = faqService;
        }

        #endregion

        #region Métodos Publicos


        [ProducesResponseType(typeof(Result<FaqResponse>), 200)]
        [ProducesResponseType(typeof(Result<FaqResponse>), 400)]
        [ProducesResponseType(typeof(Result<FaqResponse>), 404)]
        [ProducesResponseType(typeof(Result<FaqResponse>), 500)]
        [HttpGet]
        [Route("{page}")]
        public async Task<ActionResult<FaqResponse>> Get(int page)
        {
            return await Execute(async () => await FaqService.Listar(page));
        }


        [ProducesResponseType(typeof(Result<FaqResponse>), 200)]
        [ProducesResponseType(typeof(Result<FaqResponse>), 400)]
        [ProducesResponseType(typeof(Result<FaqResponse>), 404)]
        [ProducesResponseType(typeof(Result<FaqResponse>), 500)]
        [HttpGet]
        [Route("ById/{id}")]
        public async Task<ActionResult<FaqResponse>> GetById(string id)
        {
            return await Execute(async () => await FaqService.RetornarPorId(id));
        }

        [ProducesResponseType(typeof(Result<FaqResponse>), 200)]
        [ProducesResponseType(typeof(Result<FaqResponse>), 400)]
        [ProducesResponseType(typeof(Result<FaqResponse>), 404)]
        [ProducesResponseType(typeof(Result<FaqResponse>), 500)]
        [HttpGet]
        [Route("FilterByTitle/{text}/{page}")]
        public async Task<ActionResult<FaqResponse>> FilterByTitle(string text, int page)
        {
            return await Execute(async () => await FaqService.FiltrarPorTitulo(text, page));
        }

        [ProducesResponseType(typeof(Result<FaqResponse>), 400)]
        [ProducesResponseType(typeof(Result<FaqResponse>), 404)]
        [ProducesResponseType(typeof(Result<FaqResponse>), 500)]
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<FaqResponse>> Create([FromBody]FAQComponentDTO faq)
        {
            return Ok();
            //return await Execute(async () => await FaqService.FiltrarPorTitulo(text, page));
        }

        [ProducesResponseType(typeof(Result<FaqResponse>), 400)]
        [ProducesResponseType(typeof(Result<FaqResponse>), 404)]
        [ProducesResponseType(typeof(Result<FaqResponse>), 500)]
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<FaqResponse>> Update([FromBody] FAQComponentDTO faq)
        {
            return Ok();
            //return await Execute(async () => await FaqService.FiltrarPorTitulo(text, page));
        }

        [ProducesResponseType(typeof(Result<FaqResponse>), 400)]
        [ProducesResponseType(typeof(Result<FaqResponse>), 404)]
        [ProducesResponseType(typeof(Result<FaqResponse>), 500)]
        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult<FaqResponse>> Delete(string id)
        {
            return Ok();
            //return await Execute(async () => await FaqService.FiltrarPorTitulo(text, page));
        }

        #endregion

    }
}
