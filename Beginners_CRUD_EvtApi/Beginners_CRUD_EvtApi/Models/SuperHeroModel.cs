namespace Beginners_CRUD_EvtApi.Models
{
    public class SuperHeroModel
    {
        public SuperHeroModel(string name, string firstName, string lastName, string place)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Place = place;
        }

        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
    }
}
