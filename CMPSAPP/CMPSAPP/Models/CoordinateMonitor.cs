using System;
using System.Collections.Generic;
using System.Text;

namespace CMPSAPP.Models
{
    public class CoordinateMonitor
    {
        //[ScaffoldColumn(false)]
        public Guid Id { get; set; }

        //[Display(Name = "编号")]
        public string No { get; set; }

        //[Display(Name = "局部序号")]
        public string LocalSequence { get; set; }

        //[Display(Name = "监测时间")]
        public DateTime MonitorTime { get; set; }

        //[Display(Name = "X坐标值")]
        //[DisplayFormat(DataFormatString = "{0:N4}")]
        public decimal XValue { get; set; }

        //[Display(Name = "Y坐标值")]
        //[DisplayFormat(DataFormatString = "{0:N4}")]
        public decimal YValue { get; set; }

        //[Display(Name = "Z坐标值")]
        //[DisplayFormat(DataFormatString = "{0:N4}")]
        public decimal ZValue { get; set; }

        //[Display(Name = "理论X坐标值")]
        //[DisplayFormat(DataFormatString = "{0:N4}")]
        public decimal TheoryXValue { get; set; }

        //[Display(Name = "理论Y坐标值")]
        //[DisplayFormat(DataFormatString = "{0:N4}")]
        public decimal TheoryYValue { get; set; }

        //[Display(Name = "理论Z坐标值")]
        //[DisplayFormat(DataFormatString = "{0:N4}")]
        public decimal TheoryZValue { get; set; }

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
