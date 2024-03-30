using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDTO
{
    public class CustomerWithProjectDTO
    {
        public int customer_id { get; set; }

        public string? first_name { get; set; }

        public string? last_name { get; set; }

        public string? phone { get; set; }

        public string? email { get; set; }


        public decimal Salary { get; set; }

        //project info
    }
}
