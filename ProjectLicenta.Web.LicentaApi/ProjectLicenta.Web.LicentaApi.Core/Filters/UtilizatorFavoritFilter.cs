using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Filters
{
    public class UtilizatorFavoritFilter
    {
        public string ToSearch { get; set; }//filtrare dupa nume

        public List<Guid> Ids { get; set; }

        public bool PerfectMatch { get; set; } // by default false


        public IQueryable<AnuntFavorit> Filter(IQueryable<AnuntFavorit> utilizatorFavoritQuery)
        {
            if (!string.IsNullOrEmpty(ToSearch))
            {
                if (!PerfectMatch)
                    ToSearch = new string($"%{ToSearch}%");
                // utilizatorFavoritQuery = utilizatorFavoritQuery.Where(utilizatorFavorit => EF.Functions.Like(utilizatorFavorit.Nume, ToSearch));
            }

            if (Ids != null && Ids.Count != 0)
                utilizatorFavoritQuery = utilizatorFavoritQuery.Where(utilizatorFavorit => Ids.Contains(utilizatorFavorit.Id));
            return utilizatorFavoritQuery;
        }
    }
}