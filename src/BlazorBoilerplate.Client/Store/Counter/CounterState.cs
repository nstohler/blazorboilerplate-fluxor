using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Client.Store.Counter
{
    public class CounterState : ICounterState
    {
        //public bool   IsLoading    { get; private set; }
        //public bool   IsLoaded     { get; private set; }
        //public string ErrorMessage { get; private set; }
        //public int    CurrentCount { get; private set; }

        public bool   IsLoading    { get; set; }
        public bool   IsLoaded     { get; set; }
        public string ErrorMessage { get; set; }
        public int    CurrentCount { get; set; }

        public DateTime LastSuccessCounterPostTime { get; set; }

        public CounterState(bool isLoading, bool isLoaded, string errorMessage, int currentCount, DateTime lastSuccessCounterPostTime)
        {
            CurrentCount = currentCount;
            IsLoaded     = isLoaded;
            ErrorMessage = errorMessage;
            IsLoading    = isLoading;
        }

        public static CounterState CreateNew()
        {
            return new CounterState(false, false, null, 0, DateTime.UtcNow);
        }
    }

    public interface ICounterState
    {
        bool IsLoading { get; }
        bool IsLoaded { get; }
        string ErrorMessage { get; }
        int CurrentCount { get; }
        DateTime LastSuccessCounterPostTime { get; }
    }
}