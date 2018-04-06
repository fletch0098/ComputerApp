using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace ComputerLibrary.Business_Logic
{
    

    public class ComputerBAL
    {
        private readonly ILogger<ComputerBAL> _logger;

        public ComputerBAL(ILogger<ComputerBAL> logger)
        {
            _logger = logger;
        }
        public void LogTest()
        {
            _logger.LogInformation("Test Log");
        }
            

    
    }
}
