﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AssetManagementWeb.Models
{
    public class AssignLocationModel
    {
        public string AssetCode { get; set; }
        public string LocationCode { get; set; }
    }
}