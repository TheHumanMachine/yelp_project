using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIPractive.DB_Classes
{
    public class CheckIn
    {
        private String day;
        private String count;
        private String time;

        public CheckIn(String day, String count, String time)
        {
            this.Day = day;
            this.Count = count;
            this.Time = time;
        }

        public string Time { get => time; set => time = value; }
        public string Count { get => count; set => count = value; }
        public string Day { get => day; set => day = value; }
    }
}
