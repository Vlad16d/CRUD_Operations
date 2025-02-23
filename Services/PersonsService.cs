using System;
using Entities;
using ServiceContracts.DTO;
using ServiceContracts;
using System.ComponentModel.DataAnnotations;
using Services.Helpers;
using ServiceContracts.Enums;
using System.Text.RegularExpressions;

namespace Services
{
    public class PersonsService : IPersonsService
    {
        //private field
        private readonly List<Person> _persons;
        private readonly ICountriesService _countriesService;

        //constructor
        public PersonsService(bool initialize = true)
        {
            _persons = new List<Person>();
            _countriesService = new CountriesService();

            if (initialize)
            {
                _persons.Add(new Person() 
                { 
                    PersonID = Guid.Parse("E03C302E-E783-4177-8431-089BF873E502"),
                    PersonName = "Saundra", 
                    Email = "swoffenden0@blogs.com", 
                    DateOfBirth=DateTime.Parse("2005-02-17"),
                    Gender="Female", Address="1078 Sauthoff Place", 
                    ReceiveNewsLetters= true,
                    CountryID=Guid.Parse("BF0EDFA9-A2E9-4ABB-966C-0D8A2A8B1DAC")
                });

                _persons.Add(new Person()
                {
                    PersonID = Guid.Parse("482FFADC-4D13-4318-85C3-8B3B5182F064"),
                    PersonName = "Alfonse",
                    Email = "arosita1@xing.com",
                    DateOfBirth = DateTime.Parse("2002 - 05 - 16"),
                    Gender = "Male",
                    Address = "55483 Kipling Park",
                    ReceiveNewsLetters = true,
                    CountryID = Guid.Parse("F4D13F2B-BC8E-450D-A6A4-A3247F4E0066")
                });

                _persons.Add(new Person()
                {
                    PersonID = Guid.Parse("171F027D-53AE-4ED9-B8CA-2EB9820CC3F3"),
                    PersonName = "Giana",
                    Email = "gbatalle2@cloudflare.com",
                    DateOfBirth = DateTime.Parse("2003 - 03 - 02"),
                    Gender = "Female",
                    Address = "8 Amoth Lane",
                    ReceiveNewsLetters =false ,
                    CountryID = Guid.Parse("3D3ED32C-F98D-45A9-8D4C-A5B452B8A981")
                });                         


                _persons.Add(new Person()
                {
                    PersonID = Guid.Parse("02EA94BC-8961-42CD-89F1-E5C3B01B8E4B"),
                    PersonName = "Karlik",
                    Email = "khakewell3@ovh.net",
                    DateOfBirth = DateTime.Parse("2004 - 09 - 01"),
                    Gender = "Male",
                    Address = "419 Karstens Street",
                    ReceiveNewsLetters = false,
                    CountryID = Guid.Parse("F4D13F2B-BC8E-450D-A6A4-A3247F4E0066")
                });

                _persons.Add(new Person()
                {
                    PersonID = Guid.Parse("DB225312-5B3F-4919-AC40-83FBCF261789"),
                    PersonName = "Rik",
                    Email = "rmacmechan4@bizjournals.com",
                    DateOfBirth = DateTime.Parse(" 2000 - 09 - 13"),
                    Gender = "Male",
                    Address = "18269 Atwood Parkway",
                    ReceiveNewsLetters = true,
                    CountryID = Guid.Parse("3D3ED32C-F98D-45A9-8D4C-A5B452B8A981")
                });

                _persons.Add(new Person()
                {
                    PersonID = Guid.Parse("26E15B94-3AE0-4FE2-9498-AC615491C610"),
                    PersonName = "Rosella",
                    Email = "rfilgate5@bbb.org",
                    DateOfBirth = DateTime.Parse("2000 - 08 - 22"),
                    Gender = "Female",
                    Address = "976 Vernon Plaza",
                    ReceiveNewsLetters = false,
                    CountryID = Guid.Parse("BF0EDFA9-A2E9-4ABB-966C-0D8A2A8B1DAC")
                });

                _persons.Add(new Person()
                {
                    PersonID = Guid.Parse("F4B01667-2115-460C-95E4-D23195632B2D"),
                    PersonName = "Martie",
                    Email = "mblincow6@bandcamp.com",
                    DateOfBirth = DateTime.Parse("2001 - 07 - 24"),
                    Gender = "Male",
                    Address = "2155 Chive Park",
                    ReceiveNewsLetters = true,
                    CountryID = Guid.Parse("4125FCAF-038D-423C-BF95-572D39C176B1")
                });

                _persons.Add(new Person()
                {
                    PersonID = Guid.Parse("9261A76D-5FA5-4E7F-8DDD-CABD7DD1BDAB"),
                    PersonName = " Kimberli",
                    Email = "kslowey7@cyberchimps.com",
                    DateOfBirth = DateTime.Parse("2004 - 08 - 29"),
                    Gender = "Female",
                    Address = "8 Ridge Oak Park",
                    ReceiveNewsLetters =true ,
                    CountryID = Guid.Parse("F4D13F2B-BC8E-450D-A6A4-A3247F4E0066")
                });

                _persons.Add(new Person()
                {
                    PersonID = Guid.Parse("A7F188E8-D401-42AF-B0F1-E17DC24D64E8"),
                    PersonName = "Stephie",
                    Email = "svannikov8@ycombinator.com",
                    DateOfBirth = DateTime.Parse("2003 - 03 - 20"),
                    Gender = "Female",
                    Address = "006 Portage Trail",
                    ReceiveNewsLetters = false,
                    CountryID = Guid.Parse("BF0EDFA9-A2E9-4ABB-966C-0D8A2A8B1DAC")
                });

                _persons.Add(new Person()
                {
                    PersonID = Guid.Parse("F159B41D-5949-4148-8807-9EA8377E4CBB"),
                    PersonName = "Byron",
                    Email = "blamasna9@liveinternet.ru",
                    DateOfBirth = DateTime.Parse("2001 - 06 - 12"),
                    Gender = "Male",
                    Address = "6 Marcy Drive",
                    ReceiveNewsLetters = false,
                    CountryID = Guid.Parse("AF0AEC6F-7BF1-4E15-A7F0-646AABE079AA")
                });
            }
        }


