
public interface IInitializable<in T> : IMediator
{
    void Initialize(T component);
}