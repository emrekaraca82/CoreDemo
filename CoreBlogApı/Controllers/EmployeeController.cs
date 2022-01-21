using CoreBlogApı.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogApı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        context c = new context();

        [HttpGet("List")]
        public IActionResult EmployeeList()
        {
            var values = c.Employees.ToList();
            return Ok(values);
        }

        [HttpPost("Add")]
        public IActionResult EmployeeAdd(Employee employee)
        {
            c.Employees.Add(employee);
            c.SaveChanges();
            return Ok();

        }

        [HttpGet("{id}")]
        public IActionResult EmployeeGetID(int id)
        {
            var values = c.Employees.Find(id);
            if(values != null)
            {
                return Ok(values);
            }
            else
            {
                return NotFound();
            }
           
        }
     
        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id)
        {
            var employee = c.Employees.Find(id);
            if(employee != null)
            {
                c.Employees.Remove(employee);
                c.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("Update")]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            var emp = c.Find<Employee>(employee.ID);
            if(emp != null)
            {
                emp.Name = employee.Name;
                emp.Surname = employee.Surname;
                c.SaveChanges();
                return Ok(emp);
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}
