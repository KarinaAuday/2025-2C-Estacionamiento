using Microsoft.AspNetCore.Identity;

namespace _2025_2C_EstacionamietoORT.Models
{
    public class Rol : IdentityRole<int>
    {

        //Constructor
        public Rol() : base()
        {
        }
        public Rol(string roleName) : base(roleName)
        {
        }

        public override string Name
        {
            get { return base.Name; }
            set { base.Name = value; }

        }
        public override string NormalizedName
        {
            get => base.NormalizedName;
            set => base.NormalizedName = value;
        }

    }
}
