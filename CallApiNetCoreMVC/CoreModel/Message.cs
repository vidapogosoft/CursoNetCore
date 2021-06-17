using System;
using System.Collections.Generic;
using System.Text;

namespace CoreModel
{
    public class Message<T>
    {

        public bool IsSuccess { get; set; }
        public string ReturnMessage { get; set; }
        public T Data { get; set; }

    }
}
