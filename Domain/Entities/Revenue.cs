﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Revenue: Base
    {
        public long IdEnterprise { get; set; }
        public long IdContribution{ get; set; }
    }
}
