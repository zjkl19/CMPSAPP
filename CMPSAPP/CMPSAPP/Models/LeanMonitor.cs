using System;
using System.Collections.Generic;
using System.Text;

namespace CMPSAPP.Models
{
    public class LeanMonitor
    {
        //[ScaffoldColumn(false)]
        public Guid Id { get; set; }

        //[Display(Name = "编号")]
        public string No { get; set; }

        //[Display(Name = "局部序号")]
        public string LocalSequence { get; set; }

        //[Display(Name = "监测时间")]
        public DateTime MonitorTime { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N3}")]
        //[Display(Name = "轴1值")]
        public decimal Axle1Value { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N3}")]
        //[Display(Name = "理论轴1值")]
        public decimal TheoryAxle1Value { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N3}")]
        //[Display(Name = "轴2值")]
        public decimal Axle2Value { get; set; }

        //[DisplayFormat(DataFormatString = "{0:N3}")]
        //[Display(Name = "理论轴2值")]
        public decimal TheoryAxle2Value { get; set; }

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

