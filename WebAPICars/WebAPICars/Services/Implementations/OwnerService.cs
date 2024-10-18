using WebAPICars.DTOs.OwnerDTOs;
using WebAPICars.Models;
using WebAPICars.Queries;
using WebAPICars.Repositories.Interfaces;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Services.Implementations
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

       

        public IQueryable<Owner> GetAllOwners(OwnerQueries ownerQueries)
        {
            var owners = _ownerRepository.GetAllOwners();

            if (!string.IsNullOrWhiteSpace(ownerQueries.FirstName)) 
            {
                owners = owners.Where(o => o.FirstName.Contains(ownerQueries.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(ownerQueries.LastName))
            {
                owners = owners.Where(o => o.LastName.Contains(ownerQueries.LastName));
            }

            if(ownerQueries.Age != null)
            {
                owners = owners.Where(o => o.Age.Equals(ownerQueries.Age));
            }

            if (!string.IsNullOrWhiteSpace(ownerQueries.Address))
            {
                owners = owners.Where(o => o.Address.Contains(ownerQueries.Address));

            }

            if (!string.IsNullOrWhiteSpace(ownerQueries.PhoneNumber))
            {
                owners = owners.Where(o => o.PhoneNumber.Contains(ownerQueries.PhoneNumber));
            }

            if (!string.IsNullOrWhiteSpace(ownerQueries.Email))
            {
                owners = owners.Where(o => o.Email.Contains(ownerQueries.Email));
            }

            if (!string.IsNullOrWhiteSpace(ownerQueries.SortBy)) 
            {
                if(ownerQueries.SortBy == "FirstName")
                {
                    if (ownerQueries.IsDescending)
                    {
                        owners = owners.OrderByDescending(o => o.FirstName);
                    }
                    else
                    {
                        owners = owners.OrderBy(o => o.FirstName);

                    }
                }

                if (ownerQueries.SortBy == "LastName")
                {
                    if (ownerQueries.IsDescending)
                    {
                        owners = owners.OrderByDescending(o => o.LastName);
                    }
                    else
                    {
                        owners = owners.OrderBy(o => o.LastName);

                    }
                }

                if (ownerQueries.SortBy == "Age")
                {
                    if (ownerQueries.IsDescending)
                    {
                        owners = owners.OrderByDescending(o => o.Age);
                    }
                    else
                    {
                        owners = owners.OrderBy(o => o.Age);

                    }
                }

                if (ownerQueries.SortBy == "Address")
                {
                    if (ownerQueries.IsDescending)
                    {
                        owners = owners.OrderByDescending(o => o.Address);
                    }
                    else
                    {
                        owners = owners.OrderBy(o => o.Address);

                    }
                }

                if (ownerQueries.SortBy == "PhoneNumber")
                {
                    if (ownerQueries.IsDescending)
                    {
                        owners = owners.OrderByDescending(o => o.PhoneNumber);
                    }
                    else
                    {
                        owners = owners.OrderBy(o => o.PhoneNumber);

                    }
                }

                if (ownerQueries.SortBy == "Email")
                {
                    if (ownerQueries.IsDescending)
                    {
                        owners = owners.OrderByDescending(o => o.Email);
                    }
                    else
                    {
                        owners = owners.OrderBy(o => o.Email);

                    }
                }

            }

            var skipNumber = (ownerQueries.PageNumber - 1) * ownerQueries.PageSize;
            var takeNumber = ownerQueries.PageSize;

            return owners.Skip(skipNumber).Take(takeNumber);
        }

        public async Task<Owner> GetOwnerByIdAsync(int? id)
        {
            var owner = await _ownerRepository.GetOwnerByIdAsync(id);

            return owner;
        }

        public async Task PostOwnerAsync(Owner owner)
        {
            await _ownerRepository.PostOwnerAsync(owner);
            await _ownerRepository.SaveChangesAsync();
        }

        public async Task PutOwner(Owner owner, OwnerPutDTO ownerPutDTO)
        {
            _ownerRepository.PutOwner(owner, ownerPutDTO);
            await _ownerRepository.SaveChangesAsync();
        }

        public async Task DeleteOwner(Owner owner)
        {
            _ownerRepository.DeleteOwner(owner);
            await _ownerRepository.SaveChangesAsync();
        }

        public bool OwnerExists(int id)
        {
            return _ownerRepository.GetAllOwners().Any(o => o.OwnerId == id);
        }

        public bool PhoneNumberExists(string phoneNumber)
        {
            return _ownerRepository.GetAllOwners().Any(o => o.PhoneNumber == phoneNumber);
        }

        public bool EmailExists(string email)
        {
            return _ownerRepository.GetAllOwners().Any(o => o.Email == email);
        }
    }
}
