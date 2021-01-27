namespace RSG
{
    internal static class IPromise_NonGenericExtension
    {
        internal static IPromise SetCancelToken(this IPromise promise, CancelToken cancelToken)
        {
            return (promise as Promise).SetCancelToken(cancelToken);
        }
    }
    
        
    internal static class IPromiseExtension
    {
        internal static IPromise<PromisedT> SetCancelToken<PromisedT>(this IPromise<PromisedT> promise, CancelToken cancelToken)
        {
            return (promise as Promise<PromisedT>).SetCancelToken(cancelToken);
        }
    }

}