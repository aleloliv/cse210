using System;

class Program
{
    static void Main(string[] args)
    {
        string name = "Joseph";
        string topicMath = "Fractions";
        string section = "7.3";
        string problems = "3-10, 20-21";

        MathAssignment mathAssignment = new MathAssignment(name, topicMath, section, problems);

        string summaryMath = mathAssignment.GetSummary();
        Console.WriteLine(summaryMath);
        string homeworkList = mathAssignment.GetHomeworkList();
        Console.WriteLine(homeworkList);

        string topicWriting = "European History";
        string title = "The Causes of World War II";
        
        WritingAssignment writingAssignment = new WritingAssignment(name, topicWriting, title);

        string summaryWriting = writingAssignment.GetSummary();
        Console.WriteLine(summaryWriting);
        string writingInformation = writingAssignment.GetWritingInformation();
        Console.WriteLine(writingInformation);
    }
}