﻿using Microsoft.AspNetCore.Identity;
using Payment_Gateway.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payment_Gateway.Models.Entities   
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
		public override string? PhoneNumber { get; set; }
		public string? RecoveryMail { get; set; }
        public DateTime? Birthday { get; set; }
        public UserType UserType { get; set; }
        public string Pin { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(Wallet))]
        public string? WalletId { get; set; }
        public Wallet? Wallet { get; set; }

        [ForeignKey("ApiKey")]
        public string? ApiSecretKey { get; set; }
        public ApiKey? ApiKey { get; set; }
    }
}