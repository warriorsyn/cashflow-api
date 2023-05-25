﻿using CashFlow.Services.Report;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("{date}")]
    public async Task<ActionResult<decimal>> GetDailyBalanceAsync(DateTime date) =>
        await _reportService.GetDailyBalanceAsync(date);
}
