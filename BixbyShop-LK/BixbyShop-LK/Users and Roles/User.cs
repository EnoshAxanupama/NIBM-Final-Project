using BixbyShop_LK.Users_and_Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BixbyShop_LK
{
    public class User
    {
        private long id;
        private String fistName;
        private String lastName;
        private String email;
        private String address;
        private String password;
        private String pic;

        public ICollection<Roles> roles;

        public ICollection<Roles> Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        public string FirstName
        {
            get { return fistName; }
            set { fistName = value?.Trim(); }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value?.Trim(); }
        }

        public string Email
        {
            get { return email; }
            set { email = value?.Trim(); }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Pic
        {
            get { return pic; }
            set { pic = value; }
        }
    }
}
