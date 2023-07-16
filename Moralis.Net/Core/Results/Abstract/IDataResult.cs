namespace Moralis.Net.Core.Results.Abstract
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
