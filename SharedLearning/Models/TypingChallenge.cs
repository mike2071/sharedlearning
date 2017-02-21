using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedLearning.Models
{
    public class TypingChallenge
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal WPM { get; set; }

        public decimal Accuracy { get; set; }
    }
}