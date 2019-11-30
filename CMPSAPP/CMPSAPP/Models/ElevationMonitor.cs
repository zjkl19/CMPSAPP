using System;
using System.Collections.Generic;
using System.Text;

namespace CMPSAPP.Models
{
    public class ElevationMonitor
    {
        //[ScaffoldColumn(false)]
        public Guid Id { get; set; }

        //[Display(Name = "编号")]
        public string No { get; set; }

        //[Display(Name = "局部序号")]
        public string LocalSequence { get; set; }

        //[Display(Name = "监测时间")]
        public DateTime MonitorTime { get; set; }

        //[Display(Name = "高程值")]
        //[DisplayFormat(DataFormatString = "{0:N5}")]
        public decimal ElevationValue { get; set; }

        //[Display(Name = "理论高程值")]
        //[DisplayFormat(DataFormatString = "{0:N5}")]
        public decimal TheoryElevationValue { get; set; }

        //[Display(Name = "温度")]
        public decimal Temperature { get; set; }

        //[Display(Name = "工序名称")]
        public string ProcedureName { get; set; }

        //[Display(Name = "备注")]
        public string Comment { get; set; }

        public Guid ProcedureId { get; set; }
    }
}

