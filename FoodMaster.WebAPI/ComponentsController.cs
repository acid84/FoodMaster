using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using FoodMaster.Common;
using FoodMaster.Common.Entities;
using FoodMaster.Model;

namespace FoodMaster.WebAPI
{
	public class ComponentsController : ApiController
    {
	    private readonly ComponentsModel _model;
	    public ComponentsController()
	    {
		    _model = new ComponentsModel(new ComponentsStorage(new IsolatedStorageHelper()));
	    }

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
		        throw;
	        }
        }

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
		        
		        throw;
	        }
        }

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
		        throw;
	        }
        }

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
				throw;
			}
		}

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
		        throw;
	        }
        }
    }
}
