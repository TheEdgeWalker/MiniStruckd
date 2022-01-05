namespace EditMode
{
    public interface ICommand
    {
        void Apply();
        void Rollback();
    }
}
