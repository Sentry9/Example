using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Loans.Application.Base;
using Loans.Application.Limits;
using Loans.Application.Validator;
using Microsoft.Extensions.Options;

namespace Loans.Application.Controllers
{
    [Route("loans")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly List<LoanApplication> _loanApplications = new List<LoanApplication>();
        private readonly ILoanValidator _loanValidator;

        public LoansController(ILoanValidator loanValidator)
        {
            _loanValidator = loanValidator;
        }

        [HttpPost]
        public ActionResult AddLoan([FromBody] LoanApplicationModel model)
        {
            try
            {
                _loanValidator.Validate(model);
                return Ok("Заявка на кредит успешно добавлена.");
            }
            catch (LoanValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/status")]
        public ActionResult GetLoanStatus(Guid id)
        {
            return Ok("Статус кредита: Одобрено");
        }


    }
}
