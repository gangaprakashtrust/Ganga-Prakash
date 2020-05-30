using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GangaPrakashAPI.Model
{
    public class AccessToken
    {
        public String access_token { get; set; }
        public String token_type { get; set; }
        public long expires_in { get; set; }
        public String userName { get; set; }
    }
}
