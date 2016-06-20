using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SurveySystem.Models
{
    public class Survey
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime fromDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime toDate { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}