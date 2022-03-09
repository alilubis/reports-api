using APITest.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APITest.Controllers;

[ApiController]
[Route("report")]
public class ReportController : ControllerBase
{
    private readonly IReportRepository _reportRepo;

    public ReportController(IReportRepository reportRepo)
    {
        _reportRepo = reportRepo;
    }

    [HttpGet]
    public async Task<IActionResult> SummaryReport()
    {
        var reportJson = new Dictionary<string, dynamic>();

        var dailyOutputSiHy = await _reportRepo.getDailyOutputSiHy();
        var operationSiHy = await _reportRepo.getOperationSiHy();
        var dailyQC = await _reportRepo.getDailyQC();
        var dailyPOCloseSiHy = await _reportRepo.getDailyPOCloseSiHy();
        var dailyOutputFL = await _reportRepo.getDailyOutputFL();
        var operationFL = await _reportRepo.getOperationFL();
        var dailyQCFDI = await _reportRepo.getDailyQCFDI();
        var dailyPOCloseFL = await _reportRepo.getDailyPOCloseFL();
        var monthlyOutputSiHy = await _reportRepo.getMonthlyOutputSiHy();
        var monthlyQC = await _reportRepo.getMonthlyQC();
        var monthlyPOCloseSiHy = await _reportRepo.getMonthlyPOCloseSiHy();
        var monthlyOutputFL = await _reportRepo.getMonthlyOutputFL();
        var monthlyQCFDI = await _reportRepo.getMonthlyQCFDI();
        var monthlyPOCloseFL = await _reportRepo.getMonthlyPOCloseFL();
        
        reportJson.Add("DailyOutputSiHy", dailyOutputSiHy);
        reportJson.Add("OperationSiHy", operationSiHy);
        reportJson.Add("DailyQC", dailyQC);
        reportJson.Add("DailyPOCloseSiHy", dailyPOCloseSiHy);
        reportJson.Add("DailyOutputFL", dailyOutputFL);
        reportJson.Add("OperationFL", operationFL);
        reportJson.Add("DailyQCFDI", dailyQCFDI);
        reportJson.Add("DailyPOCloseFL", dailyPOCloseFL);
        reportJson.Add("MonthlyOutputSiHy", monthlyOutputSiHy);
        reportJson.Add("MonthlyQC", monthlyQC);
        reportJson.Add("MonthlyPOCloseSiHy", monthlyPOCloseSiHy);
        reportJson.Add("MonthlyOutputFL", monthlyOutputFL);
        reportJson.Add("MonthlyQCFDI", monthlyQCFDI);
        reportJson.Add("MonthlyPOCloseFL", monthlyPOCloseFL);
        
        return Ok(reportJson);
    }

    [HttpGet("Series")]
    public async Task<IActionResult> DailyOutputSiHy()
    {
        var json = new Dictionary<string, dynamic>();
        var dailyOutputSiHy = await _reportRepo.getDailyOutputSiHyBySeries();
        var operationSiHy = await _reportRepo.getOperationSiHy();
        var dailyQC = await _reportRepo.getDailyQCBySeries();
        var dailyPOCloseSiHy = await _reportRepo.getDailyPOCloseSiHyBySeries();
        var dailyOutputFL = await _reportRepo.getDailyOutputFLBySeries();
        var operationFL = await _reportRepo.getOperationFL();
        var dailyQCFDI = await _reportRepo.getDailyQCFDIBySeries();
        var dailyPOCloseFL = await _reportRepo.getDailyPOCloseFLBySeries();
        var monthlyOutputSiHy = await _reportRepo.getMonthlyOutputSiHyBySeries();
        var monthlyQC = await _reportRepo.getMonthlyQCBySeries();
        var monthlyPOCloseSiHy = await _reportRepo.getMonthlyPOCloseSiHyBySeries();
        var monthlyOutputFL = await _reportRepo.getMonthlyOutputFLBySeries();
        var monthlyQCFDI = await _reportRepo.getMonthlyQCFDIBySeries();
        var monthlyPOCloseFL = await _reportRepo.getMonthlyPOCloseFLBySeries();

        json.Add("DailyOutputSiHy", dailyOutputSiHy);
        json.Add("OperationSiHy", operationSiHy);
        json.Add("DailyQC", dailyQC);
        json.Add("DailyPOCloseSiHy", dailyPOCloseSiHy);
        json.Add("DailyOutputFL", dailyOutputFL); 
        json.Add("OperationFL", operationFL);
        json.Add("DailyQCFDI", dailyQCFDI);
        json.Add("DailyPOCloseFL", dailyPOCloseFL);
        json.Add("MonthlyOutputSiHy", monthlyOutputSiHy);
        json.Add("MonthlyQC", monthlyQC);
        json.Add("MonthlyPOCloseSiHy", monthlyPOCloseSiHy);
        json.Add("MonthlyOutputFL", monthlyOutputFL);
        json.Add("MonthlyQCFDI", monthlyQCFDI);
        json.Add("MonthlyPOCloseFL", monthlyPOCloseFL);
        return Ok(json);
    }
}
