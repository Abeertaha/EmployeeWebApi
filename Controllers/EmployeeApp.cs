using Microsoft.AspNetCore.Mvc;
using EmployeeApp.Models;
using System.Collections.Generic;

namespace EmployeeApp.Controllers
{
[ApiController]
[Route("[controller]")]

public class EmployeeAppController : ControllerBase
{
    private static List<Employee> employeeList = new List<Employee>();    
    
    [HttpGet]
    public ActionResult<IEnumerable<Employee>> Get()
    {
        return Ok(employeeList);
    }    
    
    [HttpGet("{id}")]
    public ActionResult<Employee> Get(int id)
    {
        var employee = employeeList.Find(a => a.Id == id);
        if (employee == null)
        {
            return NotFound();
        }
        return Ok(employeeList[id]);
    }    
    
    [HttpPost]
    public ActionResult<Employee> Create(Employee employee)
    {
        employee.Id = employeeList.Count + 1;
        employeeList.Add(employee);
        return CreatedAtAction(nameof(Get), new Employee{Id = employee.Id}, employee);
    }    
    
    [HttpPut("{id}")]
    public IActionResult Update(int id, Employee employee)
    {
        var existingEmployee = employeeList.Find(a => a.Id == id);
        if (existingEmployee == null)
        {
            return NotFound();
        }
        existingEmployee.Name = employee.Name;
        return NoContent();
    }    
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var employee = employeeList.Find(a => a.Id == id);
        if (employee == null)
        {
            return NotFound();
        }
        employeeList.Remove(employee);
        return NoContent();
    }
}
}