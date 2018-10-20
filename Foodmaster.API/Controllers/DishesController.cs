﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using FoodMaster.Common;
using FoodMaster.Common.Entities;
using FoodMaster.Model;
using Microsoft.AspNetCore.Mvc;

namespace Foodmaster.API.Controllers
{
    [Route("api/[controller]")]
    public class DishesController : ControllerBase
    {
        private readonly DishModel _model;
        public DishesController()
        {
            _model = new DishModel(new DishStorage(new IsolatedStorageHelper()));
        }

        [HttpGet]
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

        [HttpGet("{name}")]
        // GET api/values/5 
        public Dish Get(string name)
        {
            var dishTask = _model.GetDishAsync(name);
            dishTask.Wait();
            return dishTask.Result;
        }

        [HttpPost]
        // POST api/values 
        public HttpResponseMessage Post([FromBody]Dish dish)
        {
            var task = _model.AddDishAsync(dish);
            task.Wait();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpPut("{name}")]
        public HttpResponseMessage Put(string name, [FromBody] Dish dish)
        {
            var task = _model.UpdateDishAsync(name, dish);
            task.Wait();

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpDelete("{name}")]
        // DELETE api/values/5 
        public HttpResponseMessage Delete(string name)
        {
            var task = _model.DeleteDishAsync(name);
            task.Wait();

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
