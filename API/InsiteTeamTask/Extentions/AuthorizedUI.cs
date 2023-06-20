using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace InsiteTeamTask.API.Extentions
{
    public class AuthorizedUIAttribute : ActionFilterAttribute, IAuthorizationFilter
    {
        private const string ApiKeyHeaderName = "X-API-Key";

        // This method is called during the authorization process.
        // It checks if the provided API key is valid and grants or denies access accordingly.
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers[ApiKeyHeaderName].FirstOrDefault();

            // Validate the provided API key
            if (!ValidateKey(token))
            {
                // If the key is invalid, set the result to an UnauthorizedResult,
                // which will deny access to the requested UI endpoint.
                context.Result = new UnauthorizedResult();
            }
        }

        // This private method validates the API key.
        // Add your logic here to determine whether the key is valid or not.
        private bool ValidateKey(string key)
        {
            if (string.IsNullOrEmpty(key)) return false;
            // TODO: Add your logic to validate the provided API key
            // For example, you can check against a database or a predefined list of valid keys.
            // Return true if the key is valid, and false otherwise.
            return true;
        }
    }


}
