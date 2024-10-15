﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebAPICars.Models;
using WebAPICars.Validations.Car;

namespace WebAPICars.DTOs.CarDTOs
{
    public class CarPutDTO
    {
        [Required(ErrorMessage = "This field is required")]
        [StringLength(30, ErrorMessage = "This field can't be more than 50 characters")]
        public string Model { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [Column(TypeName = "decimal(18,2)")]
        [ValidationForPrice]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [ValidationForYear]
        public int Year { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(20, ErrorMessage = "This field can't be more than 50 characters")]
        public string Color { get; set; } = string.Empty;

        [Required(ErrorMessage = "This field is required")]
        [ValidationForLicensePlate]
        public string LicensePlate { get; set; } = string.Empty;

    }
}
