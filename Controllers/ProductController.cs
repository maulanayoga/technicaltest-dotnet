using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestBackend.Models;
using TestBackend.Repository;
using TestBackend.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TestBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository repository;
        public ProductController(ProductRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetData()
        {
            try
            {
                var get = repository.GetData();

                if (get.Count() == 0)
                {

                    return CreateResponse(HttpStatusCode.NotFound, "Data not Exsist!");
                }
                else
                {
                    return CreateResponse(HttpStatusCode.OK, "Data Product", get);
                }
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{ProductId}")]

        public ActionResult Get(int ProductId)
        {
            try
            {
                var GetPId = repository.Get(ProductId);

                if (GetPId == null)
                {
                    return CreateResponse(HttpStatusCode.NotFound, "Data not Exsist!");
                }

                return CreateResponse(HttpStatusCode.OK, "Data Product", GetPId);
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public virtual ActionResult Insert(Product product)
        {
            try
            {
                //var CekNo = repository.CheckPhone(employeevm.Phone);
                //var CekEmail = repository.CheckEmail(employeevm.Email);

                if (product == null)
                {
                    return CreateResponse(HttpStatusCode.Conflict, "!");
                }
                var insert = repository.Insert(product);

                return CreateResponse(HttpStatusCode.OK, "Data Inserted!", product);
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public virtual ActionResult Put(Product product)
        {
            try
            {

                //var get = repository.Get(employee);
                if (product == null)
                {
                    return CreateResponse(HttpStatusCode.NotFound, "Data not Exsist!");
                }

                var upt = repository.Update(product);
                return CreateResponse(HttpStatusCode.OK, "Data Updated!");
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{ProductId}")]
        public virtual ActionResult Delete(int ProductId)
        {
            try
            {
                var employee = repository.Get(ProductId);

                if (employee == null)
                {
                    return CreateResponse(HttpStatusCode.NotFound, "Data not Exsist!");
                }
                var delete = repository.Delete(ProductId);
                return CreateResponse(HttpStatusCode.OK, "Data Deleted!");

            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        private ActionResult CreateResponse(HttpStatusCode statusCode, string message, object data = null)
        {
            if (data == null)
            {
                var responseDataNull = new JsonResult(new
                {
                    status_code = (int)statusCode,
                    message,
                });

                return responseDataNull;

            }

            var response = new JsonResult(new
            {
                status_code = (int)statusCode,
                message,
                data
            });

            return response;
        }

    }
}
