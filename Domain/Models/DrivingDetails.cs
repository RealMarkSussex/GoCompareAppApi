using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class DrivingDetails
    {
        public TypeOfLicence TypeOfLicence { get; set; }
        public int YearsSincePassedTest { get; set; }
        public int MonthsSincePassedTest { get; set; }
        public bool DVLAReportableMedicalConditions { get; set; }
        [Range(0, 20)]
        public int YearsNoClaimBonus { get; set; }
        public bool HasPassPlus { get; set; }
        public bool ValidIAMCert { get; set; }
        public bool OtherVehicles { get; set; }
        public string? LicenceNumber { get; set; }
        public bool PastClaims { get; set; }
        public bool PastConvictions { get; set; }
        public bool UnspentNonMotoringConvictions { get; set; }
    }
}
