//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NEST_App.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CMD_NAV_Takeoff
    {
        public int Id { get; set; }
        public string TakeoffPitch { get; set; }
        public string Altitude { get; set; }
        public string XAcceleration { get; set; }
        public string YAcceleration { get; set; }
        public string ZAcceleration { get; set; }
        public string Throttle { get; set; }
        public int UAVId { get; set; }
    }
}
