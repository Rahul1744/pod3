using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LM.Models
{
    
    public class Collateral_RealEstate
    {
        [Key]
        public int Loan_Id { get; set; } = 0;

        public string CollateralType { get; set; } = string.Empty;

        public int Customer_Id { get; set; } = 0;

        public string Address { get; set; } = string.Empty;

        public int CurrentValue { get; set; } = 0; 

        public int RatePerSqFt { get; set; } = 0;

        public int DepreciationRate { get; set; } = 0;
    }
}
