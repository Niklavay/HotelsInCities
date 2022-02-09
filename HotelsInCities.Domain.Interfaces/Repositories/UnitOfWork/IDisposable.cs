using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelsInCities.Domain.Interfaces.Repositories.UnitOfWork
{
    public interface IDisposable
    {
        void Dispose();
    }
}
