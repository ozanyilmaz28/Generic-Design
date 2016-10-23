using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GenericDesign.Models
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }

        public T Data { get; set; }

        public List<string> Errors = new List<string>();
    }
}