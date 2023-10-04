using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertManagement.Data.Models;

namespace TravelExpertManagement.BLL.Interfaces
{
    public interface IAgentRepository
    {
        Task<IList<Agent>> GetAllAgents();
        Task<Agent> GetAgent(int id);
        Task<Agent> AddAgent(Agent agent);
        Task<Agent> UpdateAgent(Agent agent);
        Task<Agent> DeleteAgent(int id);
    }
}
