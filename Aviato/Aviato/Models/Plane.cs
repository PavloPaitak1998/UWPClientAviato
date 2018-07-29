using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aviato.Models
{
    public class Plane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlaneTypeId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Lifetime { get; set; }
    }
}
