using CognologyAPI;
using CognologyApp.Resources;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CognologyApp
{
    public class Validator : IValidator
    {
        private List<string> _errors;

        public List<string> ErrorResponse
        {
            get { return _errors; }
        }

        public Validator()
        {
            _errors = new List<string>();
        }
        /// <summary>
        /// To Check the seat availability on the dates for no of pax
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="pax"></param>
        /// <returns></returns>
        public bool CheckAvailability(DateTime start, DateTime end, int pax)
        {
            if (!CheckDataValidity(start, end, pax))
                return false;

            FlightData flightData = new FlightData();

            string inputData = ContentLoading.GetFlightDataContent();
            try
            {
                flightData = JsonConvert.DeserializeObject<FlightData>(inputData);
            }
            catch (Exception e)
            {
                _errors.Add($"Fattle error in Data extraction. Exception {e.InnerException}");
                return false;
            }
            

            var isFlightOperatesOnStartDate = IsFlightOperatesOnDate(start, flightData);
            if (!isFlightOperatesOnStartDate)
            {
                _errors.Add($"There are no service on Start date: {start.ToShortDateString()} or End date: {end.ToShortDateString()}");
                return false;
            }

            var isFlightOperatesOnEndDate = IsFlightOperatesOnDate(end, flightData);
            if (!isFlightOperatesOnEndDate)
            {
                _errors.Add($"There are no service on End date: {end.ToShortDateString()}");
                return false;
            }           

            AvailableSeats(start, flightData, out int outAvailable, out int inAvailable);
            if (outAvailable == 0)
            {
                _errors.Add($"There are no seats available on Start date: {start.ToShortDateString()}");
                return false;
            }

            AvailableSeats(end, flightData, out int outAvailableEnd, out int inAvailableEnd);
            if (inAvailableEnd == 0)
            {
                _errors.Add($"There are no seats available on End date: {end.ToShortDateString()}");
                return false;
            }

            if (pax > outAvailable)
            {
                _errors.Add($"On start date: {start.ToShortDateString()}, Only available seats are {outAvailable}, but you are looking for {pax}.");
                return false;
            }
            if (pax > inAvailableEnd)
            {
                _errors.Add($"On end date: {end.ToShortDateString()}, Only available seats are {inAvailableEnd}, but you are looking for {pax}.");
                return false;
            }

            return true;
        }
        /// <summary>
        /// To check the availability
        /// </summary>
        /// <param name="input"></param>
        /// <param name="flightData"></param>
        /// <param name="outAvailable"></param>
        /// <param name="inAvailable"></param>
        private void AvailableSeats(DateTime input, FlightData flightData, out int outAvailable, out int inAvailable)
        { 
            outAvailable = 0;
            inAvailable = 0;

            var fData = flightData.Flights.Find(f => f.DateOfTravel.ToShortDateString().Equals(input.ToShortDateString()));
            if (fData != null)
            {
                outAvailable = fData.OutBoundAvailable;
                inAvailable = fData.InBoundAvailable;
            }        
        }
        /// <summary>
        /// To check the operation dates
        /// </summary>
        /// <param name="input"></param>
        /// <param name="flightData"></param>
        /// <returns></returns>
        private bool IsFlightOperatesOnDate(DateTime input, FlightData flightData)
        {
            var fData = flightData.Flights.Find(f => f.DateOfTravel.ToShortDateString().Equals(input.ToShortDateString()));

            return fData != null;            
        }
        /// <summary>
        /// To validate the input data
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="pax"></param>
        /// <returns></returns>
        private bool CheckDataValidity(DateTime start, DateTime end, int pax)
        {
            bool invalidData = false;

            if (start > end)
            {
                _errors.Add("Start Date is greater than the End Date");
                invalidData = true;
            }

            if (start < DateTime.Now)
            {
                _errors.Add("Start Date should not be past date");
                invalidData = true;
            }

            if (end < DateTime.Now)
            {
                _errors.Add("End Date should not be past date");
                invalidData = true;
            }

            if (pax <= 0)
            {
                _errors.Add("Number of travellers should be 1 or more");
                invalidData = true;
            }

            if ((start - DateTime.Now ).TotalDays > 60) //My test data having only max of 60 days
            {
                _errors.Add($"The Start date {start.ToLongDateString()} is too far to check the availability");
                invalidData = true;
            }

            if ((end - DateTime.Now).TotalDays > 60) //My test data having only max of 60 days
            {
                _errors.Add($"The End date {end.ToLongDateString()} is too far to check the availability");
                invalidData = true;
            }

            if (invalidData)            
                return false;            
            else
                return true;
        }
    }
}
