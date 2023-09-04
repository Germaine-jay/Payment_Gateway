﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payment_Gateway.Models.Entities
{
    public class Payout
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string payoutId { get; set; }
        public long Amount { get; set; }
        public string? Reason { get; set; }
        public string? Recipient { get; set; }
        public string? Reference { get; set; }
        public string Currency { get; set; }
        public string? Source { get; set; }
        public bool? Responsestatus { get; set; }
        public string? Status { get; set; }
        public string? WalletId { get; set; }
        public string? CreatedAt { get; set; }

        [ForeignKey("TransactionHistory")]
        public string? TransactionHistoryId { get; set; }

        public TransactionHistory? TransactionHistory { get; set; }
    }
}
