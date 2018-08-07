using System;
using System.Collections.Generic;

namespace CW8.Models
{
    public partial class TblEmployee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Job { get; set; }
        public string Department { get; set; }
    }
}
