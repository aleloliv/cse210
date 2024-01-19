using System;
public class Entry
{
    public DateTime _date;
    public string _promptText;
    public string _entryText;

    public Entry()
    {
    }

    public Entry(DateTime date, string promptText, string entryText)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date.ToString()} - Prompt: {_promptText} \n{_entryText}");
    }
}