using Domain.Interfaces;

namespace Services.Interfaces
{
    public interface IGetById<T> where T : IHasId
    {
        T GetById(int id);
    }
}
