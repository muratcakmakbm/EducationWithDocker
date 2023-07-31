using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Education.Domain.Entities
{
    [Table("tb_Education")]
    public class tb_Education
    {
        [Key]
        public int EducationId { get; set; }
        [ForeignKey("EducationGroup")]
        public int EducationGroupId { get; set; }
        public string EducationName { get; set; }
        public string EducationExplanation { get; set; }
        public string EducationLink { get; set; }
        public tb_EducationGroup EducationGroup { get; set; }

    }
}
