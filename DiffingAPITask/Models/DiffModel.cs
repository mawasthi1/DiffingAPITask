using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiffingAPITask.Models
{
    public class DiffModel
    {
        public string position { get; set; }
        public string data { get; set; }
        public int offset { get; set; }
        public int length { get; set; }

    }
}