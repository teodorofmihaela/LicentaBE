using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ProjectLicenta.Web.LicentaApi.Core.Exceptions;
using ProjectLicenta.Web.LicentaApi.Core.Interfaces;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CautariController
    {
        private readonly ICautareService _service;
        private readonly ILogger<CautariController> _logger;

        public CautariController(ICautareService service, ILogger<CautariController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Cautare>> GetCautare([FromQuery] string toSearch, [FromQuery] Guid[] guids,
            [FromQuery] int pagination = 50, [FromQuery] int skip = 0)
        {
            try
            {
                return await _service.GetAllCautari(toSearch, guids.ToList(), pagination, skip);
            }
            catch (ApiException exception)
            {
                exception.LogException(_logger);
                return null;
            }
            catch (Exception exception) when (exception.GetType() != typeof(ApiException))
            {
                _logger.LogCritical(exception, "Unhandled unexpected exception while retrieving cautari");
                return null;
            }
        }

        [HttpPost]
        [Route("/[controller]/add")]
        public async Task<bool> AddCautari([FromBody] List<Cautare> cautareList)
        {
            var result = true;
            foreach (var cautare in cautareList)
                try
                {
                    await _service.CreateCautare(cautare);
                }
                catch (ApiException exception)
                {
                    exception.LogException(_logger);
                    result = false;
                }
                catch (Exception exception) when (exception.GetType() != typeof(ApiException))
                {
                    _logger.LogCritical(exception, $"Unhandled unexpected exception while creating a cautare: {JsonConvert.SerializeObject(cautare, Formatting.Indented)}");
                    result = false;
                }

            return result;
        }

        [HttpDelete]
        [Route("/[controller]/delete")]
        public async Task<bool> DeleteCautare([FromQuery] string toSearch, [FromQuery] Guid[] guids)
        {
            try
            {
                return await _service.DeleteCautare(toSearch, guids.ToList());
            }
            catch (ApiException exception)
            {
                exception.LogException(_logger);
            }
            catch (Exception exception) when (exception.GetType() != typeof(ApiException))
            {
                _logger.LogCritical(exception, "Unhandled unexpected exception while deleting a cautare.");
            }

            return false;
        }


        [HttpPut]
        [Route("/[controller]/update")]
        public async Task<bool> UpdateCautare([FromBody] List<Cautare> cautareList)
        {
            var result = true;
            foreach (var cautare in cautareList)
                try
                {
                    await _service.UpdateCautare(cautare);
                }
                catch (ApiException exception)
                {
                    exception.LogException(_logger);
                    result = false;
                }
                catch (Exception exception) when (exception.GetType() != typeof(ApiException))
                {
                    _logger.LogCritical(exception, $"Unhandled unexpected exception while updating a cautare: {JsonConvert.SerializeObject(cautare, Formatting.Indented)}");
                    result = false;
                }

            return result;
        }
    }
}