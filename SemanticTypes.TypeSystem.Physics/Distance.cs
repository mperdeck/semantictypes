using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticTypes.MetricTypeSystem
{
    /// <summary>
    /// Encapsulates a distance.
    /// For conversions, see
    /// http://www.convert-me.com/en/
    /// </summary>
    public class Distance : SemanticDoubleType<Distance>
    {
        /// <summary>
        /// Creates a new distance
        /// </summary>
        /// <param name="value">
        /// Distance in meters
        /// </param>
        public Distance(double value) : base(value) { }

        private const double MilesToMeters = 1609;
        private const double FeetToMeters = 0.3048;
        private const double InchesToMeters = 0.0254;

        /// <summary>
        /// Creates a new distance.
        /// This method is nominally a duplicate of the constructor.
        /// However, using this makes it totally clear that you're passing in a value 
        /// in meters.
        /// </summary>
        /// <param name="value">
        /// Distance in meters
        /// </param>
        /// <returns></returns>
        public static Distance FromMeters(double value)
        {
            return new Distance(value);
        }

        /// <summary>
        /// Creates a new distance
        /// </summary>
        /// <param name="value">
        /// Distance in miles
        /// </param>
        /// <returns></returns>
        public static Distance FromMiles(double value)
        {
            return new Distance(value * MilesToMeters);
        }

        /// <summary>
        /// Creates a new distance
        /// </summary>
        /// <param name="value">
        /// Distance in feet
        /// </param>
        /// <returns></returns>
        public static Distance FromFeet(double value)
        {
            return new Distance(value * FeetToMeters);
        }

        /// <summary>
        /// Creates a new distance
        /// </summary>
        /// <param name="value">
        /// Distance in inches
        /// </param>
        /// <returns></returns>
        public static Distance FromInches(double value)
        {
            return new Distance(value * InchesToMeters);
        }

        /// <summary>
        /// Returns the distance in meters.
        /// </summary>
        /// <returns></returns>
        public double Meters
        {
            get { return Value; }
        }

        /// <summary>
        /// Returns the distance in miles.
        /// </summary>
        /// <returns></returns>
        public double Miles
        {
            get { return Value / MilesToMeters; }
        }

        /// <summary>
        /// Returns the distance in feet.
        /// </summary>
        /// <returns></returns>
        public double Feet
        {
            get { return Value / FeetToMeters; }
        }

        /// <summary>
        /// Returns the distance in inches.
        /// </summary>
        /// <returns></returns>
        public double Inches
        {
            get { return Value / InchesToMeters; }
        }

        public static Area operator *(Distance b, Distance c)
        {
            if ((b == null) || (c == null)) { return null; }
            return new Area(b.Value * c.Value);
        }

    }
}
