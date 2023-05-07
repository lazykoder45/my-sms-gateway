using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmsGateway.Dao
{
    public class DeviceDao : CommonDao
    {
        public DeviceDao(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
