using System;
using System.Collections.Generic;
using System.Text;

namespace CMPSAPP.Models
{
    //和StrainMonitor数据结构相同
    public class StrainMonitorsChart
    {
        //[ScaffoldColumn(false)]
        public Guid Id { get; set; }

        //[Display(Name = "编号")]
        public string No { get; set; }

        //[Display(Name = "局部序号")]
        public string LocalSequence { get; set; }

        //[Display(Name = "监测时间")]
        public DateTime MonitorTime { get; set; }

        //[Display(Name = "应变测值")]
        public decimal StrainValue { get; set; }

        //[Display(Name = "温度")]
        public decimal Temperature { get; set; }

        //[Display(Name = "工序名称")]
        public string ProcedureName { get; set; }

        //[Display(Name = "备注")]
        public string Comment { get; set; }

        public Guid ProcedureId { get; set; }

        public Guid CMProjectId { get; set; }
    }
}
