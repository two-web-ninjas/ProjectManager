using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.WebApiModels
{
    public class ApiResponse
    {
        public dynamic Errors { get; set; }
        public dynamic Data { get; set; }
        public dynamic Message { get; set; }
    }
}
