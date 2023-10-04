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
    public class PackageRepository : IPackageRepository
    {
        private readonly TravelExpertsContext _context;

        public PackageRepository(TravelExpertsContext context)
        {
            _context = context;
        }

        public async Task<Package> AddPackage(Package package)
        {
            _context.Packages.Add(package);
            await _context.SaveChangesAsync();
            return package;
        }

        public async Task<Package> DeletePackage(int id)
        {
            var package = await _context.Packages.FindAsync(id);
            if (package == null)
            {
                return null; 
            }

            _context.Packages.Remove(package);
            await _context.SaveChangesAsync();
            return package;
        }

        public async Task<Package> GetPackage(int id)
        {
            return await _context.Packages.FindAsync(id);
        }

        public async Task<IList<Package>> GetAllPackages()
        {
            return await _context.Packages.ToListAsync();
        }

        public async Task<Package> UpdatePackage(Package package)
        {
            _context.Entry(package).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return package;
        }
    }
}
