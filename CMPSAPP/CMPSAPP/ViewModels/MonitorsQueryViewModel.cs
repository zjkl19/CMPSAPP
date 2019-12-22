using System;
using System.Collections.Generic;
using System.Text;

namespace CMPSAPP.ViewModels
{
    public class MonitorsQueryViewModel
    {
        public Guid Id { get; set; }
        public string No { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }
}
