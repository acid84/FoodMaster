using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using FoodMaster.Common;
using FoodMaster.Common.Entities;
using FoodMaster.Model;
using Microsoft.AspNetCore.Mvc;

namespace FoodMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentsController : ControllerBase
    {
	    private readonly ComponentsModel _model;
	    public ComponentsController()
	    {
		    _model = new ComponentsModel(new ComponentsStorage(new IsolatedStorageHelper()));
	    }

        [HttpGet]
        // GET api/values 
        public IEnumerable<Component> Get()
        {
	        try
	        {
				var componentsTask = _model.GetAllComponentsAsync();
				componentsTask.Wait();

		        return componentsTask.Result;
	        }
			catch (Exception)
	        {
	            Console.WriteLine("This should be fixed in the future to return proper errors.");
                throw;
	        }
        }

        [HttpGet("{name}")]
        // GET api/values/5 
        public Component Get(string name)
        {
	        try
	        {
		        var componentTask = _model.GetComponentAsync(name);
		        componentTask.Wait();
		        return componentTask.Result;
	        }
	        catch (Exception)
	        {
	            Console.WriteLine("This should be fixed in the future to return proper errors.");
                throw;
	        }
        }

        [HttpPost]
        // POST api/values 
        public HttpResponseMessage Post([FromBody]Component component)
        {
	        try
	        {
		        var task =_model.AddComponentAsync(component);
		        task.Wait();

				return new HttpResponseMessage(HttpStatusCode.Created);
	        }
	        catch (Exception)
	        {
	            Console.WriteLine("This should be fixed in the future to return proper errors.");
                throw;
	        }
        }

        [HttpPut("{name}")]
		public HttpResponseMessage Put(string name,[FromBody] Component component)
		{
			try
			{
				var task = _model.UpdateComponentAsync(name, component);
				task.Wait();

				return new HttpResponseMessage(HttpStatusCode.Created);
			}
			catch (Exception)
			{
			    Console.WriteLine("This should be fixed in the future to return proper errors.");
                throw;
			}
		}

        [HttpDelete("{name}")]
        // DELETE api/values/5 
        public HttpResponseMessage Delete(string name)
        {
	        try
	        {
		        var task = _model.DeleteComponent(name);
		        task.Wait();

				return new HttpResponseMessage(HttpStatusCode.OK);
			}
			catch (Exception)
	        {
	            Console.WriteLine("This should be fixed in the future to return proper errors.");
		        throw;
	        }
        }
    }
}
