using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUESTPRO.model
{
    internal class Holiday
    {
        public string name {  get; set; }
        public string description { get; set; }
        public Country country { get; set; }
        public Date date { get; set; }
        public List<String> type { get; set; }
        public string canonicalurl { get; set; }
        public string urlid { get; set; }
        public string locations { get; set; }
        public object states { get; set; }

    }
}
