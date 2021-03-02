namespace Rolfin.Result
{
    public interface IResult<T>
    {
        bool IsSuccess { get; }
        T Value { get; }
    }
}