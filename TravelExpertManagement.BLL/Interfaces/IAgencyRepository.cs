using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertManagement.Data.Models;

namespace TravelExpertManagement.BLL.Interfaces
{
    public interface IAgencyRepository
    {
        Task<IList<Agency>> GetAllAgencies();
        Task<Agency> GetAgency(int id);
        Task<Agency> AddAgency(Agency agency);
        Task<Agency> UpdateAgency(Agency agency);
        Task<Agency> DeleteAgency(int id);
    }
}

