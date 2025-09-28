using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Infrastructure.Authorization.Constants
{
    public static class PolicyNames
    {
        public const string HasNAtionality = "HasNationality";
        public const string AtLeast15 = "AtLeast15";

    }
    public static class AppClaimTypes
    {
        public const string Nationality = "Nationality";
        public const string DateOfBirth = "DateOfBirth";
        public const string AtLeast15 = "AtLeast15";
    }
}
