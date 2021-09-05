using Domain.Interfaces;
using Models;

namespace Services.Interfaces
{
    public interface IEdit<T, M> where T:IHasId where M : IEntityUpsertModel
    {
        T Edit(M model);
    }
}
