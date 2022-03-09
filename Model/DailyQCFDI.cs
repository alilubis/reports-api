namespace APITest.Model
{
    public class DailyQCFDI
    {
        public string Operation { get; set; }
        public string ProductType { get; set; }
        public string Date { get; set; }
        public int PON { get; set; }
        public int Fail { get; set; }
        public decimal PercentFail { get; set; }
    }
}