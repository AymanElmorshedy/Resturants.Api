using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturants.Domain.Exceptions
{
    public sealed class NotFoundException(string resourceType,string resourceIdentifier) :
        Exception($"{resourceType} with id : {resourceIdentifier} doesn't exist")
    {
    }
}
