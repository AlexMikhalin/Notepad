using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Notepad.Models
{
    public class Record
    {
        public Record()
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
        }
        // ID записи
        public Guid Id { get; set; }
        // название записи
        public string Note { get; set; }
        // номер записи
        public int Sort { get; set; }
        // вырывание записи
        public bool IsTearOut { get; set; }
        // Установка времени
        public DateTime Date { get; set; }

        public string Color { get; set; }

    }

}
