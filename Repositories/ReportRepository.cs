using System.Dynamic;
using APITest.Interfaces;
using APITest.Model;
using Microsoft.EntityFrameworkCore;

namespace APITest.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ProductionDBContext _productionContext;
        private readonly QualityDBContext _qualityContext;

        public ReportRepository(ProductionDBContext productionContext, QualityDBContext qualityContext){
            _productionContext = productionContext;
            _qualityContext = qualityContext;
        }
        #region version 1
        public async Task<List<dynamic>> getDailyOutputSiHy()
        {
            var data = await _productionContext.DailyOutputSiHy.ToListAsync();
            var listOperation = new List<dynamic>();
            var Operations = data.Select(d=>d.Operation).Distinct();
            var ProductType = data.Select(d=>d.ProductType).Distinct();

            foreach (var op in Operations)
            {
                var obj = new Dictionary<string, object>();
                var listProductType = new List<dynamic>();

                foreach(var pt in ProductType)
                {
                    var objpt = new Dictionary<string, object>();
                    var listObjpt = new List<dynamic>();
                    DateTime startDate = DateTime.Now.AddDays(-30);
                    DateTime endDate = DateTime.Now.AddDays(-1);

                    while(startDate <= endDate)
                    {
                        var result = data.Where(d => d.Operation == op && d.ProductType == pt 
                            && d.Date == startDate.ToString("yyyy-MM-dd")).FirstOrDefault();
                        listObjpt.Add(new
                        {
                            PON = result != null ? result.PON : 0,
                            LENS = result != null ? result.Lens : 0,
                            Date = result != null ? result.Date : startDate.ToString("yyyy-MM-dd")
                        });
                        startDate = startDate.AddDays(1);
                    }
                    objpt[pt] = listObjpt; // productType : list data
                    listProductType.Add(objpt);
                }
                obj[op] = listProductType; // operation : list productType
                listOperation.Add(obj);
            }

            return listOperation;
        }

        public async Task<dynamic> getOperationSiHy()
        {
            var data = await _productionContext.OperationSiHy.ToListAsync();
            return data;
        }

        public async Task<List<dynamic>> getDailyQC()
        {
            var data = await _qualityContext.DailyQC.ToListAsync();
            var listOperation = new List<dynamic>(); 
            var Operations = data.Select(d=> d.Operation).Distinct();
            var ProductTypes = data.Select(d=> d.ProductType).Distinct();

            foreach (var op in Operations)
            {
                var obj = new Dictionary<string, object>();
                var listProductType = new List<dynamic>();

                foreach(var pt in ProductTypes)
                {
                    var objpt = new Dictionary<string, object>();
                    var listObjpt = new List<dynamic>();
                    DateTime startDate = DateTime.Now.AddDays(-30);
                    DateTime endDate = DateTime.Now.AddDays(-1);
                    
                    while(startDate <= endDate)
                    {
                        var result = data.Where(d => d.Operation == op && d.ProductType == pt 
                        && d.Date == startDate.ToString("yyyy-MM-dd")).FirstOrDefault();
                        listObjpt.Add(new
                        {
                            PON = result != null ? result.PON : 0,
                            Fail =  result != null ? result.Fail : 0,
                            PercentFail = result != null ? result.PercentFail : 0,
                            Date = result != null ? result.Date : startDate.ToString("yyyy-MM-dd")
                        });
                        startDate = startDate.AddDays(1);
                    }
                    objpt[pt] = listObjpt; // productType : list data
                    listProductType.Add(objpt); 
                }
                obj[op] = listProductType; // operation : list productType
                listOperation.Add(obj);
            }

            return listOperation;
        }

        public async Task<dynamic> getDailyPOCloseSiHy()
        {
            var data = await _productionContext.DailyPOCloseSiHy.ToListAsync();
            var ProductTypes = data.Select(d=>d.ProductType).Distinct();
            var listProductType = new List<dynamic>();

            foreach(var pt in ProductTypes)
            {
                var listObjpt = new List<dynamic>();
                var obj = new Dictionary<string, object>();
                DateTime startDate = DateTime.Now.AddDays(-30);
                DateTime endDate = DateTime.Now.AddDays(-1);

                while (startDate <= endDate)
                {
                    var result = data.Where(d => d.ProductType == pt 
                        && d.Date == startDate.ToString("yyyy-MM-dd")).FirstOrDefault();
                    listObjpt.Add(new
                    {
                        PON = result != null ? result.PON : 0,
                        LENS = result != null ? result.Lens : 0,
                        Date = result != null ? result.Date : startDate.ToString("yyyy-MM-dd")
                    });
                    startDate = startDate.AddDays(1);
                }
                obj[pt] = listObjpt; // productType : list data
                listProductType.Add(obj);
            }

            return listProductType;
        }

        public async Task<List<dynamic>> getDailyOutputFL()
        {
            var data = await _productionContext.DailyOutputFL.ToListAsync();
            var listOperation = new List<dynamic>();
            var Operations = data.Select(d=> d.Operation).Distinct();
            var ProductTypes = data.Select(d=> d.ProductType).Distinct();

            foreach (var op in Operations)
            {
                var obj = new Dictionary<string, object>();
                var listProductType = new List<dynamic>();

                foreach(var pt in ProductTypes)
                {
                    var objpt = new Dictionary<string, object>();
                    var listObjpt = new List<dynamic>();
                    DateTime startDate = DateTime.Now.AddDays(-30);
                    DateTime endDate = DateTime.Now.AddDays(-1);

                    while (startDate <= endDate)
                    {
                        var result = data.Where(d => d.Operation == op && d.ProductType == pt 
                            && d.Date == startDate.ToString("yyyy-MM-dd")).FirstOrDefault();
                        listObjpt.Add(new
                        {
                            PON = result != null ? result.PON : 0,
                            LENS = result != null ? result.Lens : 0,
                            Date = result != null ? result.Date : startDate.ToString("yyyy-MM-dd")
                        });
                        startDate = startDate.AddDays(1);
                    }
                    objpt[pt] = listObjpt; // productType : list data
                    listProductType.Add(objpt);
                }
                obj[op] = listProductType; // operation : list productType
                listOperation.Add(obj);
            }
            
            return listOperation;
        }

        public async Task<dynamic> getOperationFL()
        {
            var data = await _productionContext.OperationFL.ToListAsync();
            return data;
        }

        public async Task<dynamic> getDailyQCFDI()
        {
            var data = await _qualityContext.DailyQCFDI.ToListAsync();
            var ProductTypes = data.Select(d=>d.ProductType).Distinct();
            var obj = new Dictionary<string, object>();
            var listProductType = new List<dynamic>();

            foreach(var pt in ProductTypes)
            {
                var objpt = new Dictionary<string, object>();
                var listObjpt = new List<dynamic>();
                DateTime startDate = DateTime.Now.AddDays(-30);
                DateTime endDate = DateTime.Now.AddDays(-1);

                while (startDate <= endDate)
                {
                    var result = data.Where(d => d.ProductType == pt 
                        && d.Date == startDate.ToString("yyyy-MM-dd")).FirstOrDefault();
                    listObjpt.Add(new
                    {
                        PON = result != null ? result.PON : 0,
                        Fail =  result != null ? result.Fail : 0,
                        PercentFail = result != null ? result.PercentFail : 0,
                        Date = result != null ? result.Date : startDate.ToString("yyyy-MM-dd")
                    });
                    startDate = startDate.AddDays(1);
                }
                objpt[pt] = listObjpt; // productType : list data
                listProductType.Add(objpt);
            }
            obj["Finished Device Inspection (FDI)"] = listProductType; 
            return obj;
        }

        public async Task<dynamic> getDailyPOCloseFL()
        {
            var data = await _productionContext.DailyPOCloseFL.ToListAsync();
            var ProductTypes = data.Select(d=>d.ProductType).Distinct();
            var listProductType = new List<dynamic>();

            foreach(var pt in ProductTypes)
            {
                var listObjpt = new List<dynamic>();
                var obj = new Dictionary<string, object>();
                DateTime startDate = DateTime.Now.AddDays(-30);
                DateTime endDate = DateTime.Now.AddDays(-1);

                while (startDate <= endDate)
                {
                    var result = data.Where(d => d.ProductType == pt 
                        && d.Date == startDate.ToString("yyyy-MM-dd")).FirstOrDefault();
                    listObjpt.Add(new
                    {
                        PON = result != null ? result.PON : 0,
                        LENS = result != null ? result.Lens : 0,
                        Date = result != null ? result.Date : startDate.ToString("yyyy-MM-dd")
                    });
                    startDate = startDate.AddDays(1);
                }

                obj[pt] = listObjpt; // productType : list data
                listProductType.Add(obj);
            }
            return listProductType;
        }

        public async Task<List<dynamic>> getMonthlyOutputSiHy()
        {
            var data = await _productionContext.MonthlyOutputSiHy.ToListAsync();
            var listOperation = new List<dynamic>();
            var Operations = data.Select(d=> d.Operation).Distinct();
            var ProductTypes = data.Select(d=> d.ProductType).Distinct();

            foreach (var op in Operations)
            {
                var obj = new Dictionary<string, object>();
                var listProductType = new List<dynamic>();

                foreach(var pt in ProductTypes)
                {
                    var objpt = new Dictionary<string, object>();
                    var listObjpt = new List<dynamic>();
                    DateTime startMonth = DateTime.Now.AddMonths(-13);
                    DateTime endMonth = DateTime.Now.AddMonths(-1);

                    while(startMonth <= endMonth)
                    {
                        var result = data.Where(d=> d.Operation == op && d.ProductType == pt 
                            && d.Date == startMonth.ToString("yyyy-MM")).FirstOrDefault();
                        listObjpt.Add(new
                        {
                            PON = result != null ? result.PON : 0,
                            LENS = result != null ? result.Lens : 0,
                            Date = result != null ? result.Date : startMonth.ToString("yyyy-MM")
                        });
                        startMonth = startMonth.AddMonths(1);
                    }
                    objpt[pt] = listObjpt; // productType : list data
                    listProductType.Add(objpt);
                }
                obj[op] = listProductType; // operation : list productType
                listOperation.Add(obj);
            }

            return listOperation;
        }

        public async Task<List<dynamic>> getMonthlyQC()
        {
            var data = await _qualityContext.MonthlyQC.ToListAsync();
            var listOperation = new List<dynamic>(); 
            var Operations = data.Select(d=>d.Operation).Distinct();
            var ProductTypes = data.Select(d=>d.ProductType).Distinct();

            foreach (var op in Operations)
            {
                var obj = new Dictionary<string, object>();
                var listProductType = new List<dynamic>();

                foreach(var pt in ProductTypes)
                {
                    var objpt = new Dictionary<string, object>();
                    var listObjpt = new List<dynamic>();
                    DateTime startMonth = DateTime.Now.AddMonths(-13);
                    DateTime endMonth = DateTime.Now.AddMonths(-1);

                    while(startMonth <= endMonth)
                    {
                        var result = data.Where(d=> d.Operation == op && d.ProductType == pt 
                            && d.Date == startMonth.ToString("yyyy-MM")).FirstOrDefault();
                        listObjpt.Add(new MonthlyQC
                        {
                            PON = result != null ? result.PON : 0,
                            Fail = result != null ? result.Fail : 0,
                            PercentFail = result != null ? result.PercentFail : 0,
                            Date = result != null ? result.Date : startMonth.ToString("yyyy-MM")
                        });
                        startMonth = startMonth.AddMonths(1);
                    }
                    objpt[pt] = listObjpt; // productType : list data
                    listProductType.Add(objpt);
                }
                obj[op] = listProductType; // operation : list productType
                listOperation.Add(obj);
            }

            return listOperation;
        }

        public async Task<dynamic> getMonthlyPOCloseSiHy()
        {
            var data = await _productionContext.MonthlyPOCloseSiHy.ToListAsync();
            var ProductTypes = data.Select(d=>d.ProductType).Distinct();
            var listProductType = new List<dynamic>();

            foreach(var pt in ProductTypes)
            {
                var listObjpt = new List<dynamic>();
                var obj = new Dictionary<string, object>();
                DateTime startMonth = DateTime.Now.AddMonths(-13);
                DateTime endMonth = DateTime.Now.AddMonths(-1);

                while (startMonth <= endMonth)
                {
                    var result = data.Where(d => d.ProductType == pt 
                        && d.Date == startMonth.ToString("yyyy-MM")).FirstOrDefault();
                    listObjpt.Add(new
                    {
                        PON = result != null ? result.PON : 0,
                        LENS = result != null ? result.Lens : 0,
                        Date = result != null ? result.Date : startMonth.ToString("yyyy-MM")
                    });
                    startMonth = startMonth.AddMonths(1);
                }
                obj[pt] = listObjpt; // productType : list data
                listProductType.Add(obj);
            }

            return listProductType;
        }

        public async Task<List<dynamic>> getMonthlyOutputFL()
        {
            var data = await _productionContext.MonthlyOutputFL.ToListAsync();
            var listOperation = new List<dynamic>();
            var Operations = data.Select(d=>d.Operation).Distinct();
            var ProductTypes = data.Select(d=>d.ProductType).Distinct();

            foreach (var op in Operations)
            {
                var obj = new Dictionary<string, object>();
                var listProductType = new List<dynamic>();

                foreach(var pt in ProductTypes)
                {
                    var objpt = new Dictionary<string, object>();
                    var listObjpt = new List<dynamic>();
                    DateTime startMonth = DateTime.Now.AddMonths(-13);
                    DateTime endMonth = DateTime.Now.AddMonths(-1);

                    while(startMonth <= endMonth)
                    {
                        var result = data.Where(d=> d.Operation == op && d.ProductType == pt 
                            && d.Date == startMonth.ToString("yyyy-MM")).FirstOrDefault();
                        listObjpt.Add(new
                        {
                            PON = result != null ? result.PON : 0,
                            LENS = result != null ? result.Lens : 0,
                            Date = result != null ? result.Date : startMonth.ToString("yyyy-MM")
                        });
                        startMonth = startMonth.AddMonths(1);
                    }
                    objpt[pt] = listObjpt; // productType : list data
                    listProductType.Add(objpt);
                }
                obj[op] = listProductType; // operation : list productType
                listOperation.Add(obj);
            }

            return listOperation;
        }

        public async Task<dynamic> getMonthlyQCFDI()
        {
            var data = await _qualityContext.MonthlyQCFDI.ToListAsync();
            var ProductTypes = data.Select(d=>d.ProductType).Distinct();
            var obj = new Dictionary<string, object>();
            var listProductType = new List<dynamic>();

            foreach(var pt in ProductTypes)
            {
                var objpt = new Dictionary<string, object>();
                var listObjpt = new List<dynamic>();
                DateTime startMonth = DateTime.Now.AddMonths(-13);
                DateTime endMonth = DateTime.Now.AddMonths(-1);

                while (startMonth <= endMonth)
                {
                    var result = data.Where(d => d.ProductType == pt 
                        && d.Date == startMonth.ToString("yyyy-MM")).FirstOrDefault();
                    listObjpt.Add(new
                    {
                        PON = result != null ? result.PON : 0,
                        Fail =  result != null ? result.Fail : 0,
                        PercentFail = result != null ? result.PercentFail : 0,
                        Date = result != null ? result.Date : startMonth.ToString("yyyy-MM")
                    });
                    startMonth = startMonth.AddMonths(1);
                }
                objpt[pt] = listObjpt; // productType : list data
                listProductType.Add(objpt);
            }
            obj["Finished Device Inspection (FDI)"] = listProductType; 

            return obj;
        }

        public async Task<dynamic> getMonthlyPOCloseFL()
        {
            var data = await _productionContext.MonthlyPOCloseFL.ToListAsync();
            var ProductTypes = data.Select(d=> d.ProductType).Distinct();
            var listProductType = new List<dynamic>();

            foreach(var pt in ProductTypes)
            {
                var listObjpt = new List<dynamic>();
                var obj = new Dictionary<string, object>();
                DateTime startMonth = DateTime.Now.AddMonths(-13);
                DateTime endMonth = DateTime.Now.AddMonths(-1);

                while(startMonth <= endMonth)
                {
                    var result = data.Where(d=>d.ProductType == pt
                        && d.Date ==  startMonth.ToString("yyyy-MM")).FirstOrDefault();
                    listObjpt.Add(
                        new{
                            PON = result != null ? result.PON : 0,
                            LENS = result != null ? result.Lens : 0,
                            Date = result != null ? result.Date : startMonth.ToString("yyyy-MM")
                        }
                    );
                    startMonth = startMonth.AddMonths(1);
                }
                obj[pt] = listObjpt; // productType : list data
                listProductType.Add(obj);
            }

            return listProductType;
        }

        #endregion

        #region version 2
        // update 03 Feb 2022
        public async Task<List<dynamic>> getDailyOutputSiHyByProductType()        
        {
            var data = await _productionContext.DailyOutputSiHy.ToListAsync();
            var listOperation = new List<dynamic>();
            var Operations = data.Select(d=>d.Operation).Distinct();
            var ProductType = data.Select(d=>d.ProductType).Distinct();
            var Type = new List<string>()
            {
                "PON", "Lens"
            };

            foreach (var op in Operations)
            {
                var obj = new Dictionary<string, object>();
                var listPonLens = new List<dynamic>();

                foreach(var type in Type)
                {
                    DateTime startDate = DateTime.Now.AddDays(-30);
                    DateTime endDate = DateTime.Now.AddDays(-1);
                    
                    var listProd = new List<dynamic>();
                    var objType = new Dictionary<string, object>();
                    while(startDate <= endDate)
                    {
                        dynamic prod = new ExpandoObject();
                        prod.Date = startDate.ToString("yyyy-MM-dd");
                        foreach(var pt in ProductType)
                        {
                            var result = data.Where(d => d.Operation == op 
                                && d.Date == startDate.ToString("yyyy-MM-dd")
                                && d.ProductType == pt
                            ).FirstOrDefault();
                            ((IDictionary<String, Object>)prod)[pt]  = type == "PON" ? result?.PON ?? 0 : result?.Lens ?? 0;
                        }
                        listProd.Add(prod);
                        startDate = startDate.AddDays(1);
                    }
                    objType[type] = listProd; 
                    listPonLens.Add(objType);
                }

                obj[op] = listPonLens;
                listOperation.Add(obj);
            }

            return listOperation;
        }
        #endregion

        #region version 3
        // update 03 Feb 2022, by Dynamic Series
        public async Task<List<dynamic>> getDailyOutputSiHyBySeries()
        {
            var data = await _productionContext.DailyOutputSiHy.ToListAsync();
            var listOperation = new List<dynamic>();
            var Operations = data.Select(d=>d.Operation).Distinct();
            var ProductTypes = data.Select(d=>d.ProductType).Distinct();
            var Type = new List<string>()
            {
                "PON", "Lens"
            };

            foreach (var op in Operations)
            {
                var obj = new Dictionary<string, object>();
                var listPonLens = new List<dynamic>();

                foreach(var type in Type)
                {
                    DateTime startDate = DateTime.Now.AddDays(-30);
                    DateTime endDate = DateTime.Now.AddDays(-1);
                    
                    var listProd = new List<dynamic>();
                    var objType = new Dictionary<string, object>();
                    while(startDate <= endDate)
                    {
                        foreach(var pt in ProductTypes)
                        {
                            var result = data.Where(d => d.Operation == op 
                                && d.Date == startDate.ToString("yyyy-MM-dd")
                                && d.ProductType == pt
                            ).FirstOrDefault();

                            dynamic prod = new ExpandoObject();
                            prod.Date = startDate.ToString("yyyy-MM-dd");
                            prod.Series = pt;
                            prod.Data = type == "PON" ? result?.PON ?? 0 : result?.Lens ?? 0;
                            listProd.Add(prod);
                        }
                        
                        startDate = startDate.AddDays(1);
                    }
                    objType[type] = listProd; 
                    listPonLens.Add(objType);
                }

                obj[op] = listPonLens;
                listOperation.Add(obj);
            }

            return listOperation;
        }

        public async Task<List<dynamic>> getDailyQCBySeries()
        {
            var data = await _qualityContext.DailyQC.ToListAsync();
            var listOperation = new List<dynamic>(); 
            var Operations = data.Select(d=> d.Operation).Distinct();
            var ProductTypes = data.Select(d=> d.ProductType).Distinct();

            foreach (var op in Operations)
            {
                DateTime startDate = DateTime.Now.AddDays(-30);
                DateTime endDate = DateTime.Now.AddDays(-1);
                
                var listProd = new List<dynamic>();
                var obj = new Dictionary<string, object>();
                while(startDate <= endDate)
                {
                    foreach(var pt in ProductTypes)
                    {
                        var result = data.Where(d => d.Operation == op 
                            && d.Date == startDate.ToString("yyyy-MM-dd")
                            && d.ProductType == pt
                        ).FirstOrDefault();

                        dynamic prod = new ExpandoObject();
                        prod.Date = startDate.ToString("yyyy-MM-dd");
                        prod.Series = pt;
                        prod.Data =  result?.PercentFail ?? (decimal)0.00;
                        listProd.Add(prod);
                    }
                    
                    startDate = startDate.AddDays(1);
                }
                obj[op] = listProd; 
                listOperation.Add(obj);
            }

            return listOperation;
        }

        public async Task<dynamic> getDailyPOCloseSiHyBySeries()
        {
            var data = await _productionContext.DailyPOCloseSiHy.ToListAsync();
            var ProductTypes = data.Select(d=>d.ProductType).Distinct();
            var Type = new List<string>()
            {
                "PON", "Lens"
            };

            var listPonLens = new List<dynamic>();
            foreach(var type in Type)
            {
                DateTime startDate = DateTime.Now.AddDays(-30);
                DateTime endDate = DateTime.Now.AddDays(-1);
                
                var listProd = new List<dynamic>();
                var objType = new Dictionary<string, object>();
                while(startDate <= endDate)
                {
                    foreach(var pt in ProductTypes)
                    {
                        var result = data.Where(d => d.Date == startDate.ToString("yyyy-MM-dd")
                            && d.ProductType == pt
                        ).FirstOrDefault();

                        dynamic prod = new ExpandoObject();
                        prod.Date = startDate.ToString("yyyy-MM-dd");
                        prod.Series = pt;
                        prod.Data = type == "PON" ? result?.PON ?? 0 : result?.Lens ?? 0;
                        listProd.Add(prod);
                    }
                    
                    startDate = startDate.AddDays(1);
                }
                objType[type] = listProd; 
                listPonLens.Add(objType);
            }

            return listPonLens;
        }
        
        public async Task<List<dynamic>> getDailyOutputFLBySeries()
        {
            var data = await _productionContext.DailyOutputFL.ToListAsync();
            var listOperation = new List<dynamic>();
            var Operations = data.Select(d=> d.Operation).Distinct();
            var ProductTypes = data.Select(d=> d.ProductType).Distinct();
            var Type = new List<string>()
            {
                "PON", "Lens"
            };

            foreach (var op in Operations)
            {
                var obj = new Dictionary<string, object>();
                var listPonLens = new List<dynamic>();

                foreach(var type in Type)
                {
                    DateTime startDate = DateTime.Now.AddDays(-30);
                    DateTime endDate = DateTime.Now.AddDays(-1);
                    
                    var listProd = new List<dynamic>();
                    var objType = new Dictionary<string, object>();
                    while(startDate <= endDate)
                    {
                        foreach(var pt in ProductTypes)
                        {
                            var result = data.Where(d => d.Operation == op 
                                && d.Date == startDate.ToString("yyyy-MM-dd")
                                && d.ProductType == pt
                            ).FirstOrDefault();

                            dynamic prod = new ExpandoObject();
                            prod.Date = startDate.ToString("yyyy-MM-dd");
                            prod.Series = pt;
                            prod.Data = type == "PON" ? result?.PON ?? 0 : result?.Lens ?? 0;
                            listProd.Add(prod);
                        }
                        
                        startDate = startDate.AddDays(1);
                    }
                    objType[type] = listProd; 
                    listPonLens.Add(objType);
                }

                obj[op] = listPonLens;
                listOperation.Add(obj);
            }
            
            return listOperation;
        }
        
        public async Task<dynamic> getDailyQCFDIBySeries()
        {
            var data = await _qualityContext.DailyQCFDI.ToListAsync();
            var ProductTypes = data.Select(d=>d.ProductType).Distinct();
            var obj = new Dictionary<string, object>();
            var listProd = new List<dynamic>();

            DateTime startDate = DateTime.Now.AddDays(-30);
            DateTime endDate = DateTime.Now.AddDays(-1);
            while(startDate <= endDate)
            {
                foreach(var pt in ProductTypes)
                {
                    var result = data.Where(d => d.Date == startDate.ToString("yyyy-MM-dd")
                        && d.ProductType == pt
                    ).FirstOrDefault();

                    dynamic prod = new ExpandoObject();
                    prod.Date = startDate.ToString("yyyy-MM-dd");
                    prod.Series = pt;
                    prod.Data =  result?.PercentFail ?? (decimal)0.00;
                    listProd.Add(prod);
                }
                
                startDate = startDate.AddDays(1);
            }

             obj["Finished Device Inspection (FDI)"] = listProd; 
            return obj;
        }
        
        public async Task<dynamic> getDailyPOCloseFLBySeries()
        {
            var data = await _productionContext.DailyPOCloseFL.ToListAsync();
            var ProductTypes = data.Select(d=>d.ProductType).Distinct();
            var Type = new List<string>()
            {
                "PON", "Lens"
            };

            var listPonLens = new List<dynamic>();
            foreach(var type in Type)
            {
                DateTime startDate = DateTime.Now.AddDays(-30);
                DateTime endDate = DateTime.Now.AddDays(-1);
                
                var listProd = new List<dynamic>();
                var objType = new Dictionary<string, object>();
                while(startDate <= endDate)
                {
                    foreach(var pt in ProductTypes)
                    {
                        var result = data.Where(d => d.Date == startDate.ToString("yyyy-MM-dd")
                            && d.ProductType == pt
                        ).FirstOrDefault();

                        dynamic prod = new ExpandoObject();
                        prod.Date = startDate.ToString("yyyy-MM-dd");
                        prod.Series = pt;
                        prod.Data = type == "PON" ? result?.PON ?? 0 : result?.Lens ?? 0;
                        listProd.Add(prod);
                    }
                    
                    startDate = startDate.AddDays(1);
                }
                objType[type] = listProd; 
                listPonLens.Add(objType);
            }

            return listPonLens;
        }
        
        public async Task<List<dynamic>> getMonthlyOutputSiHyBySeries()
        {
            var data = await _productionContext.MonthlyOutputSiHy.ToListAsync();
            var listOperation = new List<dynamic>();
            var Operations = data.Select(d=> d.Operation).Distinct();
            var ProductTypes = data.Select(d=> d.ProductType).Distinct();
            var Type = new List<string>()
            {
                "PON", "Lens"
            };
            
            foreach (var op in Operations)
            {
                var obj = new Dictionary<string, object>();
                var listPonLens = new List<dynamic>();

                foreach(var type in Type)
                {
                    DateTime startMonth = DateTime.Now.AddMonths(-13);
                    DateTime endMonth = DateTime.Now.AddMonths(-1);
                    
                    var listProd = new List<dynamic>();
                    var objType = new Dictionary<string, object>();
                    while(startMonth <= endMonth)
                    {
                        foreach(var pt in ProductTypes)
                        {
                            var result = data.Where(d => d.Operation == op 
                                && d.Date == startMonth.ToString("yyyy-MM")
                                && d.ProductType == pt
                            ).FirstOrDefault();

                            dynamic prod = new ExpandoObject();
                            prod.Date = startMonth.ToString("yyyy-MM");
                            prod.Series = pt;
                            prod.Data = type == "PON" ? result?.PON ?? 0 : result?.Lens ?? 0;
                            listProd.Add(prod);
                        }
                        
                        startMonth = startMonth.AddMonths(1);
                    }
                    objType[type] = listProd; 
                    listPonLens.Add(objType);
                }

                obj[op] = listPonLens;
                listOperation.Add(obj);
            }

            return listOperation;
        }
        
        public async Task<List<dynamic>> getMonthlyQCBySeries()
        {
            var data = await _qualityContext.MonthlyQC.ToListAsync();
            var listOperation = new List<dynamic>(); 
            var Operations = data.Select(d=>d.Operation).Distinct();
            var ProductTypes = data.Select(d=>d.ProductType).Distinct();

            foreach (var op in Operations)
            {
                DateTime startMonth = DateTime.Now.AddMonths(-13);
                DateTime endMonth = DateTime.Now.AddMonths(-1);
                
                var listProd = new List<dynamic>();
                var obj = new Dictionary<string, object>();
                while(startMonth <= endMonth)
                {
                    foreach(var pt in ProductTypes)
                    {
                        var result = data.Where(d => d.Operation == op 
                            && d.Date == startMonth.ToString("yyyy-MM")
                            && d.ProductType == pt
                        ).FirstOrDefault();

                        dynamic prod = new ExpandoObject();
                        prod.Date = startMonth.ToString("yyyy-MM");
                        prod.Series = pt;
                        prod.Data =  result?.PercentFail ?? (decimal)0.00;
                        listProd.Add(prod);
                    }
                    
                    startMonth = startMonth.AddMonths(1);
                }
                obj[op] = listProd; 
                listOperation.Add(obj);
            }

            return listOperation;
        }
        
        public async Task<dynamic> getMonthlyPOCloseSiHyBySeries()
        {
            var data = await _productionContext.MonthlyPOCloseSiHy.ToListAsync();
            var ProductTypes = data.Select(d=>d.ProductType).Distinct();
            var Type = new List<string>()
            {
                "PON", "Lens"
            };

            var listPonLens = new List<dynamic>();
            foreach(var type in Type)
            {
                DateTime startMonth = DateTime.Now.AddMonths(-13);
                DateTime endDate = DateTime.Now.AddMonths(-1);
                
                var listProd = new List<dynamic>();
                var objType = new Dictionary<string, object>();
                while(startMonth <= endDate)
                {
                    foreach(var pt in ProductTypes)
                    {
                        var result = data.Where(d => d.Date == startMonth.ToString("yyyy-MM")
                            && d.ProductType == pt
                        ).FirstOrDefault();

                        dynamic prod = new ExpandoObject();
                        prod.Date = startMonth.ToString("yyyy-MM");
                        prod.Series = pt;
                        prod.Data = type == "PON" ? result?.PON ?? 0 : result?.Lens ?? 0;
                        listProd.Add(prod);
                    }
                    
                    startMonth = startMonth.AddMonths(1);
                }
                objType[type] = listProd; 
                listPonLens.Add(objType);
            }

            return listPonLens;
        }

        public async Task<List<dynamic>> getMonthlyOutputFLBySeries()
        {
            var data = await _productionContext.MonthlyOutputFL.ToListAsync();
            var listOperation = new List<dynamic>();
            var Operations = data.Select(d=>d.Operation).Distinct();
            var ProductTypes = data.Select(d=>d.ProductType).Distinct();
            var Type = new List<string>()
            {
                "PON", "Lens"
            };

            foreach (var op in Operations)
            {
                var obj = new Dictionary<string, object>();
                var listPonLens = new List<dynamic>();

                foreach(var type in Type)
                {
                    DateTime startMonth = DateTime.Now.AddMonths(-13);
                    DateTime endMonth = DateTime.Now.AddMonths(-1);
                    
                    var listProd = new List<dynamic>();
                    var objType = new Dictionary<string, object>();
                    while(startMonth <= endMonth)
                    {
                        foreach(var pt in ProductTypes)
                        {
                            var result = data.Where(d => d.Operation == op 
                                && d.Date == startMonth.ToString("yyyy-MM")
                                && d.ProductType == pt
                            ).FirstOrDefault();

                            dynamic prod = new ExpandoObject();
                            prod.Date = startMonth.ToString("yyyy-MM");
                            prod.Series = pt;
                            prod.Data = type == "PON" ? result?.PON ?? 0 : result?.Lens ?? 0;
                            listProd.Add(prod);
                        }
                        
                        startMonth = startMonth.AddMonths(1);
                    }
                    objType[type] = listProd; 
                    listPonLens.Add(objType);
                }

                obj[op] = listPonLens;
                listOperation.Add(obj);
            }
            
            return listOperation;
        }
        
        public async Task<dynamic> getMonthlyQCFDIBySeries()
        {
            var data = await _qualityContext.MonthlyQCFDI.ToListAsync();
            var ProductTypes = data.Select(d=>d.ProductType).Distinct();
            var obj = new Dictionary<string, object>();
            var listProd = new List<dynamic>();

            DateTime startMonth = DateTime.Now.AddMonths(-13);
            DateTime endMonth = DateTime.Now.AddMonths(-1);
            while(startMonth <= endMonth)
            {
                foreach(var pt in ProductTypes)
                {
                    var result = data.Where(d => d.Date == startMonth.ToString("yyyy-MM")
                        && d.ProductType == pt
                    ).FirstOrDefault();

                    dynamic prod = new ExpandoObject();
                    prod.Date = startMonth.ToString("yyyy-MM");
                    prod.Series = pt;
                    prod.Data =  result?.PercentFail ?? (decimal)0.00;
                    listProd.Add(prod);
                }
                
                startMonth = startMonth.AddMonths(1);
            }

             obj["Finished Device Inspection (FDI)"] = listProd; 
            return obj;
        }

        public async Task<dynamic> getMonthlyPOCloseFLBySeries()
        {
            var data = await _productionContext.MonthlyPOCloseFL.ToListAsync();
            var ProductTypes = data.Select(d=> d.ProductType).Distinct();
             var Type = new List<string>()
            {
                "PON", "Lens"
            };

            var listPonLens = new List<dynamic>();
            foreach(var type in Type)
            {
                DateTime startMonth = DateTime.Now.AddMonths(-13);
                DateTime endMonth = DateTime.Now.AddMonths(-1);
                
                var listProd = new List<dynamic>();
                var objType = new Dictionary<string, object>();
                while(startMonth <= endMonth)
                {
                    foreach(var pt in ProductTypes)
                    {
                        var result = data.Where(d => d.Date == startMonth.ToString("yyyy-MM")
                            && d.ProductType == pt
                        ).FirstOrDefault();

                        dynamic prod = new ExpandoObject();
                        prod.Date = startMonth.ToString("yyyy-MM");
                        prod.Series = pt;
                        prod.Data = type == "PON" ? result?.PON ?? 0 : result?.Lens ?? 0;
                        listProd.Add(prod);
                    }
                    
                    startMonth = startMonth.AddMonths(1);
                }
                objType[type] = listProd; 
                listPonLens.Add(objType);
            }

            return listPonLens;
        }
        #endregion
    }
}