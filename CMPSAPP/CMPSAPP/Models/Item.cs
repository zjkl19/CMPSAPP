using System;
using System.ComponentModel.DataAnnotations;

namespace CMPSAPP.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        //[Display(Name = "项目名称")]
        public string Name { get; set; }

        //[Display(Name = "关联合同编号")]
        public string ContractNo { get; set; }

        public string ElevationPhoto { get; set; }

        //[Display(Name = "工程状态")]
        public EngineeringStatus EngineeringStatus { get; set; }

        /// <summary>
        /// 状态：进场时间
        /// </summary>
        //[Display(Name = "进场日期")]
        //[DataType(DataType.Date)]
        public DateTime EnterDateTime { get; set; }

        //[Display(Name = "项目负责人")]
        public string ResponseStaffName { get; set; }

        public Guid ResponseStaffId { get; set; }
    }

    public enum EngineeringStatus
    {
        [Display(Name = "开工")]
        workstart = 1,
        [Display(Name = "停工")]
        workstop = 2,
        [Display(Name = "竣工")]
        completed = 3,

    }
}