using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpertManagement.Data.Models
{
    public class UserManager
    {
        public static User Authenticate(string username, string password)
        {
            TravelExpertsContext db = new TravelExpertsContext();
            var user = db.Users.SingleOrDefault(usr => usr.Username == username && usr.Password == password);

            return user;
        }
    }
}
