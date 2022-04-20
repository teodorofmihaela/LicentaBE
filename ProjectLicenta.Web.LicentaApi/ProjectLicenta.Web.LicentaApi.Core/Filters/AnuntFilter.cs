using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Filters
{
    public class AnuntFilter
    {
        public string ToSearch { get; set; }//filtrare dupa id serviciu

        public List<Guid> Ids { get; set; }

        public bool PerfectMatch { get; set; } // by default false


        public IQueryable<Anunt> Filter(IQueryable<Anunt> anuntQuery)
        {
            if (!string.IsNullOrEmpty(ToSearch))
            {
                if (!PerfectMatch)
                    ToSearch = new string($"%{ToSearch}%");
                anuntQuery = anuntQuery.Where(anunt => EF.Functions.Like(anunt.IdServiciu, ToSearch));
            }

            if (Ids != null && Ids.Count != 0)
                anuntQuery = anuntQuery.Where(anunt => Ids.Contains(anunt.Id));
            return anuntQuery;
        }
    }
}