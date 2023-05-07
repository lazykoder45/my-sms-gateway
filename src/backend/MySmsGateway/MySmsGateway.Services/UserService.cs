using MySmsGateway.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmsGateway.Services
{
    public class UserService
    {
        private readonly UserDao dao;
        public UserService(UserDao dao)
        {
            this.dao = dao;
        }
    }
}
