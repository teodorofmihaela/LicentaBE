using ProjectLicenta.Web.LicentaApi.Core.Enums;
using ProjectLicenta.Web.LicentaApi.Core.Exceptions;
using ProjectLicenta.Web.LicentaApi.Core.Interfaces;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Validators
{
    public class UtilizatorFavoritValidator : IUtilizatorFavoritValidator
    {
        public bool Validate(IEntity entity)
        {
            return ValidateNume((AnuntFavorit) entity);
        }

        public static bool ValidateNume(AnuntFavorit inputAnuntFavorit)
        {
            // if (inputUtilizatorFavorit.Nume.Length <= 1)
            //     throw new ApiException
            //     {
            //         ExceptionMessage = $"Name of utilizatorFavorit {inputUtilizatorFavorit.Nume} cannot be 1 character or less.",
            //         Severity = ExceptionSeverity.Error,
            //         Type = ExceptionType.ValidationException
            //     };
            return true;
        }
    }
}