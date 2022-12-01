using MyNewAspWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyNewAspWebAPI.Controllers
{
    public class CrudApiController : ApiController
    {


        Crud_ApiEntities db = new Crud_ApiEntities ();

        [HttpGet]
        public IHttpActionResult GetEmployees()
        {
            List<Employee> list = db.Employees.ToList();
            return Ok(list);
        }

        [HttpPost]
        public IHttpActionResult EmpInsert(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetEmployeesById(int id)
        {
            var emp = db.Employees.Where(model => model.id == id).FirstOrDefault();
            return Ok(emp);
        }

        [HttpPut]
        public IHttpActionResult EmpUpdate(Employee e)
        {
            // another method to update the result 
            //db.Entry(e).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();

            var emp = db.Employees.Where(model => model.id == e.id).FirstOrDefault();

            if (emp != null)
            {
                emp.id = e.id;
                emp.name = e.name;
                emp.gender = e.gender;
                emp.age = e.age;
                emp.designation = e.designation;
                emp.salary = e.salary;
                db.SaveChanges();
            }

            else
            {
                return NotFound();
            }

            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult EmpDelete(int id)
        {
            var emp = db.Employees.Where(model => model.id == id).FirstOrDefault();
            if(emp != null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
            }
            //db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
            //db.SaveChanges();

            return Ok();
        }


    }
}
