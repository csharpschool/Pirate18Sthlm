namespace Lektion18Sthlm.Classes;

public class Magazine : IComparable<Magazine>
{
    public int Id { get; set; }
    public string Title { get; set; }

    public int CompareTo(Magazine? other)
    {
        if (other == null) return 1;
        if (ReferenceEquals(this, other)) return 0;
        //if (Title.StartsWith(other.Title)) return 0;
        if(Id > other.Id) return 1;
        if(Id < other.Id) return -1;
        return 0;
    }
}
