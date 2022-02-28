using Domain.Enums;

namespace Domain.Models
{
    public class UserInformation
    {
        public string DateOfBirth { get; set; }
        public string HouseNameNumber { get; set; }
        public string Postcode { get; set; }
        public CoverType CoverType { get; set; }
        public string RegNo { get; set; }
    }
}
