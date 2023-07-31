using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Education.Domain.Entities
{
    [Table("tb_EducationGroup")]
    public class tb_EducationGroup
    {
        [Key]
        public int EducationGroupId { get; set; }
        public string EducationGroupName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; } 
        public int? Status { get; set; }
        public List<tb_Education> Educations { get; set; }
    }
}
