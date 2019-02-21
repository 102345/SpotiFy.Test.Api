using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeBlue.Ecommerce.Api2.ViewModels
{
    public class JsonViewModel
    {
        public bool Status { get; set; }
        public string Message { get; set; } = "";
        public string ProcessingTime { get; set; }
        public object Object { get; set; }
        public JsonViewModel() { }
    }
}