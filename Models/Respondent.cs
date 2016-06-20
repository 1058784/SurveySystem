using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SurveySystem.Models
{
    public class Respondent
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string FName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string LName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string MStatus { get; set; }

        public string Name
        {
            get
            {
                return LName + ", " + FName;
            }
        }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}