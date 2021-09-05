using Domain.Interfaces;
using Models;

namespace Services.Interfaces
{
    public interface ICrudService<T, M> : IDelete<T>, IGetAll<T>, IGetById<T>, ICreate<T, M>, IEdit<T,M> where T : IHasId where M : IEntityUpsertModel
    {
    }
}
