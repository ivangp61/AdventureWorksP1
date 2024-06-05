using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AW.Entities
{
    [DataContract]    
    public class Person
    {
        
        [DataMember]
        [Key]
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
