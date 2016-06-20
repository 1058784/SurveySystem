using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveySystem.Models
{
    public abstract class Question
    {
        public int ID { get; set; }
        public int SurveyID { get; set; }

        [Required]
        [Display(Name = "Question")]
        public string Title { get; set; }

        public int NoInSurvey { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }

}