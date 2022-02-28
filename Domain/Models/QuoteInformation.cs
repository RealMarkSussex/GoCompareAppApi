using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class QuoteInformation
    {
        public VehicleDetails VehicleDetails { get; set; }
        public ProposerDetails ProposerDetails { get; set; }
        public DrivingDetails DrivingDetails { get; set; }
        public CoverDetails CoverDetails { get; set; }
        public DateTime QuoteDate { get; set; }
    }
}
