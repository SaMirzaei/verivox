﻿using System;

namespace Verivox.Application.Exceptions
{
    public class ApiExceptions : Exception
    {
        public ApiExceptions(string message) : base(message)
        {
        }
    }
}
