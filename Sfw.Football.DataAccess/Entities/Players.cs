﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfw.Football.DataAccess.Entities
{
    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public int Rating { get; set; }
    }
}
