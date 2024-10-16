﻿using WebAPICars.DTOs.OwnerDTOs;
using WebAPICars.Models;

namespace WebAPICars.Mappers
{
    public static class OwnerMapper
    {
        public static OwnerListDTO ToOwnerListDTO(this Owner ownerModel)
        {
            return new OwnerListDTO
            {
                OwnerId = ownerModel.OwnerId,
                FirstName = ownerModel.FirstName,
                LastName = ownerModel.LastName,
                Age = ownerModel.Age,
                Address = ownerModel.Address,
                PhoneNumber = ownerModel.PhoneNumber,
                Email = ownerModel.Email
            };
        }

        public static OwnerGetDTO ToOwnerGetDTO(this Owner ownerModel) 
        {
            return new OwnerGetDTO
            {
                OwnerId = ownerModel.OwnerId,
                FirstName = ownerModel.FirstName,
                LastName = ownerModel.LastName,
                Age = ownerModel.Age,
                Address = ownerModel.Address,
                PhoneNumber = ownerModel.PhoneNumber,
                Email = ownerModel.Email,
                Cars = ownerModel.Cars.Select(c => c.ToCarListDTOInOwner()).ToList()
            };
        
        }

        public static OwnerGetDTOAfterPost ToOwnerGetDTOAfterPost(this Owner ownerModel)
        {
            return new OwnerGetDTOAfterPost
            {
                OwnerId = ownerModel.OwnerId,
                FirstName = ownerModel.FirstName,
                LastName = ownerModel.LastName,
                Age = ownerModel.Age,
                Address = ownerModel.Address,
                PhoneNumber = ownerModel.PhoneNumber,
                Email = ownerModel.Email
            };
        }

        public static Owner ToOwnerModel(this OwnerPostDTO ownerPostDTO) 
        {
            return new Owner
            {
                FirstName = ownerPostDTO.FirstName,
                LastName = ownerPostDTO.LastName,
                Age = ownerPostDTO.Age,
                Address = ownerPostDTO.Address,
                PhoneNumber = ownerPostDTO.PhoneNumber,
                Email = ownerPostDTO.Email
            };
        }

        public static Owner ToOwnerModelFromPut(this Owner ownerModel) 
        {
            return new Owner
            {
                FirstName = ownerModel.FirstName,
                LastName = ownerModel.LastName,
                Age = ownerModel.Age,
                Address = ownerModel.Address,
                PhoneNumber = ownerModel.PhoneNumber,
                Email = ownerModel.Email
            };
        
        }
    }
}
