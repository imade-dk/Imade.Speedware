namespace Imade.Speedware.Api.Models;

public partial class Room 
{
    public string NameAndSchool
    {
        get { return string.Format("{0} ({1})", Name, School); }
    }

    public string SchoolAndName
    {
        get { return string.Format("{0} ({1})", School, Name); }
    }
}
