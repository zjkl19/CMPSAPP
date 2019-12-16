using System;
using System.Collections.Generic;
using System.Text;

namespace CMPSAPP.Models
{
    public class CableForceMonitor
    {
        //[ScaffoldColumn(false)]
        public Guid Id { get; set; }

        //[Display(Name = "编号")]
        public string No { get; set; }

        //[Display(Name = "局部序号")]
        public string LocalSequence { get; set; }

        //[Display(Name = "监测时间")]
        public DateTime MonitorTime { get; set; }

        //[Display(Name = "索力值")]
        public decimal CableForceValue { get; set; }

        //[Display(Name = "理论索力值")]
        public decimal TheoryCableForceValue { get; set; }

        //[Display(Name = "温度")]
        public decimal Temperature { get; set; }

        //[Display(Name = "工序名称")]
        public string ProcedureName { get; set; }

        //[Display(Name = "备注")]
        public string Comment { get; set; }

        //[Display(Name = "创建人")]
        public string CreateStaffName { get; set; }

        public Guid ProcedureId { get; set; }

        public Guid CMProjectId { get; set; }
    }
}

