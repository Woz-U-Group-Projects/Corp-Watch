using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CW8.Models;


namespace CW8.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer objemployee = new EmployeeDataAccessLayer();
        // GET: api/Employee
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<TblEmployee> Index()
        {
            return objemployee.GetAllEmployees();
        }

       
        // POST api/Employee
        [HttpPost]
        [Route("api/Employee/Create")]
        public int Create(TblEmployee employee)
        {
            return objemployee.AddEmployee(employee);
        }

        // Get api/Employee Data 
        [HttpGet]
        [Route("api/Employee/Details/{id}")]
        public TblEmployee Details(int id)
        {
            return objemployee.GetEmployeeData(id);
        }

        [HttpPut]
        [Route("api/Employee/Edit")]
        public int Edit(TblEmployee employee)
        {
            return objemployee.UpdateEmployee(employee);
        }

        [HttpDelete]
        [Route("api/Employee/Delete/{id}")]
        public int Delete(int id)
        {
            return objemployee.DeleteEmployee(id);
        }

        [HttpGet]
        [Route("api/Employee/GetJobList")]
        public IEnumerable<TblJob> Details()
        {
            return objemployee.GetJob();
        }
    }
}
