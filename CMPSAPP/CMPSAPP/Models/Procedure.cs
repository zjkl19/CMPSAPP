using System;
using System.Collections.Generic;
using System.Text;

namespace CMPSAPP.Models
{
    public class Procedure
    {
        //[ScaffoldColumn(false)]
        public Guid Id { get; set; }

        //[Display(Name = "施工顺序")]
        public int Sequence { get; set; }
        //[Display(Name = "名称")]
        public string Name { get; set; }

        //[Display(Name = "工序说明")]
        public string Instructions { get; set; }

        //[Display(Name = "备注")]
        public string Comment { get; set; }

        public Guid CMProjectId { get; set; }
    }
}
