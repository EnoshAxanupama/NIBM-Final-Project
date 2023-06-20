using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BixbyShop_LK.Users_and_Roles
{
    public class Authority
    {
        private String name;
        public string Name
        {
            get { return name; }
            set { name = value?.Trim(); }
        }

        private ICollection<Roles> roles;
        public ICollection<Roles> Roles
        {
            get { return roles; }
            set { roles = value; }
        }
    }
}
