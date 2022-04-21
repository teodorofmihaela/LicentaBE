using ProjectLicenta.Web.LicentaApi.Core.Enums;
using ProjectLicenta.Web.LicentaApi.Core.Exceptions;
using ProjectLicenta.Web.LicentaApi.Core.Interfaces;
using ProjectLicenta.Web.LicentaApi.Core.Models;

namespace ProjectLicenta.Web.LicentaApi.Core.Validators
{
    public class FeedbackValidator : IFeedbackValidator
    {
        public bool Validate(IEntity entity)
        {
            return ValidateNume((Feedback) entity);
        }

        public static bool ValidateNume(Feedback inputFeedback)
        {
            // if (inputFeedback.Nume.Length <= 1)
            //     throw new ApiException
            //     {
            //         ExceptionMessage = $"Name of feedback {inputFeedback.Nume} cannot be 1 character or less.",
            //         Severity = ExceptionSeverity.Error,
            //         Type = ExceptionType.ValidationException
            //     };
            return true;
        }
    }
}