using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.Counter
{
    public class CounterState
    {
        public bool   IsLoading    { get; private set; }
        public bool   IsLoaded     { get; private set; }
        public string ErrorMessage { get; private set; }
        public int    CurrentCount { get; private set; }

        public CounterState(bool isLoading, bool isLoaded, string errorMessage, int currentCount)
        {
            CurrentCount = currentCount;
            IsLoaded     = isLoaded;
            ErrorMessage = errorMessage;
            IsLoading    = isLoading;
        }
    }
}