        private PersonResponse ConvertPersonToPersonResponse(Person person)
        {
            PersonResponse personResponse = person.ToPersonResponse();
            personResponse.Country = _countriesService.GetCountryByCountryID(person.CountryID)?.CountryName;
            return personResponse;
        }

        public PersonResponse AddPerson(PersonAddRequest? personAddRequest)
        {
            //check if PersonAddRequest is not null
            if (personAddRequest == null)
            {
                throw new ArgumentNullException(nameof(personAddRequest));
            }

            //Model validation
            ValidationHelper.ModelValidation(personAddRequest);

            //convert personAddRequest into Person type
            Person person = personAddRequest.ToPerson();

            //generate PersonID
            person.PersonID = Guid.NewGuid();

            //add person object to persons list
            _persons.Add(person);

            //convert the Person object into PersonResponse type
            return ConvertPersonToPersonResponse(person);
        }


        public List<PersonResponse> GetAllPersons()
        {
            return _persons.Select(temp => ConvertPersonToPersonResponse(temp)).ToList();
        }


        public PersonResponse? GetPersonByPersonID(Guid? personID)
        {
            if (personID == null)
                return null;

            Person? person = _persons.FirstOrDefault(temp => temp.PersonID == personID);
            if (person == null)
                return null;

            return ConvertPersonToPersonResponse(person);
        }

        public List<PersonResponse> GetFilteredPersons(string searchBy, string? searchString)
        {
            List<PersonResponse> allPersons = GetAllPersons();
            List<PersonResponse> matchingPersons = allPersons;

            if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchString))
                return matchingPersons;


