using System.Threading.Tasks;

namespace Arinsys.AspNetCore.Components.StateManagement
{
    /// <summary>Identifies a class that is used to perform operations after the reducer completes the execution of a specific action</summary>
    /// <typeparam name="TState">The class type of the state this effect operates on</typeparam>
    public interface IEffect<TState>
    {
        /// <summary>This method is executed by the store immediately after reducer completes the execution of a specific action</summary>
        /// <param name="previousState">The state prior to reducer executing the action</param>
        /// <param name="currentState">The current state after the reducer completes the action</param>
        /// <param name="action">The action that was dispatched</param>
        Task HandleAsync(TState previousState, TState currentState, object action);

        /// <summary>Indicates whether or not the effect should react to a specific action dispatched through the store</summary>
        /// <param name="action">The action that is being dispatched through the store</param>
        /// <returns>True if the <see cref="HandleAsync(object, IDispatcher)"/> method should be called</returns>
        bool ShouldReactToAction(object action);
    }

    public abstract class Effect<TState, TAction> : IEffect<TState> where TAction : IAction<TState>
    {
        public bool ShouldReactToAction(object action)
        {
            return action is TAction;
        }

        /// <summary>This method is executed by the store immediately after reducer completes the execution of a specific action</summary>
        /// <param name="previousState">The state prior to reducer executing the action</param>
        /// <param name="currentState">The current state after the reducer completes the action</param>
        /// <param name="action">The action that was dispatched</param>
        public abstract Task HandleAsync(TState previousState, TState currentState, TAction action);

        Task IEffect<TState>.HandleAsync(TState previousState, TState currentState, object action)
        {
            return HandleAsync(previousState, currentState, (TAction)action);
        }
    }
}
