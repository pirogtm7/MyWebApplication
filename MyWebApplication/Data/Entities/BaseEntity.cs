﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApplication.Data.Entities
{
	public abstract class BaseEntity : IBaseEntity
	{
		public int Id { get; set; }

	}
}
