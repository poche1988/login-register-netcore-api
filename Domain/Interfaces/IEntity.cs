namespace Domain.Interfaces
{
    public interface IEntity : IHasId
    {
        bool IsActive { get; set; }
    }
}
