using LM.Model;
using LM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanManagementController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(LoanManagementController));
        private readonly DataContext _context;

        public LoanManagementController(DataContext context)
        {
            _context = context;
        }

        

        [HttpGet("GetLoanDetails")]
        public JsonResult GetLoanDetails([FromQuery]LC_ids request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _log4net.Info("Collateral Get Loan Details Method Called");
                    /*var L_id = new SqlParameter("@lid", request.L_id);
                    var C_id = new SqlParameter("@cid", request.C_id);*/
                    //return Ok(request.L_id.ToString() + request.C_id.ToString());
                    //string Retrieve_Loan_Details = "SELECT l.LoanId, cltl.CollateralValue, l.Tenure, l.Interest, cl.Collateral_Id, cltl.PledgedDate FROM CustomerLoan cl, CollateralLoan cltl, Loan l WHERE l.LoanId = cltl.Loan_Id AND cl.Loan_Id = cltl.Loan_Id AND l.LoanId = " + request.L_id + " AND cl.Customer_Id =" + request.C_id + ";";
                    //string Retrieve_Loan_Details = "SELECT c.customerId, c.CustomerFirstName, c.CustomerLastName, c.CustomerEmail, c.CustomerAddress, c.CustomerCity, c.CustomerState FROM Customer c";
                    var data = _context.LC_Details.Find(a => a.LoanId == request.L_id && a.CustomerId == request.C_id).ToList();
                    return new JsonResult(data);
                }
                else
                {
                    _log4net.Info("Model is not valid to Get Collateral_Details");
                    return new JsonResult("Unable to update table");
                }
            }
            catch (Exception e)
            {
                _log4net.Error("Exception in Get Collateral_Details" + e.Message);
                return new JsonResult(e.Message);
            }
        }

        /*[HttpPost("PostRealEstate")]
        public ActionResult PostRealEstate([FromQuery]Collateral_RealEstate request)
        {
            *//*var L_id = new SqlParameter("@lid", request.L_id);
             var C_id = new SqlParameter("@cid", request.C_id);*//*
            //return Ok(request.L_id.ToString() + request.C_id.ToString());
            *//* string Post_RealEstate = //"INSERT INTO Collateral_RealEstate VALUES ("+request.Loan_Id +"," +request.CollateralType +"," +request.Customer_Id +","+request.Address + ","+request.CurrentValue +","+request.RatePerSqFt +","+request.DepreciationRate+");";
                     @"INSERT INTO Collateral_RealEstate VALUES
                     ('" + request.Loan_Id + @"', 
                      '" + request.CollateralType + @"',
                      '" + request.Customer_Id + @"',
                      '" + request.Address + @"',
                      '" + request.CurrentValue + @"',
                      '" + request.RatePerSqFt + @"',
                      '" + request.DepreciationRate + @"')  
                     ";
             //string Retrieve_Loan_Details = "SELECT c.customerId, c.CustomerFirstName, c.CustomerLastName, c.CustomerEmail, c.CustomerAddress, c.CustomerCity, c.CustomerState FROM Customer c";
             var data = _context.Cltrl_REs.FromSqlRaw(Post_RealEstate);*//*
            await _context.Cltrl_REs.AnyAsync();
            return Ok("Data Saved");
        }*/

        [HttpPost("postRealEstate")]
        public async Task<IActionResult> PostRealEstate([FromBody]Collateral_RealEstate request)
        {
            var data = new Collateral_RealEstate()
            {
                Loan_Id = request.Loan_Id,
                CollateralType = request.CollateralType,
                Customer_Id = request.Customer_Id,
                Address = request.Address,
                CurrentValue = request.CurrentValue,
                RatePerSqFt = request.RatePerSqFt,
                DepreciationRate = request.DepreciationRate
            };

            await _context.Collateral_RealEstate.AddAsync(data);
            await _context.SaveChangesAsync();

            return Ok(data);
        }

        [HttpPost("postCashDeposite")]
        public async Task<IActionResult> postCashDeposite([FromBody] Collateral_CashDeposit request)
        {
            var data = new Collateral_CashDeposit()
            {
                Loan_Id = request.Loan_Id,
                CollateralType = request.CollateralType,
                Customer_Id = request.Customer_Id,
                BankName = request.BankName,
                CurrentValue = request.CurrentValue,
                InterestRate = request.InterestRate,
                DepositAmount = request.DepositAmount,
                LockPeriod = request.LockPeriod,
            };

            await _context.Collateral_CashDeposits.AddAsync(data);
            await _context.SaveChangesAsync();

            return Ok(data);
        }

    }
}
