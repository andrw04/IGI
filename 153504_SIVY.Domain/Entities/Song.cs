using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153504_SIVY.Domain.Entities
{
    public class Song : Entity
    {
        // Жанр музыки
        public string Genre { get; set; }
        public string Language { get; set; }
        // Длительность песни в секундах
        public int Duration { get; set; }
    }
}
