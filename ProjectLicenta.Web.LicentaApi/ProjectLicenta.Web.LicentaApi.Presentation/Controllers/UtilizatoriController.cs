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
    public class UtilizatoriController
    {
        private readonly IUtilizatorService _service;
        private readonly ILogger<UtilizatoriController> _logger;

        public UtilizatoriController(IUtilizatorService service, ILogger<UtilizatoriController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Utilizator>> GetUtilizator([FromQuery] string toSearch, [FromQuery] Guid[] guids,
            [FromQuery] int pagination = 50, [FromQuery] int skip = 0)
        {
            try
            {
                return await _service.GetAllUtilizatori(toSearch, guids.ToList(), pagination, skip);
            }
            catch (ApiException exception)
            {
                exception.LogException(_logger);
                return null;
            }
            catch (Exception exception) when (exception.GetType() != typeof(ApiException))
            {
                _logger.LogCritical(exception, "Unhandled unexpected exception while retrieving utilizatori");
                return null;
            }
        }

        [HttpPost]
        [Route("/[controller]/add")]
        public async Task<bool> AddUtilizator([FromBody] List<Utilizator> utilizatorList)
        {
            var result = true;
            foreach (var utilizator in utilizatorList)
                try
                {
                    await _service.CreateUtilizator(utilizator);
                }
                catch (ApiException exception)
                {
                    exception.LogException(_logger);
                    result = false;
                }
                catch (Exception exception) when (exception.GetType() != typeof(ApiException))
                {
                    _logger.LogCritical(exception, $"Unhandled unexpected exception while creating a utilizator: {JsonConvert.SerializeObject(utilizator, Formatting.Indented)}");
                    result = false;
                }

            return result;
        }

        [HttpDelete]
        [Route("/[controller]/delete")]
        public async Task<bool> DeleteUtilizator([FromQuery] string toSearch, [FromQuery] Guid[] guids)
        {
            try
            {
                return await _service.DeleteUtilizator(toSearch, guids.ToList());
            }
            catch (ApiException exception)
            {
                exception.LogException(_logger);
            }
            catch (Exception exception) when (exception.GetType() != typeof(ApiException))
            {
                _logger.LogCritical(exception, "Unhandled unexpected exception while deleting a utilizator.");
            }

            return false;
        }


        [HttpPut]
        [Route("/[controller]/update")]
        public async Task<bool> UpdateUtilizator([FromBody] List<Utilizator> utilizatorList)
        {
            var result = true;
            foreach (var utilizator in utilizatorList)
                try
                {
                    await _service.UpdateUtilizator(utilizator);
                }
                catch (ApiException exception)
                {
                    exception.LogException(_logger);
                    result = false;
                }
                catch (Exception exception) when (exception.GetType() != typeof(ApiException))
                {
                    _logger.LogCritical(exception, $"Unhandled unexpected exception while updating a utilizator: {JsonConvert.SerializeObject(utilizator, Formatting.Indented)}");
                    result = false;
                }

            return result;
        }
    }
}