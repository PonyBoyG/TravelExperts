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
    public class AgencyRepository : IAgencyRepository
    {
        private readonly TravelExpertsContext _context;

        public AgencyRepository(TravelExpertsContext context)
        {
            _context = context;
        }
        public async Task<Agency> AddAgency(Agency agency)
        {
            _context.Agencies.Add(agency);
            await _context.SaveChangesAsync();
            return agency;
        }

        public async Task<Agency> DeleteAgency(int id)
        {
            var agency = await _context.Agencies.FindAsync(id);
            if (agency == null)
            {
                return null; // Or handle not found case as needed
            }

            _context.Agencies.Remove(agency);
            await _context.SaveChangesAsync();
            return agency;
        }

        public async Task<Agency> GetAgency(int id)
        {
            return await _context.Agencies.FindAsync(id);
        }

        public async Task<IList<Agency>> GetAllAgencies()
        {
            return await _context.Agencies.ToListAsync();
        }

        public async Task<Agency> UpdateAgency(Agency agency)
        {
            _context.Entry(agency).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return agency;
        }
    }
}
