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
    public class AnunturiPrestateController
    {
        private readonly IAnuntPrestatService _service;
        private readonly ILogger<AnunturiPrestateController> _logger;

        public AnunturiPrestateController(IAnuntPrestatService service, ILogger<AnunturiPrestateController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<AnuntPrestat>> GetAnuntPrestat([FromQuery] string toSearch, [FromQuery] Guid[] guids,
            [FromQuery] int pagination = 50, [FromQuery] int skip = 0)
        {
            try
            {
                return await _service.GetAllAnunturiPrestate(toSearch, guids.ToList(), pagination, skip);
            }
            catch (ApiException exception)
            {
                exception.LogException(_logger);
                return null;
            }
            catch (Exception exception) when (exception.GetType() != typeof(ApiException))
            {
                _logger.LogCritical(exception, "Unhandled unexpected exception while retrieving anunturiPrestate");
                return null;
            }
        }

        [HttpPost]
        [Route("/[controller]/add")]
        public async Task<bool> AddAnuntPrestat([FromBody] List<AnuntPrestat> anuntPrestatList)
        {
            var result = true;
            foreach (var anuntPrestat in anuntPrestatList)
                try
                {
                    await _service.CreateAnuntPrestat(anuntPrestat);
                }
                catch (ApiException exception)
                {
                    exception.LogException(_logger);
                    result = false;
                }
                catch (Exception exception) when (exception.GetType() != typeof(ApiException))
                {
                    _logger.LogCritical(exception, $"Unhandled unexpected exception while creating a anuntPrestat: {JsonConvert.SerializeObject(anuntPrestat, Formatting.Indented)}");
                    result = false;
                }

            return result;
        }

        [HttpDelete]
        [Route("/[controller]/delete")]
        public async Task<bool> DeleteAnuntPrestat([FromQuery] string toSearch, [FromQuery] Guid[] guids)
        {
            try
            {
                return await _service.DeleteAnuntPrestat(toSearch, guids.ToList());
            }
            catch (ApiException exception)
            {
                exception.LogException(_logger);
            }
            catch (Exception exception) when (exception.GetType() != typeof(ApiException))
            {
                _logger.LogCritical(exception, "Unhandled unexpected exception while deleting a anuntPrestat.");
            }

            return false;
        }


        [HttpPut]
        [Route("/[controller]/update")]
        public async Task<bool> UpdateAnuntPrestat([FromBody] List<AnuntPrestat> anuntPrestatList)
        {
            var result = true;
            foreach (var anuntPrestat in anuntPrestatList)
                try
                {
                    await _service.UpdateAnuntPrestat(anuntPrestat);
                }
                catch (ApiException exception)
                {
                    exception.LogException(_logger);
                    result = false;
                }
                catch (Exception exception) when (exception.GetType() != typeof(ApiException))
                {
                    _logger.LogCritical(exception, $"Unhandled unexpected exception while updating a anuntPrestat: {JsonConvert.SerializeObject(anuntPrestat, Formatting.Indented)}");
                    result = false;
                }

            return result;
        }
    }
}