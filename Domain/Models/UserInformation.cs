using Domain.Enums;

namespace Domain.Models
{
    public class UserInformation
    {
        public DateTime DateOfBirth { get; set; }
        public string HouseNameNumber { get; set; }
        public string Postcode { get; set; }
        public CoverType CoverType { get; set; }
        public string regNo { get; set; }
    }
}
