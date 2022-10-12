namespace ChatSupport.Application;
public class DateFormatConverter : IsoDateTimeConverter
{
    public DateFormatConverter(string format)
    {
        DateTimeFormat = format;
    }
}
