using Library.Domain.Interfaces;
using Library.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers;

[ApiController]
[Route("loan")]
public class LoanController : ControllerBase
{
    private readonly ILogger<LoanController> _logger;
    private readonly ILoanService _loanService;

    public LoanController(ILogger<LoanController> logger, ILoanService loanService)
    {
        _logger = logger;
        _loanService = loanService;
    }

    [HttpGet]
    public async Task<List<Loan>> GetLoansAsync()
    {
        return await _loanService.GetLoansAsync();
    } 

    [HttpGet("book:{bookId}")]
    public async Task<List<Loan>> GetLoansByBookAsync(Guid bookId)
    {
        return await _loanService.GetLoansByBookAsync(bookId);
    }

    [HttpGet("user:{userId}")]
    public async Task<List<Loan>> GetLoansByUserAsync(Guid userId)
    {
        return await _loanService.GetLoansByUserAsync(userId);
    }

    [HttpGet("fines:{userId}")]
    public async Task<string> GetUserTotalFineAsync(Guid userId)
    {
        return await _loanService.GetUserTotalFineAsync(userId);
    }

    [HttpPost]
    public async Task<Loan> NewLoanAsync([FromBody] LoanDTO loanDTO)
    {
        return await _loanService.NewLoanAsync(loanDTO);
    }

    [HttpPut("{bookId}")]
    public async Task<Loan> ReturnBookAsync(Guid bookId)
    {
        return await _loanService.ReturnBookAsync(bookId);
    }
}