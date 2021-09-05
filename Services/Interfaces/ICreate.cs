using Domain.Interfaces;
using Models;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICreate<T, M> where T:IHasId where M : IEntityUpsertModel
    {
        Task<T> Create(M model);
    }
}
