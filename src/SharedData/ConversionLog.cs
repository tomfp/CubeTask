namespace SharedData
{
    public class ConversionLog
    {
        public DateTime RequestDate { get; set; }
        public ConversionRequest Request { get; set; } = new ConversionRequest();
    }
}
