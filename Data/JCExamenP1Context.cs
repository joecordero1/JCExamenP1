using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JCExamenP1.Models;

namespace JCExamenP1.Data
{
    public class JCExamenP1Context : DbContext
    {
        public JCExamenP1Context (DbContextOptions<JCExamenP1Context> options)
            : base(options)
        {
        }

        public DbSet<JCExamenP1.Models.JCordero> JCordero { get; set; } = default!;
    }
}
