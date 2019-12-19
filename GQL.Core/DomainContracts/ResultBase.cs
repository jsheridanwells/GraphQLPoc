using System;
using System.Collections.Generic;
using System.Text;

namespace GQL.Core.DomainContracts
{
    public abstract class ResultBase
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; }
        
    }
}
