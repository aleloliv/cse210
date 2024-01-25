using System;
using System.Collections.Generic;

public class Reference
{
    public string _book { get; private set; } // a string _book attribute encapsulated so only the constructor can set it but anyone can see it
    public int _chapter { get; private set; } // an int _chapter attribute encapsulated so only the constructor can set it but anyone can see it

    public int _verse { get; private set; } // an int _verse attribute encapsulated so only the constructor can set it but anyone can see it
    public List<int> _verses { get; private set; } = new List<int>(); // a List<int> _verses attribute encapsulated so only the constructor can set it but anyone can see it

    public Reference(string book, int chapter, int verse) // this is a constructor that accepts only one verse as argument
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _verses = null;
    }

    public Reference(string book, int chapter, List<int> verses) // this is a constructor that accepts multiple verses as arguments
    {
        _book = book;
        _chapter = chapter;
        _verse = 0;
        _verses = verses;
    }

    public void DisplayReference() // this will display only the reference, using the book, chapter and verse or verses
    {
        if (_verse == 0) // this checks if there are more than one verse in the reference
        {
            if (_verses.Count > 2) // if there are more than 2 verses, this will display the reference using a hifen like "Book C:V1-V2"
            Console.Write($"{_book} {_chapter}:{_verses[0]}-{_verses[_verses.Count - 1]} ");
            else // if there are exactly 2 verses, this will use a comma (,) to separate the verses like "Book C:V1,V2"
            {
                Console.Write($"{_book} {_chapter}:{_verses[0]},{_verses[1]} ");
            }
        }
        else // if there is only one verse this will display the reference like "Book C:V"
        {
            Console.Write($"{_book} {_chapter}:{_verse} ");
        }
    }
}