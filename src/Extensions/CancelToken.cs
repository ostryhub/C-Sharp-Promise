using System;

namespace RSG
{
    public class CancelToken
    {
        public event Action onCanceled;
    
        public void Cancel()
        {
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