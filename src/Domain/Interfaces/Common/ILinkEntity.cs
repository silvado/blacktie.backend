namespace Domain.Interfaces.Common
{
    public interface ILinkEntity<T>
    {
        T GetEntity();
        int GetEntityId();        
        Guid GetEntityIdGuid();
        void SetEntityId(int id);
        void SetEntityIdGuid(Guid id);
    }
}
