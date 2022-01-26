using Orleans;

namespace OrleansOnContainerApps.Abstractions
{
    public interface IVisitorGrain : IGrainWithStringKey
    {
        Task SetVisitor(Visitor visitor);
        Task<Visitor> GetVisitor(string key);
    }
}
