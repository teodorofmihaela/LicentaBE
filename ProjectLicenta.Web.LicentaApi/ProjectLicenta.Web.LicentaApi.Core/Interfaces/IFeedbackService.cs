using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Interfaces
{
    public interface IFeedbackService
    {
        public Task<List<Feedback>> GetAllFeedbacks(string toSearch, List<Guid> guids, int pagination = 50, int skip = 0);

        public Task<bool> CreateFeedback(Feedback inputFeedback);

        public Task<bool> DeleteFeedback(string toSearch, List<Guid> guids);

        public Task<bool> UpdateFeedback(Feedback inputFeedback);
    }
}