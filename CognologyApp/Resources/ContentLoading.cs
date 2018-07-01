using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CognologyApp.Resources
{
    static class ContentLoading
    {
        public static string GetFlightDataContent()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string NAME = "CognologyApp.Resources.FlightData.json";
            using (Stream stream = assembly.GetManifestResourceStream(NAME))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
