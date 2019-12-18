using System;

using CMPSAPP.Models;

namespace CMPSAPP.ViewModels
{
    public class ProcedureDetailViewModel : BaseViewModel
    {
        public Procedure Procedure { get; set; }
        public string SurveyPointURL{ get; set; }

        public ProcedureDetailViewModel(Procedure item = null)
        {
            Title = item?.Name;
            Procedure = item;
        }

        public ProcedureDetailViewModel(Guid Id,Procedure item = null)
        {
            Title = item?.Name;
            Procedure = item;
            SurveyPointURL = $"http://192.168.1.107/Procedure/Details/{Id.ToString()}";
        }
    }
}
