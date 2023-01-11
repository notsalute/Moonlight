using MelonLoader;
using System.Collections;

namespace Moonlight_Client.Core
{
    public static class Functions
    {
        public static void Start(this IEnumerator source)
        {
            MelonCoroutines.Start(source);
        }

        public static void Stop(this IEnumerator source)
        {
            MelonCoroutines.Stop(source);
        }
    }
}
