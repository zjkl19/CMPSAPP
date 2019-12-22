using System;

using CMPSAPP.Models;

namespace CMPSAPP.ViewModels
{
    public class MonitorsQueryNavigationViewModel : BaseViewModel
    {
        public MonitorsQuery MonitorsQuery { get; set; }
        public MonitorsQueryNavigationViewModel(MonitorsQuery monitorsQuery = null)
        {
            MonitorsQuery = monitorsQuery;
        }
    }
}
