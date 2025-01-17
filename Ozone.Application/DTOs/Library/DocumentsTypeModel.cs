﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ozone.Application.DTOs
{
    public class DocumentsTypeModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleteed { get; set; }
        public string Description { get; set; }
    }
}
