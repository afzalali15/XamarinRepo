using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavBook.Services
{
    public class ConnectivityService
    {
        public static async Task<bool> IsConnected()
        {
            return await CrossConnectivity.Current.IsRemoteReachable("http://www.google.com", 80, 5000);
        }
    }
}
