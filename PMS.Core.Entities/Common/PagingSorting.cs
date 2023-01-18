using PMS.Core.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.Core.Entities.Common
{
    public class PagingSorting
    {
        public PageSize PageSize { get; set; }

        public int PageIndex { get; set; }

        public int TotalRecords { get; set; }

        public string SortBy { get; set; }

        public SortOrder SortOrder { get; set; }
    }
}
