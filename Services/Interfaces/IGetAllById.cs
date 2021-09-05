using Domain.Interfaces;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IGetAllById<T> where T : IHasId
    {
        IEnumerable<T> GetAllById(int id);
    }
}
