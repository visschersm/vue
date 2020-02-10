namespace ViewModels.Interfaces
{
    public interface IId<TKey>
    {
        TKey Id { get; set; }
    }
}
