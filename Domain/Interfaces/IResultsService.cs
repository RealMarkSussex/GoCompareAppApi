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
        public List<ResultsInformation> GetResultsInformation(string regNo, string email);
        public List<ResultsInformation> GetResultsInformation(UserInformation userInformation);

    }
}
