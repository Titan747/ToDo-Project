﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApi.Models
{
	public class ToDoContext : DbContext
	{
		public ToDoContext(DbContextOptions options)
		   : base(options)
		{
		}
		public DbSet<ToDo> ToDos { get; set; }
	}
}
