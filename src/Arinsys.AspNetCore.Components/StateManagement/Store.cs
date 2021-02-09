using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;

namespace Arinsys.AspNetCore.Components.StateManagement
{
    public interface IStore<TState> where TState : class
    {
        IObservable<TState> Select();
        IObservable<TProjection> Select<TProjection>() where TProjection : class;
        Task DispatchAsync<TAction>(TAction action) where TAction : IAction<TState>;
    }

    public class Store<TState> : IStore<TState> where TState : class
    {
        private readonly BehaviorSubject<TState> state = new BehaviorSubject<TState>(default);
        private readonly IEnumerable<ISelector<TState>> selectors;
        private readonly IEnumerable<IReducer<TState>> reducers;
        private readonly IEnumerable<IEffect<TState>> effects;

        public Store(IEnumerable<ISelector<TState>> selectors, IEnumerable<IReducer<TState>> reducers, IEnumerable<IEffect<TState>> effects)
        {
            this.selectors = selectors;
            this.reducers = reducers;
            this.effects = effects;
        }

        public IObservable<TState> Select()
        {
            return Select<TState>();
        }

        public IObservable<TProjection> Select<TProjection>() where TProjection : class
        {
            if (typeof(TProjection) == typeof(TState))
            {
                return state.Select(currentState => currentState as TProjection);
            }
            return state.Select(selectors.OfType<ISelector<TState, TProjection>>().Single().Projection);
        }

        public async Task DispatchAsync<TAction>(TAction action) where TAction : IAction<TState>
        {
            TState previousState = state.Value;
            TState newState = state.Value;
            Reducer<TState, TAction> reducer = reducers.OfType<Reducer<TState, TAction>>().Single();
            if (reducer.ShouldReduceStateForAction(action))
            {
                newState = reducer.Reduce(previousState, action);
            }

            IEnumerable<Effect<TState, TAction>> eligibleEffects = effects.OfType<Effect<TState, TAction>>().Where(x => x.ShouldReactToAction(action));
            if (eligibleEffects.Any())
            {
                await Task.WhenAll(eligibleEffects.Select(x => x.HandleAsync(previousState, newState, action)));
            }
            state.OnNext(newState);
        }
    }
}
