using System;

namespace DbTableEditor.Auth.Model
{
    public class UserToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
