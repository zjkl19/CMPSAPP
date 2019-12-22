using System;
using System.Collections.Generic;
using System.Text;

namespace CMPSAPP.Models
{
    public class MonitorsQuery
    {
        public Guid Id { get; set; }
        public string No { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }
}
