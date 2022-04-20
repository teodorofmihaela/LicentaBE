using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Filters
{
    public class ServiciuFilter
    {
        public string ToSearch { get; set; }//filtrare dupa nume serviciu

        public List<Guid> Ids { get; set; }

        public bool PerfectMatch { get; set; } // by default false


        public IQueryable<Serviciu> Filter(IQueryable<Serviciu> serviciuQuery)
        {
            if (!string.IsNullOrEmpty(ToSearch))
            {
                if (!PerfectMatch)
                    ToSearch = new string($"%{ToSearch}%");
                serviciuQuery = serviciuQuery.Where(servicu => EF.Functions.Like(servicu.NumeServiciu, ToSearch));
            }

            if (Ids != null && Ids.Count != 0)
                serviciuQuery = serviciuQuery.Where(servicu => Ids.Contains(servicu.Id));
            return serviciuQuery;
        }
    }
}