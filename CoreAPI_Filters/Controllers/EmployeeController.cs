using CoreAPI_Filters.Filters;
using CoreAPI_Filters.Models;
using CoreAPI_Filters.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CoreAPI_Filters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {

        readonly IEmployeeRepo emprepo;

        public EmployeeController(IEmployeeRepo emp)
        {

            emprepo = emp;
        }
        #region Exception filter 
        [HttpGet]
        public IActionResult GetEmployee()
        {

            int[] abc = new int[] { 1, 2, 2, 2, 2, 2 };
            throw new Exception
                ("controller throwing" +
                " exception");
            return Ok(abc);
        }

        [HttpGet]
        [Route("GetEmployeeBId")]

        public IActionResult GetEmployeeBId()
        {
            string str = emprepo.GetData();
            Console.WriteLine("action method execeued");
            return Ok(new { message = str });
        }

        [HttpGet]
        [Route("GetEmployeeByName")]

        [GlobalExceptionFilter]
        // when you want to  try this attribute level go and comment the program.cs for add filter exception line because thats a globla decaltion works then we dont know 
        // this working or not
        public IActionResult GetEmployeeByName()
        {

            throw new Exception
                    ("controller throwing" +
                    " exception");


        }

        #endregion

        #region Actionfilter
        [HttpGet]
        [Route("getEmployeeByMangerId")]
        public IActionResult getEmployeeByMangerId()
        {
            Console.WriteLine("2:::: called inside action");

            return Ok(new { message = "testing action filter" });
        }


        [HttpGet]
        [Route("getEmployeeByMangerIdtwice")]
        [CustomActionFilter]

        [ResultResponseFilter]
        // when you want to  try this attribute level go and comment the program.cs for add filter customactionfilter line because thats a globla decaltion works then we dont know 
        // this working or not

        public IActionResult getEmployeeByMangerIdtwice()
        {
            Console.WriteLine("2:::: called inside action");

            return Ok(new { message = "testing action filter" });
        }
        #endregion

        #region Result/Response filter

        [HttpGet]
        [Route("getEmployeeByMangerName")]
        [CustomActionFilter]
        [ResultResponseFilter]
        // when you want to  try this attribute level go and comment the program.cs for add filter customactionfilter line because thats a globla decaltion works then we dont know 
        // this working or not

        public IActionResult getEmployeeByMangerName()
        {
            Console.WriteLine("2:::: called inside action");

            return Ok(new { message = "testing action filter" });
        }


        #endregion

        #region Cache

        [HttpPost]

        [Route("GetEmployeeDetailsBYCEO")]
        [ServiceFilter(typeof(CacheFilter))]
        public IActionResult GetEmployeeDetailsBYCEO([FromBody] EmployeeModel empdata)
        {
            return Ok(empdata);

        }
        #endregion

        #region authrize filter
        [HttpPost]
        [Route("GetEmployeeBySalary")]
        [ServiceFilter(typeof(AutherizeFilterOnly))]
        public IActionResult GetEmployeeBySalary()
        {
            return Ok();
        } 
        #endregion
    }
}
