using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace learning
{
    internal class Context : DbContext
    {
        public Context() : base ("name=Company_SDEntities") 
        { }
    }
}
