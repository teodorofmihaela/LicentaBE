using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Interfaces;
using ProjectLicenta.Web.LicentaApi.Core.Models;
using Microsoft.Extensions.Logging;
using ProjectLicenta.Web.LicentaApi.Core.Enums;
using ProjectLicenta.Web.LicentaApi.Core.Exceptions;
using ProjectLicenta.Web.LicentaApi.Core.Extensions;
using ProjectLicenta.Web.LicentaApi.Core.Filters;
using ProjectLicenta.Web.LicentaApi.Core.Validators;

namespace ProjectLicenta.Web.LicentaApi.Core.Services
{
    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository _repository;
        private IFeedbackValidator _feedbackValidator;
        private const int MaxPagination = 9999;

        public FeedbackService(IFeedbackRepository repository, IFeedbackValidator feedbackValidator)
        {
            _repository = repository;
            _feedbackValidator = feedbackValidator;
        }

        public async Task<List<Feedback>> GetAllFeedbacks(string toSearch, List<Guid> guids, int pagination = 50, int skip = 0)
        {
            return await _repository.GetAllFeedbacks(
                new FeedbackFilter() {ToSearch = toSearch, Ids = guids}, pagination, skip);
        }

        public async Task<bool> CreateFeedback(Feedback inputFeedback)
        {
            _feedbackValidator.Validate(inputFeedback);
            // var nameAlikeFeedbacks = await _repository.GetAllFeedbacks(
            //     new FeedbackFilter {ToSearch = inputFeedback.Titlu,}, MaxPagination);

            var idAlikeFeedbacks = await _repository.GetAllFeedbacks(
                new FeedbackFilter {Ids = new List<Guid>() {inputFeedback.Id}}, MaxPagination);

            if (idAlikeFeedbacks.Any())
                throw new ApiException
                {
                    ExceptionMessage = "Feedback already exists in the repository !",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };

            // if (nameAlikeFeedbacks.Any())
            //     throw new ApiException
            //     {
            //         ExceptionMessage = "Feedback name is not unique !",
            //         Severity = ExceptionSeverity.Error,
            //         Type = ExceptionType.ServiceException
            //     };
            return await _repository.CreateFeedback(inputFeedback);
        }

        public async Task<bool> DeleteFeedback(string toSearch, List<Guid> guids)
        {
            var feedbacksToDelete = await _repository.GetAllFeedbacks(
                new FeedbackFilter {ToSearch = toSearch, Ids = guids, PerfectMatch = true}, MaxPagination);

            if (!feedbacksToDelete.Any())
                throw new ApiException
                {
                    ExceptionMessage = "Feedback is not in the repository.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            var result = true;

            foreach (var feedback in feedbacksToDelete)
                result = result && await _repository.DeleteFeedback(feedback.Id);
            return result;
        }

        public async Task<bool> UpdateFeedback(Feedback inputFeedback)
        {
            _feedbackValidator.Validate(inputFeedback);

            var sameIdFeedbacks =
                await _repository.GetAllFeedbacks(new FeedbackFilter {Ids = new List<Guid> {inputFeedback.Id}});

            if (sameIdFeedbacks.Count != 1)
                throw new ApiException
                {
                    ExceptionMessage = $"Feedback with id {inputFeedback.Id} to update has not been found.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ServiceException
                };
            // if (inputFeedback.Nume != sameIdFeedbacks.First().Nume)
            // {
            //     var sameNumeFeedbacks = await _repository.GetAllFeedbacks(
            //         new FeedbackFilter {ToSearch = inputFeedback.Nume, PerfectMatch = true});
            //     if (sameNumeFeedbacks.Any(s => s.Id != inputFeedback.Id))
            //         throw new ApiException
            //         {
            //             ExceptionMessage = $"Cannot update feedback name to one that already exists : {inputFeedback.Nume}.",
            //             Severity = ExceptionSeverity.Error,
            //             Type = ExceptionType.ServiceException
            //         };
            // }

            var feedback = sameIdFeedbacks.First();
            feedback.UpdateByReflection(inputFeedback);
            return await _repository.UpdateFeedback(feedback);
        }
    }
}