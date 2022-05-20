﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConvertClient.Services
{
    public class ServiceResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }
        public bool HasErrors => StatusCode != HttpStatusCode.OK;
    }
}
