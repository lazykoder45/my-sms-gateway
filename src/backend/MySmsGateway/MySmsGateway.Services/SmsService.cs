using MySmsGateway.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySmsGateway.Services
{
    public class SmsService
    {
        private readonly SmsDao dao;
        public SmsService(SmsDao dao)
        {
            this.dao = dao;
        }
    }
}
