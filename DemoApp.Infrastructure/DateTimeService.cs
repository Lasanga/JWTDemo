using DemoApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Infrastructure
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
