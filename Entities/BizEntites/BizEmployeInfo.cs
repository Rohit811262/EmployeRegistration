using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.BizEntites
{
    public class BizEmployeInfo
    {
        public int ? EmpId { get; set; }

        public string? EmpName { get; set; }

        public string? EmpWork { get; set; }

        public DateTime? LastModified { get; set; }
    }
}
