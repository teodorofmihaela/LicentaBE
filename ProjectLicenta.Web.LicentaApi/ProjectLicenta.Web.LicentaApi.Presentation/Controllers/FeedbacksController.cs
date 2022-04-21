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
    public class FeedbacksController
    {
        private readonly IFeedbackService _service;
        private readonly ILogger<FeedbacksController> _logger;

        public FeedbacksController(IFeedbackService service, ILogger<FeedbacksController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Feedback>> GetFeedback([FromQuery] string toSearch, [FromQuery] Guid[] guids,
            [FromQuery] int pagination = 50, [FromQuery] int skip = 0)
        {
            try
            {
                return await _service.GetAllFeedbacks(toSearch, guids.ToList(), pagination, skip);
            }
            catch (ApiException exception)
            {
                exception.LogException(_logger);
                return null;
            }
            catch (Exception exception) when (exception.GetType() != typeof(ApiException))
            {
                _logger.LogCritical(exception, "Unhandled unexpected exception while retrieving feedbacks");
                return null;
            }
        }

        [HttpPost]
        [Route("/[controller]/add")]
        public async Task<bool> AddFeedback([FromBody] List<Feedback> feedbackList)
        {
            var result = true;
            foreach (var feedback in feedbackList)
                try
                {
                    await _service.CreateFeedback(feedback);
                }
                catch (ApiException exception)
                {
                    exception.LogException(_logger);
                    result = false;
                }
                catch (Exception exception) when (exception.GetType() != typeof(ApiException))
                {
                    _logger.LogCritical(exception, $"Unhandled unexpected exception while creating a feedback: {JsonConvert.SerializeObject(feedback, Formatting.Indented)}");
                    result = false;
                }

            return result;
        }

        [HttpDelete]
        [Route("/[controller]/delete")]
        public async Task<bool> DeleteFeedback([FromQuery] string toSearch, [FromQuery] Guid[] guids)
        {
            try
            {
                return await _service.DeleteFeedback(toSearch, guids.ToList());
            }
            catch (ApiException exception)
            {
                exception.LogException(_logger);
            }
            catch (Exception exception) when (exception.GetType() != typeof(ApiException))
            {
                _logger.LogCritical(exception, "Unhandled unexpected exception while deleting a feedback.");
            }

            return false;
        }


        [HttpPut]
        [Route("/[controller]/update")]
        public async Task<bool> UpdateFeedback([FromBody] List<Feedback> feedbackList)
        {
            var result = true;
            foreach (var feedback in feedbackList)
                try
                {
                    await _service.UpdateFeedback(feedback);
                }
                catch (ApiException exception)
                {
                    exception.LogException(_logger);
                    result = false;
                }
                catch (Exception exception) when (exception.GetType() != typeof(ApiException))
                {
                    _logger.LogCritical(exception, $"Unhandled unexpected exception while updating a feedback: {JsonConvert.SerializeObject(feedback, Formatting.Indented)}");
                    result = false;
                }

            return result;
        }
    }
}