using ProjectLicenta.Web.LicentaApi.Core.Enums;
using ProjectLicenta.Web.LicentaApi.Core.Exceptions;
using ProjectLicenta.Web.LicentaApi.Core.Interfaces;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Validators
{
    public class AnuntValidator : IAnuntValidator
    {
        public bool Validate(IEntity entity)
        {
            return ValidateNume((Anunt) entity);
        }

        public static bool ValidateNume(Anunt inputAnunt)
        {
            if (inputAnunt.Text.Length <= 1)
                throw new ApiException
                {
                    ExceptionMessage = $"Text of anunt {inputAnunt.Text} cannot be 1 character or less.",
                    Severity = ExceptionSeverity.Error,
                    Type = ExceptionType.ValidationException
                };
            return true;
        }
    }
}