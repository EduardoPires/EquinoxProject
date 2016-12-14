namespace Equinox.Application.EventSourcedNormalizers
{
    public class CustomerHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string When { get; set; }
        public string Who { get; set; }
    }
}