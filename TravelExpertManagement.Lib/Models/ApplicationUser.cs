﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TravelExpertManagement.Lib.Models
{
        public class ApplicationUser : IdentityUser
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool IsActive { get; set; }

            public ApplicationUser()
            {
                // Initialize properties if needed
                IsActive = true;
            }
        }


    }

