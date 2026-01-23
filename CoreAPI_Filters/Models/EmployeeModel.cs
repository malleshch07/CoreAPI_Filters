namespace CoreAPI_Filters.Models
{

    public class EmployeeModel
    {

        public int EmpId { get; set; }
        public string? EmpName { get; set; }
        public string? EmpAddress { get; set; }
        public bool IsActive { get; set; }
    }

    public class EmployeeData

    {
    //public readonly IEnumerable<EmployeeModel> objEmployee;


        IEnumerable<EmployeeModel> objEmployee = new List<EmployeeModel>()
        {
            new EmployeeModel(){EmpId=1, EmpAddress="Mallesh",EmpName="Mallesh",IsActive=false},
            new EmployeeModel(){EmpId=2, EmpAddress="Mallesh",EmpName="Mallesh",IsActive=false},
            new EmployeeModel(){EmpId=2, EmpAddress="Mallesh",EmpName="Mallesh",IsActive=false},
            new EmployeeModel(){EmpId=3, EmpAddress="Mallesh",EmpName="Mallesh",IsActive=false}


        };
    }
}
