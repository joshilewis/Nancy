﻿namespace Nancy.Authentication.Token
{
    using System.Collections.Generic;

    using Nancy.Security;

    internal class DefaultUserMapper : IUserMapper
    {
        public IUserIdentity GetUser(string userName, IEnumerable<string> claims, NancyContext context)
        {
            return new TokenUserIdentity(userName, claims);
        }

        private class TokenUserIdentity : IUserIdentity
        {
            public TokenUserIdentity(string userName, IEnumerable<string> claims)
            {
                this.UserName = userName;
                this.Claims = claims;
            }

            public string UserName { get; private set; }

            public IEnumerable<string> Claims { get; private set; }
        }
    }
}