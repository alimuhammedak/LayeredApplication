﻿using Entities.Abstract;
using System;
using System.Linq;

namespace Entities.Concrete
{
    public class Category : IEntity // Category is a concrete class that implements IEntity interface
    {
        public int Id { get; set; } // Primary Key
        public string CategoryName { get; set; }
    }
}