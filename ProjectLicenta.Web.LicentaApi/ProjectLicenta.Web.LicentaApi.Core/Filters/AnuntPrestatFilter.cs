using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Filters
{
    public class AnuntPrestatFilter
    {
        public string ToSearch { get; set; }//filtrare dupa idUtilizator

        public List<Guid> Ids { get; set; }

        public bool PerfectMatch { get; set; } // by default false


        public IQueryable<AnuntPrestat> Filter(IQueryable<AnuntPrestat> anuntPrestatQuery)
        {
            if (!string.IsNullOrEmpty(ToSearch))
            {
                if (!PerfectMatch)
                    ToSearch = new string($"%{ToSearch}%");
                // anuntPrestatQuery = anuntPrestatQuery.Where(anuntPrestat => EF.Functions.Like(anuntPrestat.IdUtilizator, ToSearch));
            }

            if (Ids != null && Ids.Count != 0)
                anuntPrestatQuery = anuntPrestatQuery.Where(anuntPrestat => Ids.Contains(anuntPrestat.Id));
            return anuntPrestatQuery;
        }
    }
}