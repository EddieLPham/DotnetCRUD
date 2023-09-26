using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingWebApi.EfCore;
using ShoppingWebApi.Models;

namespace ShoppingWebApi.Controllers
{
    [ApiController]
    public class ShoppingApiController : ControllerBase
    {
        private readonly DbHelper _db;
        public ShoppingApiController(EF_DataContext eF_DataContext) {
            _db = new DbHelper(eF_DataContext);
        }

        // GET: /ShoppingApi
        [HttpGet]
        [Route("/[controller]/GetProducts")]
        public IActionResult Get()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                IEnumerable<ProductModel> data = _db.GetProducts();
                if (!data.Any())
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, data));
            }
            catch (Exception ex)
            {
                
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET: /ShoppingApi/5
        [HttpGet ]
        [Route("/[controller]/GetProductById/{id}")]

        public IActionResult Get(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                ProductModel data = _db.GetProductById(id);
                if (data ==null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, data));
            }
            catch (Exception ex)
            {
                type = ResponseType.Failure;
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST: /ShoppingApi
        [HttpPost]
        [Route("/[controller]/SaveOrder")]

        public IActionResult Post([FromBody] OrderModel model)
        {
            try {
                ResponseType type = ResponseType.Success;
                _db.SaveOrder(model);
                return Ok(ResponseHandler.GetApiResponse(type, model));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }

        // PUT: /ShoppingApi/5
        [HttpPut]
        [Route("/[controller]/UpdateOrder")]

        public IActionResult Put([FromBody] OrderModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.SaveOrder(model);
                return Ok(ResponseHandler.GetApiResponse(type, model));

            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }

        // DELETE: /ShoppingApi/5
        [HttpDelete]
        [Route("/[controller]/DeleteOrder/{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                _db.DeleteOrder(id);
                return Ok(ResponseHandler.GetApiResponse(type, "Delete Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));

            }
        }
        
    }
}
