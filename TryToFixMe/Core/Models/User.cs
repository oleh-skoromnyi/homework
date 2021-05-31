using System.Runtime.Serialization;

namespace Core.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string Firstname { get; set; }

        [DataMember]
        public string Lastname { get; set; }

        [DataMember]
        public string Points { get; set; }

        [DataMember]
        public int Age { get; set; }
    }
}