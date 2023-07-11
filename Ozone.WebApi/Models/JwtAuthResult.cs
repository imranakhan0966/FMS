using System;

namespace Ozone.WebApi
{
    public class JwtAuthResult
    {
        public string AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
        public DateTime ValidTo { get; set; }
    }
}