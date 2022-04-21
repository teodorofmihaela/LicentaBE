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
    public class UtilizatoriFavoritiController
    {
        private readonly IUtilizatorFavoritService _service;
        private readonly ILogger<UtilizatoriFavoritiController> _logger;

        public UtilizatoriFavoritiController(IUtilizatorFavoritService service, ILogger<UtilizatoriFavoritiController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<UtilizatorFavorit>> GetUtilizatorFavorit([FromQuery] string toSearch, [FromQuery] Guid[] guids,
            [FromQuery] int pagination = 50, [FromQuery] int skip = 0)
        {
            try
            {
                return await _service.GetAllUtilizatoriFavoriti(toSearch, guids.ToList(), pagination, skip);
            }
            catch (ApiException exception)
            {
                exception.LogException(_logger);
                return null;
            }
            catch (Exception exception) when (exception.GetType() != typeof(ApiException))
            {
                _logger.LogCritical(exception, "Unhandled unexpected exception while retrieving utilizatoriFavoriti");
                return null;
            }
        }

        [HttpPost]
        [Route("/[controller]/add")]
        public async Task<bool> AddUtilizatorFavorit([FromBody] List<UtilizatorFavorit> utilizatorFavoritList)
        {
            var result = true;
            foreach (var utilizatorFavorit in utilizatorFavoritList)
                try
                {
                    await _service.CreateUtilizatorFavorit(utilizatorFavorit);
                }
                catch (ApiException exception)
                {
                    exception.LogException(_logger);
                    result = false;
                }
                catch (Exception exception) when (exception.GetType() != typeof(ApiException))
                {
                    _logger.LogCritical(exception, $"Unhandled unexpected exception while creating a utilizatorFavorit: {JsonConvert.SerializeObject(utilizatorFavorit, Formatting.Indented)}");
                    result = false;
                }

            return result;
        }

        [HttpDelete]
        [Route("/[controller]/delete")]
        public async Task<bool> DeleteUtilizatorFavorit([FromQuery] string toSearch, [FromQuery] Guid[] guids)
        {
            try
            {
                return await _service.DeleteUtilizatorFavorit(toSearch, guids.ToList());
            }
            catch (ApiException exception)
            {
                exception.LogException(_logger);
            }
            catch (Exception exception) when (exception.GetType() != typeof(ApiException))
            {
                _logger.LogCritical(exception, "Unhandled unexpected exception while deleting a utilizatorFavorit.");
            }

            return false;
        }


        [HttpPut]
        [Route("/[controller]/update")]
        public async Task<bool> UpdateUtilizatorFavorit([FromBody] List<UtilizatorFavorit> utilizatorFavoritList)
        {
            var result = true;
            foreach (var utilizatorFavorit in utilizatorFavoritList)
                try
                {
                    await _service.UpdateUtilizatorFavorit(utilizatorFavorit);
                }
                catch (ApiException exception)
                {
                    exception.LogException(_logger);
                    result = false;
                }
                catch (Exception exception) when (exception.GetType() != typeof(ApiException))
                {
                    _logger.LogCritical(exception, $"Unhandled unexpected exception while updating a utilizatorFavorit: {JsonConvert.SerializeObject(utilizatorFavorit, Formatting.Indented)}");
                    result = false;
                }

            return result;
        }
    }
}