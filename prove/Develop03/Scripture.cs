using System;

public class Scripture
{
    public Reference _reference { get; private set; } // a reference attribute that cannot be setted outside of the constructor, only seen
    public List<Word> _text { get; private set; } = new List<Word>(); // a list of words attribute that cannot be setted outside of the constructor, only seen

    public Scripture(Reference reference, List<Word> text) // the class constructor
    {
        _reference = reference;
        _text = text;
    }

    public void DisplayScripture() // this will display the entire scripture with the reference and the text
    {
        _reference.DisplayReference();
        foreach (Word word in _text)
        {
            word.DisplayWord();
        }
    }

    public List<Word> HideRandomWord() // this will pick 3 random words and hide them
    {
        List<Word> hidden = new List<Word>(); // an empty list of words that are already hidden
        List<Word> notHidden = new List<Word>(); // an empty list of words that are not hidden
        // List<Word> newText = new List<Word>(_text); // I tried to make something else, this is not important for the code
        foreach (Word w in _text) // this will check if the word is already hidden and add the not hidden words to the proper list and the already hidden word to its list
        {
            if (!w.IsHidden())
            {
                notHidden.Add(w);
            }
            else
            {
                hidden.Add(w);
            }
        }
        
        Random random = new Random(); // creates a random object

        for (int i = 0; i < 3 && notHidden.Count > 0; i++) // this will count to 3, than pick 3 random words using the list index to hide them
        {
            int randomIndex = random.Next(0, notHidden.Count); // picks a random number ranging from 0 to the number of words that are not hidden

            if (!notHidden[randomIndex].IsHidden()) // if the word is not hidden, this hides it
            {
                hidden.Add(notHidden[randomIndex]); // this will add the picked word (using the index from the random number to pick it from the notHidden list) to the hidden list
                string wordString = notHidden[randomIndex].HideWord(); // this will hide the word and assign it to a string wordString variable
                Word hiddenWord = new Word(wordString); // this will call a constructor to make the word a Word object
                _text[_text.IndexOf(notHidden[randomIndex])] = hiddenWord; // this will get the index of the scripture text list of words for the picked word that is now hidden
            }
            notHidden.RemoveAt(randomIndex); // this will remove the now hidden word from the notHidden list, so it is not picked again to be hidden
    }

    return _text; // returns the new text with the random words hidden
}

    public bool IsCompletelyHidden() // this checks if the list of words _text is completely hidden
    {
        bool isHidden = false;
        bool allHidden = false;
        foreach (Word word in _text) // for each word in the text it will check if it is hidden
        {
            if (isHidden != word.IsHidden()) // if the word is hidden assign true to the bool variable allHidden
            {
                allHidden = true;
            }
            else
            {
                allHidden = false; // if the word is not hidden assign false and breaks the loop
                break;
            }
        }
        if (allHidden == true) // if allHidden is true, returns true
        {
            return true;
        }
        else // if allHidden is false, returns false
        {
            return false;
        }
    }

    public void ShowHiddenWords() // this was supposed to show the hidden words, I was trying to make the code accept go back and forward hiding and showing back hidden words, but I couldn't do it in time, this should be ignored
    {
        foreach (Word word in _text)
        {
            if (word.IsHidden() == true)
            {
                word.DisplayWord();
            }
            else
            {
                word.DisplayWord();
            }
        }
    }
}