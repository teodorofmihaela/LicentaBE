using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Filters
{
    public class FeedbackFilter
    {
        public string ToSearch { get; set; }//filtrare dupa nume

        public List<Guid> Ids { get; set; }

        public bool PerfectMatch { get; set; } // by default false


        public IQueryable<Feedback> Filter(IQueryable<Feedback> feedbackQuery)
        {
            if (!string.IsNullOrEmpty(ToSearch))
            {
                if (!PerfectMatch)
                    ToSearch = new string($"%{ToSearch}%");
                feedbackQuery = feedbackQuery.Where(feedback => EF.Functions.Like(feedback.Titlu, ToSearch));
            }

            if (Ids != null && Ids.Count != 0)
                feedbackQuery = feedbackQuery.Where(feedback => Ids.Contains(feedback.Id));
            return feedbackQuery;
        }
    }
}