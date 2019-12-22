using System;

using CMPSAPP.Models;

namespace CMPSAPP.ViewModels
{
    public class MonitorsQueryNavigationViewModel : BaseViewModel
    {
        public MonitorsQueryViewModel MonitorsQueryViewModel { get; set; }
        public MonitorsQueryNavigationViewModel(MonitorsQueryViewModel monitorsQueryViewModel = null)
        {
            MonitorsQueryViewModel = monitorsQueryViewModel;
        }
    }
}
