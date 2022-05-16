using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IResultsService
    {
        public Results GetResultsInformation(string regNo, string email);
        public Results GetResultsInformation(UserInformation userInformation);
        public Results GetResultsInformation(QuoteInformation quoteInformation);


    }
}
