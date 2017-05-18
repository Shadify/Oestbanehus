﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class BuildingWithCity
    {
        public int Id { get; set; }


        public string ZipCode { get; set; }


        public string Street { get; set; }

        public string City { get; set; }


    }
}