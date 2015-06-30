using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plmOS.Database.Memory
{
    public class Session : ISession
    {
        public ITransaction BeginTransaction()
        {
            return new Transaction(this);
        }

        public Session()
        {
        }
    }
}
