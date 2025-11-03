using Microsoft.AspNetCore.Identity;

namespace _2025_2C_EstacionamietoORT.Models
{
    public class Rol : IdentityRole<int>
    {
        public Rol() : base()
        {
        }

        public Rol(string name) : base(name)
        {
        }


        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }

        }

        public override string NormalizedName
        {
            get { return base.NormalizedName; }
            set { base.NormalizedName = value; }
        }
    }
}
