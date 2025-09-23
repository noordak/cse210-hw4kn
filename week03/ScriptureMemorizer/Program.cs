// Scripture memorizer program, take 8


// Scripture memorizer program --- Take 6

// Program Requirements.

// Store a scripture, including both the reference (for example "John 3:16") and the text of the scripture.
// Accommodate scriptures with multiple verses, such as "Proverbs 3:5-6".
// Clear the console screen and display the complete scripture, including the reference and the text.
// Prompt the user to press the enter key or type quit.
// If the user types quit, the program should end.
// If the user presses the enter key (without typing quit), the program should hide a few random words in the scripture, clear the console screen, and display the scripture again. (Hiding a word means that the word should be replace by underscores (_) and the number of underscores should match the number of letters in that word.)
// The program should continue prompting the user and hiding more words until all words in the scripture are hidden.
// When all words in the scripture are hidden, the program should end. (The final display of the scripture should show the scripture with all words hidden.)
// When selecting the random words to hide, for the core requirements, you can select any word at random, even if the word was already hidden. (As a stretch challenge, try to randomly select from only those words that are not already hidden.)



using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a reference
            Reference reference = new Reference("Proverbs", 3, 5, 6);

            // Create scripture
            string text = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";
            Scripture scripture = new Scripture(reference, text);

            while (!scripture.AllWordsHidden())
            {
                Console.Clear();
                scripture.Display();

                Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "quit")
                    break;

                scripture.HideRandomWords(3); // Hide 3 random words per round
            }

            Console.Clear();
            scripture.Display();
            Console.WriteLine("\nAll words are now hidden. Program ended.");
        }
    }

    class Reference
    {
        private string _book;
        private int _chapter;
        private int _startVerse;
        private int? _endVerse;

        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = null;
        }

        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        public string GetDisplayText()
        {
            if (_endVerse.HasValue)
                return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
            else
                return $"{_book} {_chapter}:{_startVerse}";
        }
    }

    class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        public string GetDisplayText()
        {
            if (_isHidden)
                return new string('_', _text.Length);
            else
                return _text;
        }
    }

    class Scripture
    {
        private Reference _reference;
        private List<Word> _words;
        private Random _random;

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = new List<Word>();
            _random = new Random();

            // Split on spaces and keep punctuation attached
            foreach (string word in text.Split(' '))
            {
                _words.Add(new Word(word));
            }
        }

        public void HideRandomWords(int count)
        {
            var notHiddenWords = _words.Where(w => !w.IsHidden()).ToList();

            if (notHiddenWords.Count == 0)
                return;

            for (int i = 0; i < count; i++)
            {
                if (notHiddenWords.Count == 0)
                    break;

                int index = _random.Next(notHiddenWords.Count);
                notHiddenWords[index].Hide();
                notHiddenWords.RemoveAt(index);
            }
        }

        public void Display()
        {
            Console.WriteLine(_reference.GetDisplayText());
            foreach (Word word in _words)
            {
                Console.Write(word.GetDisplayText() + " ");
            }
            Console.WriteLine();
        }

        public bool AllWordsHidden()
        {
            return _words.All(w => w.IsHidden());
        }
    }
}

