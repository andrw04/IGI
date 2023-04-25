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

        // Язык
        public string Language { get; set; }

        // Длительность песни в секундах
        public int Duration { get; set; }

        // Место в чарте (обязательное свойство)
        public int Position { get; set; }

        // Автор песни (внешний ключ)
        public long PerformerId { get; set; }

        // Навигационное свойство
        public Performer? Performer { get; set; }
    }
}
