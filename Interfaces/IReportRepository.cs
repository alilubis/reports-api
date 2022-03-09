namespace APITest.Interfaces
{
    public interface IReportRepository
    {
        Task<List<dynamic>> getDailyOutputSiHy();
        Task<List<dynamic>> getDailyOutputSiHyByProductType();
        Task<List<dynamic>> getDailyOutputSiHyBySeries();
        
        Task<dynamic> getOperationSiHy();

        Task<List<dynamic>> getDailyQC();
        Task<List<dynamic>> getDailyQCBySeries();
        
        Task<dynamic> getDailyPOCloseSiHy();
        Task<dynamic> getDailyPOCloseSiHyBySeries();
        
        Task<List<dynamic>> getDailyOutputFL();
        Task<List<dynamic>> getDailyOutputFLBySeries();
        
        Task<dynamic> getOperationFL();

        Task<dynamic> getDailyQCFDI();
        Task<dynamic> getDailyQCFDIBySeries();
        
        Task<dynamic> getDailyPOCloseFL();
        Task<dynamic> getDailyPOCloseFLBySeries();
        
        Task<List<dynamic>> getMonthlyOutputSiHy();
        Task<List<dynamic>> getMonthlyOutputSiHyBySeries();
        
        Task<List<dynamic>> getMonthlyQC();
        Task<List<dynamic>> getMonthlyQCBySeries();
        
        Task<dynamic> getMonthlyPOCloseSiHy();
        Task<dynamic> getMonthlyPOCloseSiHyBySeries();
        
        Task<List<dynamic>> getMonthlyOutputFL();
        Task<List<dynamic>> getMonthlyOutputFLBySeries();
        
        Task<dynamic> getMonthlyQCFDI();
        Task<dynamic> getMonthlyQCFDIBySeries();
        
        Task<dynamic> getMonthlyPOCloseFL();
        Task<dynamic> getMonthlyPOCloseFLBySeries();
        
        
    }
}