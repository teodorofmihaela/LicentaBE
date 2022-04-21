using ProjectLicenta.Web.LicentaApi.Core.Enums;
using ProjectLicenta.Web.LicentaApi.Core.Exceptions;
using ProjectLicenta.Web.LicentaApi.Core.Interfaces;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Validators
{
    public class UtilizatorValidator : IUtilizatorValidator
    {
        public bool Validate(IEntity entity)
        {
            return ValidateNume((Utilizator) entity);
        }

        public static bool ValidateNume(Utilizator inputUtilizator)
        {
            if (inputUtilizator.Nume.Length <= 1)
                throw new ApiException
                {
                    ExceptionMessage = $"Name of utilizaotr {inputUtilizator.Nume} cannot be 1 character or less.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ValidationException
                };
            return true;
        }
    }
}