using System;

namespace RSG
{
    public class CancelToken : IDisposable
    {
        public event Action onCanceled;

        private bool _isCanceled = false;
        public bool IsCanceled => _isCanceled;

        public void Dispose()
        {
            if (_isCanceled) return;
            _isCanceled = true;

            try
            {
                onCanceled?.Invoke();
            }
            finally
            {
                onCanceled = null;
            }
        }
    }
}