using System;
using System.Collections.Generic;
using System.IO;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();

    public PromptGenerator()
    {
    }
    
    public string GetRandomPrompt(string filename)
    {
        var randomPrompt = new Random();
        int index = randomPrompt.Next(1, 11);
        try
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                _prompts.Add(line);
            }
            // using (StreamReader sr = File.OpenText(filename))
            // {
            //     while (!sr.EndOfStream){
            //         string prompt = sr.ReadLine();
            //         _prompts.Add(prompt);
            //     }
            // }
        }
        catch (IOException e){
            Console.WriteLine("An error occurred");
            Console.WriteLine(e.Message);
        }
        return _prompts[index];
    }
}