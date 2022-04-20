using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Filters
{
    public class CautareFilter
    {
        public string ToSearch { get; set; }//filtrare dupa nume serviciu

        public List<Guid> Ids { get; set; }

        public bool PerfectMatch { get; set; } // by default false


        public IQueryable<Cautare> Filter(IQueryable<Cautare> cautareQuery)
        {
            if (!string.IsNullOrEmpty(ToSearch))
            {
                if (!PerfectMatch)
                    ToSearch = new string($"%{ToSearch}%");
                cautareQuery = cautareQuery.Where(cautare => EF.Functions.Like(cautare.IdUtilizator, ToSearch));
            }

            if (Ids != null && Ids.Count != 0)
                cautareQuery = cautareQuery.Where(cautare => Ids.Contains(cautare.Id));
            return cautareQuery;
        }
    }
}