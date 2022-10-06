
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace LM.Models
{
    [Keyless]
    public class LC_Detail
    {
        public int LoanId { get; set; } = 0;
        public int CollateralValue { get; set; } = 0;
        public string Tenure { get; set; } = string.Empty;
        public decimal Interest { get; set; } = decimal.Zero;
        public int Collateral_Id { get; set; } = 0;
        public DateTime PledgedDate { get; set; }
    }
}
