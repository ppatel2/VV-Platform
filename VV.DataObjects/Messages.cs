using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.DataObjects
{
    public class Messages
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime? Sent { get; set; }
        public DateTime? Recieved { get; set; }
        public DateTime? ReadAt { get; set; }
        public string Message { get; set; }
        public bool Read { get; set; }
        public string XMLMessage { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
