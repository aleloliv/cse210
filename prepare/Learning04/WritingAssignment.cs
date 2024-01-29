public class WritingAssignment : Assignment
{
    private string _title { get; set; }
    public WritingAssignment(string name, string topic, string title) : base(name, topic)
    {
        _title = title;
    }


    public string GetWritingInformation()
    {
        return "Title: "
            + _title
            + " by "
            + _studentName;
    }
}