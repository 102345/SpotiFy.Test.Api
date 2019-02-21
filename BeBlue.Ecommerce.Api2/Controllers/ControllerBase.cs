using BeBlue.Ecommerce.Api2.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeBlue.Ecommerce.Api2.Controllers
{

    public class ControllerBase : ApiController
    {
        private Stopwatch _stopWatch;
        private JsonViewModel _jsonResult;

        public Stopwatch StopWatch
        {
            get
            {
                return _stopWatch;
            }
            set
            {
                _stopWatch = value;
            }
        }
        public JsonViewModel JsonResult
        {
            get
            {
                return _jsonResult;
            }
            set
            {
                _jsonResult = value;
            }
        }

        public ControllerBase()
        {
            _stopWatch = new Stopwatch();
            _jsonResult = new JsonViewModel();
        }
    }
}

