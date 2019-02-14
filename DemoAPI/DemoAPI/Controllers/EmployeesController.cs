using EmployeeDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        [BasicAuthentication]
        [HttpGet]
        public HttpResponseMessage LoadEmployeesByGender(string gender = "all")
        {
            string username = Thread.CurrentPrincipal.Identity.Name;
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                switch (username.ToLower())
                {
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(e => e.Gender.ToLower() == "female").ToList());
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.Employees.Where(e => e.Gender.ToLower() == "male").ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, gender + " is invalid");
                }
            }
        }

        [HttpGet]
        public HttpResponseMessage LoadEmployeeById(int id)
        {
            using (EmployeeDBEntities entities = new EmployeeDBEntities())
            {
                var model = entities.Employees.FirstOrDefault(e => e.ID == id);
                if(model != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, model);
                } else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id = " + id.ToString() + " not found");
                }
            }
        }

        [HttpPost]
        public HttpResponseMessage CreateNewEmployee([FromBody] Employee model)
        {
            try
            {
                using (EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    entities.Employees.Add(model);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, model);
                    message.Headers.Location = new Uri(Request.RequestUri + model.ID.ToString());
                    return message;
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage DeleteEmployee(int id)
        {
            try
            {
                using(EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var model = entities.Employees.FirstOrDefault(e => e.ID == id);
                    if(model != null)
                    {
                        entities.Employees.Remove(model);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id = " + id.ToString() + " not found to delete");
                    }
                }
            } catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateEmployee(int id, [FromBody] Employee model)
        {
            try
            {
                using(EmployeeDBEntities entities = new EmployeeDBEntities())
                {
                    var entity = entities.Employees.FirstOrDefault(e => e.ID == id);
                    if (entities != null)
                    {
                        entity.FirstName = model.FirstName;
                        entity.LastName = model.LastName;
                        entity.Gender = model.Gender;
                        entity.Salary = model.Salary;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    } else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id = " + id.ToString() + " not found to update");
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
