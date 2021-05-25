using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ApiProcessingResult
    {
        public ApiProcessingResult() { }
       
        public List<ApiProcessingError> Errors { get; set; } = new List<ApiProcessingError>();
        public bool IsError { get; set; } = false;
         
        
    }

    public class ApiProcessingResult<TReturnedData> : ApiProcessingResult
    {
        public ApiProcessingResult() { }
        public TReturnedData Data { get; set; }
    }
}
