﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    class Role
    {
        public Guid Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
    }
}
