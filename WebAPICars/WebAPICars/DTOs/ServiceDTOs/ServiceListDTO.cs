﻿using System.ComponentModel.DataAnnotations.Schema;
using WebAPICars.Models;

namespace WebAPICars.DTOs.ServiceDTOs
{
    public class ServiceListDTO
    {
        public int ServiceId { get; set; }
        public int? CarId { get; set; }
        public DateTime StartServiceDate { get; set; }
        public DateTime EndServiceDate { get; set; }
        public string ServiceType { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }
        public bool IsCarRepaired { get; set; }

    }
}