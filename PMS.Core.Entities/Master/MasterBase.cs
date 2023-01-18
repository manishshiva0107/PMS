using PMS.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PMS.Core.Entities.Master
{
    class MasterBase<T>:Base<T>
    {
        [Required]
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public string D0Code { get; set; }
        public bool IsDefault { get; set; }

        public int? ShortOrder { get; set; }
    }
}
