using System.Text.RegularExpressions;

namespace SettlementBookingSystem.Application.Common.Statics
{
    public static class Static
    {
        public static Regex HourFormatRegex = new ("[0-9]{1,2}:[0-9][0-9]");
    }
}