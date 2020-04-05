using System;
using System.Collections.Generic;
using System.Text;

namespace SuggestService.Domain
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

    public struct Result<TResult, TModel> where TResult : Enum where TModel : class
    {
        public TResult Value { get; }

        public TModel Model { get; }

        public string Message { get; }

        public Result(TResult value, TModel model = null, string message = "")
        {
            Value = value;
            Message = message;
            Model = model;
        }
    }
}
