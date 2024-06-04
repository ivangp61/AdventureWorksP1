using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace AW.Entities
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int BusinessEntityID { get; set; }

        [DataMember]
        public string PersonType { get; set; }

        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public DateTime ModifiedDate { get; set; }
    }
}
