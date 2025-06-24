namespace PropertyManagement.Data.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPropertyRepository Properties { get; }
        Task<int> SaveAsync();
    }
}
