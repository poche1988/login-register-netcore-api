using Domain.Interfaces;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IGetAll<T> where T : IHasId
    {
        IEnumerable<T> GetAll();
    }
}
