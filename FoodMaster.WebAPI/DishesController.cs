using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FoodMaster.Common;
using FoodMaster.Common.Entities;
using FoodMaster.Model;

namespace FoodMaster.WebAPI
{
	public class DishesController : ApiController
	{
		private readonly DishModel _model;
		public DishesController()
		{
			_model = new DishModel(new DishStorage(new IsolatedStorageHelper()));
		}

		// GET api/values 
		public IEnumerable<Dish> Get()
		{
			try
			{
				var dishesTask = _model.GetAllDishesAsync();
				dishesTask.Wait();

				return dishesTask.Result;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		// GET api/values/5 
		public Dish Get(string name)
		{
			try
			{
				var dishTask = _model.GetDishAsync(name);
				dishTask.Wait();
				return dishTask.Result;
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		// POST api/values 
		public HttpResponseMessage Post([FromBody]Dish dish)
		{
			try
			{
				var task = _model.AddDishAsync(dish);
				task.Wait();

				return new HttpResponseMessage(HttpStatusCode.Created);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		public HttpResponseMessage Put(string name, [FromBody] Dish dish)
		{
			try
			{
				var task = _model.UpdateDishAsync(name, dish);
				task.Wait();

				return new HttpResponseMessage(HttpStatusCode.Created);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		// DELETE api/values/5 
		public HttpResponseMessage Delete(string name)
		{
			try
			{
				var task = _model.DeleteDishAsync(name);
				task.Wait();

				return new HttpResponseMessage(HttpStatusCode.OK);
			}
			catch (Exception ex)
			{
				throw;
			}
		}
	}
}
