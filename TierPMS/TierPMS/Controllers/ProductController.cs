using BLL.DTOs;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TierPMS.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/product/all")]
        public HttpResponseMessage Get()
        {
            var data = ProductService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/product/{id}")]
        public HttpResponseMessage Get(int id)
        {
            var data = ProductService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("api/product/search/{name}")]
        public HttpResponseMessage Search(string name)
        {

            var data = ProductService.SearchByName(name);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }


        [HttpPost]
        [Route("api/product/create")]
        public HttpResponseMessage Create(ProductDTO product)
        {
            try
            {
                var isCreated = ProductService.Create(product);
                if (isCreated)
                {
                    return Request.CreateResponse(HttpStatusCode.Created, "Product created successfully");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Product creation failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpPut]
        [Route("api/product/update")]
        public HttpResponseMessage Update([FromBody] ProductDTO product)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                var isUpdated = ProductService.Update(product);
                if (isUpdated)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Product updated successfully");
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Product update failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }



        [HttpDelete]
        [Route("api/product/delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var isDeleted = ProductService.Delete(id);
                if (isDeleted)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Product deleted successfully");
                }
                return Request.CreateResponse(HttpStatusCode.NotFound, "Product not found or deletion failed");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, $"Error: {ex.Message}");
            }
        }



    }
}
