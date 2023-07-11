using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
    public class CertificationModel
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
