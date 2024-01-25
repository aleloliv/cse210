using System;
using System.Collections.Generic;

public class Word
{
    public string _word { get; private set; } // the string _word attribute encapsulated so only the constructor can set it but anyone can see it

    public Word() // the class constructor that is meant to be an empty text constructor for the spaces, not used
    {
        _word = "";
    }
    public Word(string word) // the class constructor that accepts the string word as parameter
    {
        _word = word;
    }

    public string CaptalizeWord() // this would captalize the word, this was meant to read from text that is not standardized, not used
    {
        char[] letters = _word.ToCharArray();
        string first = letters[0].ToString();
        first = first.ToUpper();
        string wordWithoutBegining = "";
        string captalizedWord = "";
        for (int i = 1; i < _word.Length; i++)
        {
            wordWithoutBegining += letters[i];
        }
        captalizedWord = first + wordWithoutBegining;        
        return captalizedWord;
    }

    public void DisplayWord() // this will display the word in the console
    {
        Console.Write($"{_word} ");
    }

    public string HideWord() // this will hide the word replacing each character of the word by an underscore (_)
    {
        string letter = "_";
        string erasedWord = "";
        foreach (char c in _word) // for each character of the word this will add the letter string variable "_" to an empty string erasedWord
        {
            erasedWord += letter;
        }
        return erasedWord; // returns the hidden word
    }

    public void ShowWord() // this was meant to show a hidden word, too hard ant too little time to implement, not used
    {
        Console.WriteLine(_word);
    }

    public bool IsHidden() // this will check if the word is already hidden, comparing it to a string with the same ammount of characters but with underscores (_) instead
    {
        int n = _word.Length;
        string hiddenWord = "";

        for (int i = 0; i < n; i++) // this will create a new string with the same ammount of characters as the word but with underscores (_)
        {
            hiddenWord += "_";
        }

        if (_word == hiddenWord) // compares the hidden word to the actual word
        {
            return true; // if the hidden word matches with the actual word, returns true meaning it is hidden
        }
        else
        {
            return false; // if the hidden word doesn't match with the actual word, returns false meaning it is not hidden
        }

    }
}