            switch (searchBy)
            {
                case nameof(PersonResponse.PersonName):
                    matchingPersons = allPersons.Where(temp =>
                    (!string.IsNullOrEmpty(temp.PersonName) ?
                    temp.PersonName.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PersonResponse.Email):
                    matchingPersons = allPersons.Where(temp =>
                    (!string.IsNullOrEmpty(temp.Email) ?
                    temp.Email.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;


                case nameof(PersonResponse.DateOfBirth):
                    matchingPersons = allPersons.Where(temp =>
                    (temp.DateOfBirth != null) ?
                    temp.DateOfBirth.Value.ToString("dd MMMM yyyy").Contains(searchString, StringComparison.OrdinalIgnoreCase) : true).ToList();
                    break;

                case nameof(PersonResponse.Gender):
                    matchingPersons = allPersons.Where(temp =>
                    (!string.IsNullOrEmpty(temp.Gender) ?
                    temp.Gender.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PersonResponse.CountryID):
                    matchingPersons = allPersons.Where(temp =>
                    (!string.IsNullOrEmpty(temp.Country) ?
                    temp.Country.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                case nameof(PersonResponse.Address):
                    matchingPersons = allPersons.Where(temp =>
                    (!string.IsNullOrEmpty(temp.Address) ?
                    temp.Address.Contains(searchString, StringComparison.OrdinalIgnoreCase) : true)).ToList();
                    break;

                default: matchingPersons = allPersons; break;
            }
            return matchingPersons;
        }


        public List<PersonResponse> GetSortedPersons(List<PersonResponse> allPersons, string sortBy, SortOrderOptions sortOrder)
        {
            if (string.IsNullOrEmpty(sortBy))
                return allPersons;

            List<PersonResponse> sortedPersons = (sortBy, sortOrder) switch
            {
                (nameof(PersonResponse.PersonName), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.PersonName), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.PersonName, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Email), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Email), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Email, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.DateOfBirth).ToList(),

                (nameof(PersonResponse.DateOfBirth), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.DateOfBirth).ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Age).ToList(),

                (nameof(PersonResponse.Age), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Age).ToList(),

                (nameof(PersonResponse.Gender), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Gender), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Gender, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Country), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Country, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Country), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Country, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.Address), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.Address, StringComparer.OrdinalIgnoreCase).ToList(),

                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.ASC) => allPersons.OrderBy(temp => temp.ReceiveNewsLetters).ToList(),

                (nameof(PersonResponse.ReceiveNewsLetters), SortOrderOptions.DESC) => allPersons.OrderByDescending(temp => temp.ReceiveNewsLetters).ToList(),

                _ => allPersons
            };

            return sortedPersons;
        }


        public PersonResponse UpdatePerson(PersonUpdateRequest? personUpdateRequest)
        {
            if (personUpdateRequest == null)
                throw new ArgumentNullException(nameof(Person));

            //validation
            ValidationHelper.ModelValidation(personUpdateRequest);

            //get matching person object to update
            Person? matchingPerson = _persons.FirstOrDefault(temp => temp.PersonID == personUpdateRequest.PersonID);
            if (matchingPerson == null)
            {
                throw new ArgumentException("Given person id doesn't exist");
            }

            //update all details
            matchingPerson.PersonName = personUpdateRequest.PersonName;
            matchingPerson.Email = personUpdateRequest.Email;
            matchingPerson.DateOfBirth = personUpdateRequest.DateOfBirth;
            matchingPerson.Gender = personUpdateRequest.Gender.ToString();
            matchingPerson.CountryID = personUpdateRequest.CountryID;
            matchingPerson.Address = personUpdateRequest.Address;
            matchingPerson.ReceiveNewsLetters = personUpdateRequest.ReceiveNewsLetters;

            return ConvertPersonToPersonResponse(matchingPerson);
        }

        public bool DeletePerson(Guid? personID)
        {
            if (personID == null)
            {
                throw new ArgumentNullException(nameof(personID));
            }

            Person? person = _persons.FirstOrDefault(temp => temp.PersonID == personID);
            if (person == null)
                return false;

            _persons.RemoveAll(temp => temp.PersonID == personID);

            return true;
        }
    }
}