namespace Domain.Models
{
    public class ResultInformation
    {
        public string PartnerName { get; set; }
        public string ImageUrl { get; set; }
        public bool LegalAssistance { get; set; }
        public bool BreakdownCover { get; set; }
        public bool PersonalAccident { get; set; }
        public bool CourtesyCar { get; set; }
        public double Price { get; set; }
        public int Excess { get; set; }
        public int DefaqtoRating { get; set; }
    }
}
