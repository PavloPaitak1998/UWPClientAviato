using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviato.Models
{
    public class PlaneType
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int Seats { get; set; }
        public double Carrying { get; set; }
    }
}
