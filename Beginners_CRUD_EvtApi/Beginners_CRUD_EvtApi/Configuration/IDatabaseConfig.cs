namespace Beginners_CRUD_EvtApi.Configuration
{
    public interface IDatabaseConfig
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }

    }
}
