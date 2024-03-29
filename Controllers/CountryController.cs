using CountryDropApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CountryDropApp.Controllers
{
    public class CountryController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await new CountryModel().GetCountries();
            return View(result);
        }
        [HttpGet]
        public async Task<List<State>> GetStates(int countryId)
        {
            var states = await new CountryModel().GetStatesByCountryId(countryId); // Fetch states from your database
            return states;
        }
    }
}
