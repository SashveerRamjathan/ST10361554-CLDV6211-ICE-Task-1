using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CLDV6211_ICE_Task_1.Models;

namespace CLDV6211_ICE_Task_1.Data
{
    public class CLDV6211_ICE_Task_1Context : DbContext
    {
        public CLDV6211_ICE_Task_1Context (DbContextOptions<CLDV6211_ICE_Task_1Context> options)
            : base(options)
        {
        }

        public DbSet<CLDV6211_ICE_Task_1.Models.Book> Book { get; set; } = default!;
    }
}
