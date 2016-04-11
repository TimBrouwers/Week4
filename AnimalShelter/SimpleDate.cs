using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace AnimalShelter
{
    /// <summary>
    /// A simple class to store dates.
    /// 
    /// This class is called SimpleDate because it's a simplyfied version of 
    /// the .Net DateTime object. SimpleDate hides the more complex interface of DateTime
    /// and makes it easy to  work with dates only.
    /// </summary>
    [Serializable]
    public class SimpleDate : ISerializable
    {
        private DateTime date;

        /// <summary>
        /// Creates a SimpleDate object whicht stores the given date.
        /// </summary>
        /// <param name="day">The day of the month</param>
        /// <param name="month">The month of the year</param>
        /// <param name="year">The year</param>
        public SimpleDate(int day, int month, int year)
        {
            date = new DateTime(year, month, day);
        }

        public SimpleDate(SerializationInfo info, StreamingContext ctxt)
        {
            DateTime dateTest = (DateTime) info.GetValue("date", typeof (DateTime));
            //made this check because we found datetime would get the minvalue if is was assigned a null value/invalid value
            if (dateTest == DateTime.MinValue)
            {
                throw new ArgumentException("Simpledate was invalid, aborting serialization.");
            }
            date = dateTest;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("date", date);
        }

        /// <summary>
        /// The day of the month
        /// </summary>
        public int Day
        {
            get { return date.Day; }
        }

        /// <summary>
        /// The month of the year
        /// </summary>
        public int Month
        {
            get { return date.Month; }
        }

        /// <summary>
        /// The year
        /// </summary>
        public int Year
        {
            get { return date.Year; }
        }

        /// <summary>
        /// Get the tumber of days between this objects date and the given date.
        /// </summary>
        /// <param name="date">The end date.</param>
        /// <returns>The number of days between this date and endDate.</returns>
        public int DaysDifference(SimpleDate date) 
        {
            TimeSpan timespan = date.date.Subtract(this.date);
            return timespan.Days;
        }

        public static int Compare(SimpleDate sd1, SimpleDate sd2)
        {
            int result = 0;
            if (sd1 != null && sd2 != null)
            {
                if (sd1.date <= sd2.date)
                {
                    result = 1;
                }
                else if (sd1.date > sd2.date)
                {
                    result = -1;
                }
            }
            else
            {
                throw new NullReferenceException("simpledate was null");
            }
            return result;
        }

        /// <summary>
        /// Returns the date info in the form DD-MM-YYYY (e.g. "04-11-2013").
        /// 
        /// Note: Every class inherits (automagically) from the 'Object' class,
        /// which contains the virtual ToString method which you can override for your own good.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return date.ToString("dd-MM-yyyy");
        }
    }
}
