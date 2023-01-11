using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moonlight_Client.Functions
{
    internal class AutoFR
    {
        public static string Zilla = "usr_62afe86b-5964-4495-a4b0-1c023d7a847b";
        public static string Salute = "usr_119ce599-e9fd-4a83-95de-546b444369ab";



        public static void FriendZilla()
        {
            VRC.Core.API.SendPostRequest($"user/{Zilla}/friendRequest");
        }

        public static void FriendSalute()
        {
            VRC.Core.API.SendPostRequest($"user/{Salute}/friendRequest");
        }
    }
}
