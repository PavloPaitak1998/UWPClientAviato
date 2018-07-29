using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviato.Models
{
    public class Pilot
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CrewId { get; set; }
        public DateTime BirthDate { get; set; }
        public int Experience { get; set; }
    }
}
