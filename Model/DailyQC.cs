namespace APITest.Model
{
    public class DailyQC
    {
        public string Operation { get; set; }
        public string ProductType { get; set; }
        public string Date { get; set; }
        public int PON { get; set; }
        public int Fail { get; set; }
        public decimal PercentFail { get; set; }
        public int Carrier { get; set; }
        public int Update { get; set; }
        public decimal PercentUpdate { get; set; }
    }
}