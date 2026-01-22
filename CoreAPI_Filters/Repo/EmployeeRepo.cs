namespace CoreAPI_Filters.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {

        public string GetData()
        {

            int a = 10;
            int b = 0;
            int c = a / b;
            return "reached get data in employeerepo";
        }
    }
}
