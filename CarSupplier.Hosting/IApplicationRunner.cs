using System.Threading;
using System.Threading.Tasks;

namespace CarSupplier.Hosting
{
    public interface IApplicationRunner
    {
        void Run();
        Task RunAsync(CancellationToken cancellationToken);
    }
}