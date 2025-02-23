using Entities;
using ServiceContracts;
using ServiceContracts.DTO;

namespace Services
{
    public class CountriesService : ICountriesService
    {
        //private field
        private readonly List<Country> _countries;

        //constructor
        public CountriesService(bool initialize = true)
        {
            _countries = new List<Country>();
            if (initialize)
            {
                _countries.AddRange(new List<Country>() {
                new Country() { CountryID = Guid.Parse("BF0EDFA9-A2E9-4ABB-966C-0D8A2A8B1DAC"), CountryName = "USA" },
                new Country() { CountryID = Guid.Parse("3D3ED32C-F98D-45A9-8D4C-A5B452B8A981"), CountryName = "Mexico" },
                new Country() { CountryID = Guid.Parse("4125FCAF-038D-423C-BF95-572D39C176B1"), CountryName = "Belarus" },
                new Country() { CountryID = Guid.Parse("E4BF9029-4F57-41E0-A622-DE128A69CFF6"), CountryName = "Poland" },
                new Country() { CountryID = Guid.Parse("F4D13F2B-BC8E-450D-A6A4-A3247F4E0066"), CountryName = "Czechy" },
                new Country() { CountryID = Guid.Parse("AF0AEC6F-7BF1-4E15-A7F0-646AABE079AA"), CountryName = "UK" }
                });
            }
        }
        public CountryResponse AddCountry(CountryAddRequest? countryAddRequest)
        {

            //Validation: countryAddRequest parameter can't be null
            if (countryAddRequest == null)
            {
                throw new ArgumentNullException(nameof(countryAddRequest));
            }

            //Validation: CountryName can't be null
            if (countryAddRequest.CountryName == null)
            {
                throw new ArgumentException(nameof(countryAddRequest.CountryName));
            }

            //Validation: CountryName can't be duplicate
            if (_countries.Where(temp => temp.CountryName == countryAddRequest.CountryName).Count() > 0)
            {
                throw new ArgumentException("Given country name already exists");
            }

            //Convert object from CountryAddRequest to Country type
            Country country = countryAddRequest.ToCountry();

            //generate CountryID
            country.CountryID = Guid.NewGuid();

            //Add country object into _countries
            _countries.Add(country);

            return country.ToCountryResponse();
        }

        public List<CountryResponse> GetAllCountries()
        {
            return _countries.Select(country => country.ToCountryResponse()).ToList();
        }

        public CountryResponse? GetCountryByCountryID(Guid? countryID)
        {
            if (countryID == null)
                return null;

            Country? country_response_from_list = _countries.FirstOrDefault(temp => temp.CountryID == countryID);

            if (country_response_from_list == null)
                return null;

            return country_response_from_list.ToCountryResponse();
        }
    }
}
