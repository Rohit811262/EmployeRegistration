using System;
using System.Collections.Generic;

namespace Repository.DBEntities;

public partial class EmployeInfo
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public string? EmpWork { get; set; }

    public DateTime? LastModified { get; set; }
}
