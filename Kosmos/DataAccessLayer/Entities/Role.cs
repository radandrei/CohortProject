﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}