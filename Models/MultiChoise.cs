using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveySystem.Models
{
    public class MultiChoise : Question
    {
        [Required]
        public bool NullOrMultiAllowed { get; set; }

    }
}