﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingMallData
{
    public class FeedbackInfo
    {
        public string id { get; set; }
        public string item { get; set; }
        public DateTime feedDate { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string rate { get; set; }
        public string feedback { get; set; }
    }
}
