﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGear.Api.Models
{
    public class Request<T> : BaseRequest 
    {
        public T Dados { get; set; } 
    }
}
