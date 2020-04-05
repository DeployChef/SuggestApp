using System;

namespace SuggestService.Domain.Results
{
    public struct Result<TResult> where TResult : Enum
    {
        public TResult Value { get; }

        public string Message { get; }

        public Result(TResult value, string message = "")
        {
            Value = value;
            Message = message;
        }
    }

    public struct Result<TResult, TData> where TResult : Enum where TData : class
    {
        public TResult Value { get; }

        public TData Data { get; }

        public string Message { get; }

        public Result(TResult value, TData data = null, string message = "")
        {
            Value = value;
            Message = message;
            Data = data;
        }
    }
}
