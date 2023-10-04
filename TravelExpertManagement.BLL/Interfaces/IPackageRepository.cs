using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertManagement.Data.Models;

namespace TravelExpertManagement.BLL.Interfaces
{
    public interface IPackageRepository
    {
        Task<IList<Package>> GetAllPackages();
        Task<Package> GetPackage(int id);
        Task<Package> AddPackage(Package package);
        Task<Package> UpdatePackage(Package package);
        Task<Package> DeletePackage(int id);
    }
}
