using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CognologyApp
{
    public interface IValidator
    {
        List<string> ErrorResponse { get; }

        bool CheckAvailability(DateTime start, DateTime end, int pax);
        //bool CheckAvailability(string request);
    }
}