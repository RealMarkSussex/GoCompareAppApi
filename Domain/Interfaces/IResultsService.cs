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
        public List<ResultInformation> GetResultsInformation(string regNo, string email);
        public List<ResultInformation> GetResultsInformation(UserInformation userInformation);

    }
}
