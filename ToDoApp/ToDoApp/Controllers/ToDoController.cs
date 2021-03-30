using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Controllers
{
	public class ToDoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult AddToDo()
		{
			return View();
		}
		public IActionResult UpdateToDo()
		{
			return View();
		}
		public IActionResult DeleteToDo()
		{
			return View();
		}
	}
}
