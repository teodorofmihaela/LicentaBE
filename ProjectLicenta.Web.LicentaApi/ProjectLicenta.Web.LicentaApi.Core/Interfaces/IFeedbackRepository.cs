using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Filters;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Interfaces
{
    public interface IFeedbackRepository
    {
        public Task<List<Feedback>> GetAllFeedbacks(FeedbackFilter filter, int pagination = 50, int skip = 0);

        public Task<bool> CreateFeedback(Feedback inputFeedback);

        public Task<bool> DeleteFeedback(Guid id);

        public Task<bool> UpdateFeedback(Feedback inputFeedback);
    }
}