using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUserPassword.Domain
{
    internal class Users
    {
        private String login;
        private String password;

        public Users(String login, String password)
        {
            this.login = login;
            this.password = password;
        }

        public override string ToString()
        {
            return this.login + " " + this.password;
        }
    }
}
