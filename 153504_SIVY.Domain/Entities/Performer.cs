using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153504_SIVY.Domain.Entities
{
    public class Performer : Entity
    {
        // Национальность исполнителя
        public string Nationality { get; set; }

        // Песни исполнителя
        public List<Song> Songs { get; set; }
    }
}
