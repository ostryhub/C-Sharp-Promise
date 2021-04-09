using System;

namespace RSG
{
    public static class PromiseUtils
    {
        public static IPromise WhileDo(Func<bool> condition, Func<IPromise> statement)
        {
            return new WhileDoPromise(condition, statement);
        }
    }

    class WhileDoPromise : Promise
    {
        private Func<bool> _condition;
        private Func<IPromise> _statement;
        
        public WhileDoPromise(Func<bool> condition, Func<IPromise> statement)
        {
            _condition = condition;
            _statement = statement;
            
            Loop();
        }

        void Loop()
        {
            if (CurState != PromiseState.Pending) return;
            
            if (!_condition())
            {
                Resolve();
                return;
            }
            
            _statement()
                .Then(Loop)
                .Catch(Reject);
        }
    }
}
