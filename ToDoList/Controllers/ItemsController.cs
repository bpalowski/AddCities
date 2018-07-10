using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using MySql.Data.MySqlClient;

namespace ToDoList.Controllers
{
    public class ItemsController : Controller
    {

        [HttpGet("/items")]
        public ActionResult Index()
        {
        //  City newCity= new City(Request.Form["new-city"]);
         //SetUserInput(Request.Query["new-city"]);
         return View(City.GetAll());
        }

        [HttpGet("/items/new")]
        public ActionResult CreateForm()
        {
            return View();
        }
      //   [HttpPost("/items")]
      //   public ActionResult Create()
      //   {
      //
      //     return View("Index",City.SearchByCity(Request.Form["newcity"]));
      // }
        }
    }
