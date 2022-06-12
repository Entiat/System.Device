// ==++==
// 
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// 
// ==--==
/*=============================================================================
**
** Class: GeoLocation
**
** Purpose: Represents a GeoLocation object
**
=============================================================================*/

namespace System.Device.Location
{
    public class GeoLocation
    {
        public static readonly GeoLocation Unknown = new(GeoCoordinate.Unknown);

        #region Constructors

        public GeoLocation(GeoCoordinate coordinate)
            : this(coordinate, double.NaN, double.NaN)
        {
        }

        public GeoLocation(GeoCoordinate coordinate, double heading, double speed)
            : this(coordinate, heading, speed, CivicAddress.Unknown, DateTimeOffset.Now)
        {
        }

        public GeoLocation(CivicAddress address)
            : this(GeoCoordinate.Unknown, double.NaN, double.NaN, address, DateTimeOffset.Now)
        {
        }

        public GeoLocation(GeoCoordinate coordinate, double heading, double speed, CivicAddress address, DateTimeOffset timestamp)
        {
			if (heading < 0.0 || heading > 360.0)
            {
                throw new ArgumentOutOfRangeException(nameof(heading), SR.Argument_MustBeInRangeZeroTo360);
            }

            if (speed < 0.0)
            {
                throw new ArgumentOutOfRangeException(nameof(speed), SR.Argument_MustBeNonNegative);
            }

            Coordinate = coordinate ?? throw new ArgumentNullException(nameof(coordinate));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Heading = heading;
            Speed = speed;
            Timestamp = timestamp;
        }

        #endregion

        #region Properties

        public GeoCoordinate Coordinate { get; private set;}
        public double Heading {get; private set; }
        public double Speed { get; private set; }
        public CivicAddress Address { get; private set; }
        public DateTimeOffset Timestamp {get; private set; }

        #endregion
    }
}
