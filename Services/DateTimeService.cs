using System;
using System.Collections.Generic;
using System.Text;
using UiDesktopApp1.Interfaces;

namespace UiDesktopApp1.Services
{
    internal class DateTimeService : IDateTime
    {
        public DateTime? GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
