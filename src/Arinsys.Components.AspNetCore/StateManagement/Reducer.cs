namespace Arinsys.Components.AspNetCore.StateManagement
{
    /// <summary>Identifies a class that is used to update state based on the execution of a specific action</summary>
	/// <typeparam name="TState">The class type of the state this reducer operates on</typeparam>
    public interface IReducer<TState>
    {
        /// <summary>Takes the current state and the action dispatched and returns a new state</summary>
        /// <param name="state">The current state</param>
        /// <param name="action">The action dispatched via the store</param>
        /// <returns>The new state based on the current state + the changes the action should cause</returns>
        public TState Reduce(TState currentState, object action);

        /// <summary>Indicates whether or not this reducer intends to alter state based on the action</summary>
		/// <param name="action">The action being dispatched via the store</param>
		/// <returns>True if the reducer should be executed</returns>
		bool ShouldReduceStateForAction(object action);
    }

    /// <summary>A generic implementation of a reducer</summary>
	/// <typeparam name="TState">The state that this reducer works with</typeparam>
	/// <typeparam name="TAction">The action type this reducer responds to</typeparam>
    public abstract class Reducer<TState, TAction> : IReducer<TState> where TAction : IAction<TState>
    {
        /// <summary>Reduces state in reaction to the action dispatched via the store</summary>
		/// <param name="currentState">The current state</param>
		/// <param name="action">The action dispatched via the store</param>
		/// <returns>The new state based on the current state + the changes the action should cause</returns>
        public abstract TState Reduce(TState currentState, TAction action);

        public bool ShouldReduceStateForAction(object action)
        {
            return action is TAction;
        }

        TState IReducer<TState>.Reduce(TState currentState, object action)
        {
            return Reduce(currentState, (TAction)action);
        }
    }
}
