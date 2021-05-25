using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Core;


using Utilities;

namespace Services {
    public class BaseDataService {
      public  BaseDataService()
        {
            log = LogManager.GetCurrentClassLogger();
        }
        protected Logger log { get; set; }
    }
}
