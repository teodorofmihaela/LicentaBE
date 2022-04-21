using ProjectLicenta.Web.LicentaApi.Core.Enums;
using ProjectLicenta.Web.LicentaApi.Core.Exceptions;
using ProjectLicenta.Web.LicentaApi.Core.Interfaces;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Validators
{
    public class CautareValidator : ICautareValidator
    {
        public bool Validate(IEntity entity)
        {
            return ValidateNume((Cautare) entity);
        }

        public static bool ValidateNume(Cautare inputCautare)
        {
        //     if (inputCautare.IdUtilizator.Equals() <= 1)//??
        //         throw new ApiException
        //         {
        //             ExceptionMessage = $"Id utilizator cautare  {inputCautare.IdUtilizator} inexistent.",
        //             Severity = ExceptionSeverity.Error,
        //             Type = ExceptionType.ValidationException
        //         };
             return true;
        }
    }
}