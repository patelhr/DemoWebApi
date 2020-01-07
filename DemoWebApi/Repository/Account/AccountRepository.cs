using DemoWebApi.Models.ApplicationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Repository.Account
{
    public class AccountRepository
    {
        private readonly IAuthenticationApiClient _authenticationApiClient;
        public AccountRepository(IAuthenticationApiClient authenticationApiClient)
        {
            _authenticationApiClient = authenticationApiClient;
        }
        public async Task<string> GetAccessTokenAsync(LoginAc loginModel)
        {
            var result = await _authenticationApiClient.GetTokenAsync(new ResourceOwnerTokenRequest
            {
                ClientId = _auth0Settings.ClientId,
                ClientSecret = _auth0Settings.ClientSecret,
                Audience = _auth0Settings.ApiIdentifier,
                Scope = scope,
                Realm = connection,
                Username = loginModel.EmailAddress,
                Password = loginModel.Password,
            });
        }
        }
    }
