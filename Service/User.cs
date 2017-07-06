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
        private string userName;

        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
      
    }
}
