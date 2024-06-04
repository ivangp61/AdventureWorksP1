using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using AW.Entities;


namespace AW.Services
{
    [ServiceContract]
    public interface IAWService
    {
        [OperationContract]
        List<Person> GetPersons();
    }
}
