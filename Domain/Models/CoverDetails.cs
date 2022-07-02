using Domain.Enums;

namespace Domain.Models
{
    public class CoverDetails
    {
        public DateTime CoverStartDate { get; set; }
        public CoverType CoverType { get; set; }
        private int _voluntaryExcess;
        public int VoluntaryExcess { 
            get 
            {
                return _voluntaryExcess;
            } 
            set
            {
                var possibleExcessValues = new List<int> { 0, 100, 250, 500 };

                for (int i = 1; i < possibleExcessValues.Count; i++)
                {
                    var previousValue = possibleExcessValues[i - 1];
                    var excessValue = possibleExcessValues[i];

                    if(value <= excessValue)
                    {
                        var diffInPrevious = Math.Abs(previousValue - value);
                        var diffInCurrent = Math.Abs(excessValue - value);
                        if(diffInPrevious > diffInCurrent)
                        {
                            _voluntaryExcess = excessValue;
                            break;
                        } 
                        else
                        {
                            _voluntaryExcess = previousValue;
                            break;
                        }
                    }
                }
            }
        }
        public bool SpecialTerms { get; set; }
        public int? RenewalPrice { get; set; }
        public PaymentFrequency PaymentFrequency { get; set; }
        public bool FreeExcess { get; set; }
        public bool ContactPreference { get; set; }
    }
}
