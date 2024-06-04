using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AW.Data;
using AW.Entities;

namespace AW.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class AWService : IAWService, IDisposable
    {
        readonly AWDbContext _Context = new AWDbContext();
        //[PrincipalPermission(SecurityAction.Demand, Role = "BUILTIN\\Users")]
        public List<Person> GetPersons()
        {
            return _Context.Person.ToList();
        }

        public void Dispose()
        {
            _Context.Dispose();
        }
    }
}
