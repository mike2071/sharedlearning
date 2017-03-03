using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SharedLearning.Models
{
    public class TypingChallengeIndexView
    {
        public TypingChallengeIndexView(List<TypingChallenge> typingChallenges)
        {
            TypingChallenges = typingChallenges;

            CalculateAverageCompanySpeedByTopFive();
            CalculateAverageCompanyAccuracyByTopFive();
        }

        public List<TypingChallenge> TypingChallenges { get; set; }

        public decimal AverageCompanySpeed { get; set; }

        public decimal AverageCompanyAccuracy { get; set; }
        
        private void CalculateAverageCompanySpeedByTopFive()
        {
            const int devideBy = 5;
            var topFiveWPMSummed = TypingChallenges.OrderBy(x => x.WPM).Take(5).Sum(s => s.WPM);

            AverageCompanySpeed = topFiveWPMSummed / devideBy;
        }

        private void CalculateAverageCompanyAccuracyByTopFive()
        {
            const int devideBy = 5;
            var topFiveAccuractSummed = TypingChallenges.OrderBy(x => x.WPM).Take(5).Sum(s => s.Accuracy);

            AverageCompanyAccuracy = topFiveAccuractSummed / devideBy;
        }
    }
}