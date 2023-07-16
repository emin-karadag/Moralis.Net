﻿namespace Moralis.Net.Core.Results.Concrete
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message, 0)
        {
        }

        public SuccessResult() : base(true)
        {
        }
    }
}
