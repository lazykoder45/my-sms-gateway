using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmsGateway.Dao
{
    public class UserDao : CommonDao
    {
        public UserDao(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
