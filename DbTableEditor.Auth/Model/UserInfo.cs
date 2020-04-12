using System.Collections.Generic;

namespace DbTableEditor.Auth.Model
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
    }
}
