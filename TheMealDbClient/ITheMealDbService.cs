namespace TheMealDbClient
{
    public interface ITheMealDbService
    {
        public Task<string> GetByName(string name);
        public Task<string> GetByFirstLetter(string firstLetter);
        public Task<string> GetById(string id);
        public Task<string> GetSingleRandom();
        public Task<string> GetCategories();
        public Task<string> GetListOf(string type); // c categories, a areas, i ingrediets
        public Task<string> FilterByMainIngredient(string mainIngredient);
        public Task<string> FilterBy(string filer);
    }
}
