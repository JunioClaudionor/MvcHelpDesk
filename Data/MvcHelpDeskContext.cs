using Microsoft.EntityFrameworkCore;
using MvcHelpDesk.Models;


namespace MvcHelpDesk.Data
{
    public class MvcHelpDeskContext : DbContext
    {
        public MvcHelpDeskContext (DbContextOptions<MvcHelpDeskContext> options)
            : base(options)
        {
        }

        public DbSet<Denunciar> Denunciar{ get; set; }
    
        public DbSet<Usuario> Usuario{ get; set; }

        public DbSet<Tecnico> Tecnico{ get; set; }

        public DbSet<FeedBack> Feedback{ get; set; }

        public DbSet<OrdemDeServico> OrdemDeServico{ get; set; }
       }
}