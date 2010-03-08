namespace FluentNhibernateSampleApp.Domain
{
    public class ScotchWhiskey : Whiskey
    {
        public ScotchWhiskey()
        {
            Country = "Scotland";
        }

        public virtual Region Region { get; set; }
    }

    public enum Region
    {
        Lowland,
        Speyside,
        Highland,
        Campbeltown,
        Islay
    }
}