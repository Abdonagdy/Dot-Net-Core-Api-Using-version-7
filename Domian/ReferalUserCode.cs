using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class ReferalUserCode
    {
        public  int  id { get; set; }

        public int? UserReralold { get; set; }

        public int? UserReralnew { get; set; }
        public ReferalUserCode(int o , int n) {

             UserReralold=o; 
            
             UserReralnew=n; 


        }
        public ReferalUserCode():this(0,0)
        {

            

        }

    }
}
