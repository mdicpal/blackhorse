namespace ApplicationLayer.Extensions.ApiExceptions
{
    using FunderApi;
    using System.Net;

    public static class ApiExceptionExtension
    {
        public static bool IsNonTransientError(this ApiException e)
        {
            return (HttpStatusCode)e.StatusCode is
                HttpStatusCode.BadRequest
                or HttpStatusCode.Unauthorized
                or HttpStatusCode.Forbidden
                or HttpStatusCode.NotFound
                or HttpStatusCode.InternalServerError
                or HttpStatusCode.PaymentRequired;
        }
    }
}
