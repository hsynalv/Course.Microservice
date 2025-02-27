﻿using IdentityServer4.Models;
using IdentityServer4.Validation;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.IdentityServer.Services
{
    public class TokenExchangeExtensionGrandValidator : IExtensionGrantValidator
    {
        public string GrantType => "urn:ietf:params:oauth:grant-type:token-exchange";

        private readonly ITokenValidator _tokenValidator;

        public TokenExchangeExtensionGrandValidator(ITokenValidator tokenValidator)
        {
            _tokenValidator = tokenValidator;
        }

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var requestRaw = context.Request.Raw.ToString();

            var token = context.Request.Raw.Get("subject_token");

            if (string.IsNullOrEmpty(token))
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest, "Token missing");
                return;
            }

            var tokenValidateResult = await _tokenValidator.ValidateAccessTokenAsync(token);

            if (tokenValidateResult.IsError)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Token invalid");
                return;
            }

            var subjectClaim = tokenValidateResult.Claims.FirstOrDefault(c => c.Type == "sub");

            if (subjectClaim == null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "Token must contain sub value");
                return;
            }

            context.Result = new GrantValidationResult(subjectClaim.Value, "access_token", tokenValidateResult.Claims);
            return;
        }
    }
}
