using Domain.Enums;

namespace Domain.Models
{
    public class ProposerDetails
    {
        public Title Title { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public DateTime LivedInUk { get; set; }
        public string TelephoneNumber { get; set; }
        public bool Homeowner { get; set; }
        public int NumberOfChildren { get; set; }
        public bool IsKeptOvernight { get; set; }
        public int TotalCarsInHousehold { get; set; }
        public OccupationStatus OccupationStatus { get; set;}
        public string JobTitle { get; set; }
        public string JobSector { get; set; }
        public bool OtherEmployment { get; set; }
        public Address Address { get; set; }

    }
}
