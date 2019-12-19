namespace GQL.Core.DomainContracts
{
    public interface IQuery<out TResponse> where TResponse : ResultBase { }
}
