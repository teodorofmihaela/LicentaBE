using ProjectLicenta.Web.LicentaApi.Core.Enums;
using ProjectLicenta.Web.LicentaApi.Core.Exceptions;
using ProjectLicenta.Web.LicentaApi.Core.Interfaces;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Validators
{
    public class AnuntPrestatValidator : IAnuntPrestatValidator
    {
        public bool Validate(IEntity entity)
        {
            return ValidateNume((AnuntPrestat) entity);
        }

        public static bool ValidateNume(AnuntPrestat inputAnuntPrestat)
        {
            // if (inputAnuntPrestat.Nume.Length <= 1)
            //     throw new ApiException
            //     {
            //         ExceptionMessage = $"Name of anuntPrestat {inputAnuntPrestat.Nume} cannot be 1 character or less.",
            //         Severity = ExceptionSeverity.Error,
            //         Type = ExceptionType.ValidationException
            //     };
            return true;
        }
    }
}