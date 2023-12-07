namespace EasyGroupChat.Clients
{
    public interface IClient
    {
        Guid ClientID { get; }
        Task SendTextAsync(string text, CancellationToken cancellationToken);
    }
}