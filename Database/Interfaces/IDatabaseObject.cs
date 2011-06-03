namespace Database.Interfaces
{
    public interface IDatabaseObject
    {
        void SetIdentifier(int id);

        int GetIdentifier();
    }
}