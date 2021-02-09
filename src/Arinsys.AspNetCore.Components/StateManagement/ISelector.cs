using System;

namespace Arinsys.AspNetCore.Components.StateManagement
{
    public interface ISelector<TState> { }
    public interface ISelector<TState, TProjection> : ISelector<TState>
    {
        Func<TState, TProjection> Projection { get; }
    }
}
