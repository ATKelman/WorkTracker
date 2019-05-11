using System;

namespace WpfBase
{
    public static class ActionExtensions
    {
        public static Action<object> AddErrorHandling(this Action<object> act, Action<Action<object>, Exception> onError)
        {
            return (obj) =>
            {
                try
                {
                    act(obj);
                }
                catch (Exception ex)
                {
                    onError(act, ex);
                }
            };
        }
    }
}
