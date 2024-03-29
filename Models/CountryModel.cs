using Newtonsoft.Json;

namespace CountryDropApp.Models
{
    public class CountryModel
    {
        public List<Country> countries { get; set; }
        public async Task<CountryModel> GetCountries()
        {
            var countrymodel=new CountryModel();
            using HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7257/Data/GetCountries");
            response.EnsureSuccessStatusCode(); // Throws exception if not successful
            var responseContent = await response.Content.ReadAsStringAsync();
            countrymodel.countries = JsonConvert.DeserializeObject<List<Country>>(responseContent);
            return countrymodel;
        }
        public async Task<List<State>> GetStatesByCountryId(int countryId)
        {
            using HttpClient httpClient = new HttpClient();
            string url = "https://localhost:7257/Data/GetStates/" + countryId;
            var response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode(); // Throws exception if not successful
            var responseContent = await response.Content.ReadAsStringAsync();
            var States= JsonConvert.DeserializeObject<List<State>>(responseContent);
            return States;
        }

    }
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<State> States { get; set; }
    }
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cid { get; set; }
        public Country Country { get; set; }
    }
}
