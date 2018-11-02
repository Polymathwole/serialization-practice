using System;
using System.Collections.Generic;
//using System.Runtime.Serialization;
using System.Text;

namespace RndomTests.Models
{
    //[DataContract]
    public class Person
    {
        //[DataMember]
        public string FirstName { get; set; }
        //[DataMember]
        public string LastName { get; set; }
        //[DataMember]
        public int Age { get; set; }
        //[DataMember]
        public Guid UniqueID { get; set; }
    }
}
