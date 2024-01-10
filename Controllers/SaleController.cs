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
    public class SaleController : ControllerBase
    {
        private readonly SaleRepository repository;
        public SaleController(SaleRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Sale>> GetData()
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
                    return CreateResponse(HttpStatusCode.OK, "Data Sale", get);
                }
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{SaleId}")]

        public ActionResult Get(int SaleId)
        {
            try
            {
                var GetSId = repository.Get(SaleId);

                if (GetSId == null)
                {
                    return CreateResponse(HttpStatusCode.NotFound, "Data not Exsist!");
                }

                return CreateResponse(HttpStatusCode.OK, "Data Sale", GetSId);
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public virtual ActionResult Insert(SaleVM salevm)
        {
            try
            {
                //var CekNo = repository.CheckPhone(employeevm.Phone);
                //var CekEmail = repository.CheckEmail(employeevm.Email);

                if (salevm == null)
                {
                    return CreateResponse(HttpStatusCode.Conflict, "!");
                }
                var insert = repository.Insert(salevm);

                return CreateResponse(HttpStatusCode.OK, "Data Inserted!", salevm);
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public virtual ActionResult Put(SaleVM salevm)
        {
            try
            {

                //var get = repository.Get(employee);
                if (salevm == null)
                {
                    return CreateResponse(HttpStatusCode.NotFound, "Data not Exsist!");
                }

                var upt = repository.Update(salevm);
                return CreateResponse(HttpStatusCode.OK, "Data Updated!");
            }
            catch (Exception ex)
            {
                return CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{SaleId}")]
        public virtual ActionResult Delete(int SaleId)
        {
            try
            {
                var employee = repository.Get(SaleId);

                if (employee == null)
                {
                    return CreateResponse(HttpStatusCode.NotFound, "Data not Exsist!");
                }
                var delete = repository.Delete(SaleId);
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
