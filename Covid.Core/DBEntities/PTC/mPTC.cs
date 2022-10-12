using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Covid.Core.DBEntities.PTC
{
    public class mPTC
    {
        public int GameId { get; set; }
        public int Status { get; set; }
        public String GameJson { get; set; }
    }
}
