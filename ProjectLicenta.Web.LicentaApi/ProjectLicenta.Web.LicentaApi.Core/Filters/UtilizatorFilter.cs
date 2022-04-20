using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Filters
{
    public class UtilizatorFilter
    {
        public string ToSearch { get; set; }//filtrare dupa nume

        public List<Guid> Ids { get; set; }

        public bool PerfectMatch { get; set; } // by default false


        public IQueryable<Utilizator> Filter(IQueryable<Utilizator> utilizatorQuery)
        {
            if (!string.IsNullOrEmpty(ToSearch))
            {
                if (!PerfectMatch)
                    ToSearch = new string($"%{ToSearch}%");
                utilizatorQuery = utilizatorQuery.Where(utilizator => EF.Functions.Like(utilizator.Nume, ToSearch));
            }

            if (Ids != null && Ids.Count != 0)
                utilizatorQuery = utilizatorQuery.Where(utilizator => Ids.Contains(utilizator.Id));
            return utilizatorQuery;
        }
    }
}