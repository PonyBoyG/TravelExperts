using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TravelExpertManagement.BLL.Interfaces;
using TravelExpertManagement.Data.Models;

namespace TravelExpertManagement.BLL.Repositories
{
    public class AgentRepository : IAgentRepository
    {
        private readonly TravelExpertsContext _context;

        public AgentRepository(TravelExpertsContext context)
        {
            _context = context;
        }

        public async Task<Agent> AddAgent(Agent agent)
        {
            _context.Agents.Add(agent);
            await _context.SaveChangesAsync();
            return agent;
        }

        public async Task<Agent> DeleteAgent(int id)
        {
            var agent = await _context.Agents.FindAsync(id);
            if (agent == null)
            {
                return null;
            }

            _context.Agents.Remove(agent);
            await _context.SaveChangesAsync();
            return agent;
        }

        public async Task<Agent> GetAgent(int id)
        {
            return await _context.Agents.FindAsync(id);
        }

        public async Task<IList<Agent>> GetAllAgents()
        {
            return await _context.Agents.ToListAsync();
        }

        public async Task<Agent> UpdateAgent(Agent agent)
        {
            _context.Entry(agent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return agent;
        }
    }
}
