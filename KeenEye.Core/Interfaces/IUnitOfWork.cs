

namespace KeenEye.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IUserRepository Users { get; }

        int Save();
    }
}
