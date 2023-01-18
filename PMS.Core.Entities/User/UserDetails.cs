using PMS.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Core.Entities.User
{
    public class UserDetails:Base<int>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
