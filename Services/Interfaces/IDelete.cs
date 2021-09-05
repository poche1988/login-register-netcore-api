using Domain.Interfaces;

namespace Services.Interfaces
{
    public interface IDelete<T> where T:IHasId
    {
        void Delete(int id);
    }
}
