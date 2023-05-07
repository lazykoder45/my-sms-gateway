using MySmsGateway.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmsGateway.Services
{
    public class DeviceService
    {
        private readonly DeviceDao dao;
        public DeviceService(DeviceDao dao)
        {
            this.dao = dao;
        }
    }
}
