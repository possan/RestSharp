namespace RestSharp
{
    /// <summary>
    /// Base class for OAuth 2 Authenticators.
    /// </summary>
    /// <remarks>
    /// Since there are many ways to authenticate in OAuth2,
    /// this is used as a base class to differentiate between 
    /// other authenticators.
    /// 
    /// Any other OAuth2 authenticators must derive from this
    /// abstract class.
    /// </remarks>
    public abstract class OAuth2Authenticator : IAuthenticator
    {
        #region Implementation of IAuthenticator

        public abstract void Authenticate(RestRequest request);

        #endregion
    }

    /// <summary>
    /// The OAuth 2 authenticator using URI query paramater.
    /// </summary>
    /// <remarks>
    /// Based on http://tools.ietf.org/html/draft-ietf-oauth-v2-10#section-5.1.2
    /// </remarks>
    public class OAuth2UriQueryParamaterAuthenticator : OAuth2Authenticator
    {
        /// <summary>
        /// Access token to be used when authenticating.
        /// </summary>
        private readonly string _accessToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="OAuth2UriQueryParamaterAuthenticator"/> class.
        /// </summary>
        /// <param name="accessToken">
        /// The access token.
        /// </param>
        public OAuth2UriQueryParamaterAuthenticator(string accessToken)
        {
            _accessToken = accessToken;
        }

        #region Overrides of OAuth2Authenticator

        public override void Authenticate(RestRequest request)
        {
            request.AddParameter("oauth_token", _accessToken, ParameterType.GetOrPost);
        }

        #endregion
    }
}