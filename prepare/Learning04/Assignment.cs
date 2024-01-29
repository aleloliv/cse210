public abstract class Assignment 
{
    protected string _studentName { get; set; }
    private string _topic { get; set; }

    public Assignment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }

    public string GetSummary()
    {
        return "Name: "
                + _studentName
                + " Topic: "
                + _topic;
    }
        
}