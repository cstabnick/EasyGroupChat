using EasyGroupChat.Clients;

namespace EasyGroupChat.Server
{
    public class Channel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Dictionary<Guid, IClient> Clients { get; set; }
    }
}
