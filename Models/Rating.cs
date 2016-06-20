using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurveySystem.Models
{
    public class Rating : Question
    {
        public int MinRate { get; set; }
        public int RateStep { get; set; }
        public int MaxRate { get; set; }
  //      public virtual ICollection<Answer> Answers { get; set; }
    //    public virtual Survey Survey { get; set; }

    }
}