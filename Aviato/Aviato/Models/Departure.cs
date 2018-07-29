using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviato.Models
{
    public class Departure
    {
        public int Id { get; set; }
        public int FlightNumber { get; set; }
        public DateTime Time { get; set; }
        public int FlightId { get; set; }
        public int CrewId { get; set; }
        public int PlaneId { get; set; }
    }
}
