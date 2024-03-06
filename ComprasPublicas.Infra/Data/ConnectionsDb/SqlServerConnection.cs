using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ComprasPublicas.Infra.Data.ConnectionsDb
{
    public static class SqlServerConnection
    {
        public static DbContextOptionsBuilder OnConfiguring(DbContextOptionsBuilder builder)
        {            
            return builder.UseSqlServer(@"Data Source=.\;Initial Catalog=ComprasPublicas;User ID=sa;Password=123");
        }
    }
}
