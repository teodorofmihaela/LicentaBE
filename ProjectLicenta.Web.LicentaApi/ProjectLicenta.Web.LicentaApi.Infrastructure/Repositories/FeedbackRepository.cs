using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectLicenta.Web.LicentaApi.Core.Filters;
using ProjectLicenta.Web.LicentaApi.Core.Interfaces;
using ProjectLicenta.Web.LicentaApi.Core.Models;
using ProjectLicenta.Web.LicentaApi.Infrastructure.Data;

namespace ProjectLicenta.Web.LicentaApi.Infrastructure.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly DataContext _dataContext;

        public FeedbackRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Feedback>> GetAllFeedbacks(FeedbackFilter filter, int pagination = 50, int skip = 0)
        {
            return await filter.Filter(_dataContext.Feedbacks.AsQueryable()).Skip(skip).Take(pagination).ToListAsync();
        }

        public async Task<bool> CreateFeedback(Feedback inputFeedback)
        {
            await _dataContext.Feedbacks.AddAsync(inputFeedback);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFeedback(Guid id)
        {
            _dataContext.Feedbacks.Remove(await _dataContext.Feedbacks.FirstOrDefaultAsync(Feedback => Feedback.Id.Equals(id)));
            
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateFeedback(Feedback inputFeedback)
        {
            _dataContext.Feedbacks.Update(inputFeedback);

            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}