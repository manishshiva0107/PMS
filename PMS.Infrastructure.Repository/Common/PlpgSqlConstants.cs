using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Infrastructure.Repository.Common
{
    public static class PlpgSqlConstants
    {
        public const string GetUserDetails = @"Select * from ""UserAdmin"".""usp_GetUserAccessInformation""(@in_userid)";

    }
}
