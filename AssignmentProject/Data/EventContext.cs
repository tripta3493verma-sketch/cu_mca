using AssignmentProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentProject.Data
{
    public class EventContext: IdentityDbContext<ApplicationUser>
    {
        public EventContext(DbContextOptions<EventContext> options)
            : base(options)
        {

        }

        public DbSet<EventAdd> EventAdd { get; set; }
    }
}
