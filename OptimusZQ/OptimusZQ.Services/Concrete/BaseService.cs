using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace OptimusZQ.Services.Concrete
{
    public class BaseService
    {
        protected readonly IOptions<AppSettings> _options;
        public BaseService(IOptions<AppSettings> options)
        {
            _options = options;
        }
    }
}
