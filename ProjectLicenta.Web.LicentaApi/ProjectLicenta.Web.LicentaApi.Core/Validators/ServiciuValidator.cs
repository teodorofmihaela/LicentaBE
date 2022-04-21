using ProjectLicenta.Web.LicentaApi.Core.Enums;
using ProjectLicenta.Web.LicentaApi.Core.Exceptions;
using ProjectLicenta.Web.LicentaApi.Core.Interfaces;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Validators
{
    public class ServiciuValidator : IServiciuValidator
    {
        public bool Validate(IEntity entity)
        {
            return ValidateNume((Serviciu) entity);
        }

        public static bool ValidateNume(Serviciu inputServiciu)
        {
            // if (inputServiciu.Nume.Length <= 1)
            //     throw new ApiException
            //     {
            //         ExceptionMessage = $"Name of serviciu {inputServiciu.Nume} cannot be 1 character or less.",
            //         Severity = ExceptionSeverity.Error,
            //         Type = ExceptionType.ValidationException
            //     };
            return true;
        }
    }
}