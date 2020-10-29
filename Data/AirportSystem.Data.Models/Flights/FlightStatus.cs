﻿namespace PlaneSystem.Data.Flight
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum FlightStatus
    {
        Ready = 1,
        WaitingForPassengers = 2,
        Declined = 3,
        TookOff = 4,
        ReachedDestination = 5,
        EmergenceLanded = 6,
        Delayed = 7,
    }
}
