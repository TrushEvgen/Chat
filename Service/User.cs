using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    [DataContract]
    public class User
    {
        public User(Guid guid)
        {
            UserGuid = Guid.NewGuid();
        }
        private string userName;

        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private Guid guid = Guid.NewGuid();

        [DataMember]
        public Guid UserGuid
        {
            get { return guid; }
            set { guid = value; }
        }

        
        public override int GetHashCode()
        {
            return guid.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals((obj as User).UserGuid,guid);
        }

    }
}
