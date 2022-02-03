using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Via.CMS.Domain.Models;

namespace Via.CMS.API.Controllers
{
    public abstract class AbstractController<R> : ControllerBase
    {
        private readonly ILogger<R> logger;
        private readonly IConfiguration configuration;

        public AbstractController(ILogger<R> logger, IConfiguration configuration)
        {
            this.logger = logger;
            this.configuration = configuration;
        }

        protected async Task<ObjectResult> Execute<T>(Func<Task<Result<T>>> func)
        {
            try
            {
                var task = await func();
                return StatusCodeFromResult(task);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(400, Result<T>.CreateFailure(ex.Message));
            }
            catch (Exception ex)
            {
                logger.LogError($"{ex.Message} onde ocorreu {ex.StackTrace}");
                return StatusCode(500, Result<T>.CreateFailure($"{ex.Message} onde ocorreu {ex.StackTrace}"));
            }
        }

        protected int GetTimeoutTime()
        {
            string config = configuration.GetSection($"TimeoutTimeInMs").Value;

            int.TryParse(config, out int time);

            if (time <= 0)
                time = 10000;

            return time;
        }

        protected ObjectResult StatusCodeFromResult<T>(Result<T> result)
        {
            int statusCode;
            if (result.Success)
            {
                statusCode = 200;
                return StatusCode(statusCode, result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
