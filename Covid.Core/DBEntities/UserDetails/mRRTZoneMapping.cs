﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.UserDetails
{
    public class mRRTZoneMapping
    {
        public int UserId { get; set; }

        public int LocalBodyId { get; set; }

        public int ZoneId { get; set; }

        public int WardId { get; set; }
    }
}
