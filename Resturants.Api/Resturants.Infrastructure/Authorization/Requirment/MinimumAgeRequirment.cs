﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Infrastructure.Authorization.Requirment
{
    public class MinimumAgeRequirment(int minimumAge) : IAuthorizationRequirement
    {
        public int MinimumAge { get;  } = minimumAge;

    }
}
