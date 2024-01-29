using System;
using System.Globalization;
using System.Collections.Generic;

public class MathAssignment : Assignment
{
    private string _textbookSection { get; set; }
    private string _problems { get; set; }
    public MathAssignment(string name, string topic, string section, string problems) : base(name, topic)
    {
        _textbookSection = section;
        _problems = problems;
    }

    public string GetHomeworkList()
    {
        return "Section "
            + _textbookSection
            + " Problems "
            + _problems;
    }
}