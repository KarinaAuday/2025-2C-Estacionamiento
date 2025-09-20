using Microsoft.EntityFrameworkCore;

namespace _2025_2C_EstacionamietoORT.Data
{
    public class EstacionamientoContext : DbContext
    {
        public EstacionamientoContext(DbContextOptions options) : base(options)
        {

        }
    }
}
