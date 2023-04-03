namespace InputReader
{
    public interface IEntityInputSource
    {
        float HorizontalMove { get; }

        bool Jump { get; }

        void ResetActions();
        
    }
}
