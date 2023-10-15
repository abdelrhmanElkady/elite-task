using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace elite_task.main.template
{
    public class BillItem
    {
        public string ItemName { get; set; }
        public int Quntity { get; set; }
        public float UnitPrice { get; set; }
        public float Total { get; set; }
    }
}