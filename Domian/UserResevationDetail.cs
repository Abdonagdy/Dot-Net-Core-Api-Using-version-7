using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class UserResevationDetail
    {


        public int id { get; set; }

        public User User { get; set; }

        public CarNamesh CarName { get; set; }


        public UserResevationDetail(User user , CarNamesh carName) {
        
             User = user;
             CarName=carName;

        }

        public UserResevationDetail():this(null!,null!) { }
    }
}
