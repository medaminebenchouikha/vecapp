using System;

namespace src.VecRepositories.Abstractions
{
    public interface IEntityRepository : IDisposable
    {
        bool Disposed { get; }
    }
}