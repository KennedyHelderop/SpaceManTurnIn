using System;
using static System.Console;
class main
{
    static void Main()
    {
        string[] words = {"cornerstone", "eagle", "soar",
         "matters", "ceasing", "christ",
         "stowell", "rock"};
        Random RandomClass = new Random();
        int randomNumber;
        randomNumber = RandomClass.Next(0, words.Length);
        string selectedWord = words[randomNumber];
        string guessedWord = "";
        string originalWord = selectedWord;
        string guess;
        char letter;
        int pos;
        char tempChar;
        int foundCount = 0;
        bool letterInWord;
        for (int a = 0; a < selectedWord.Length; ++a)
            guessedWord = guessedWord + "*";
        while (foundCount < selectedWord.Length)
        {
            try
            {
                WriteLine("Word: {0}", guessedWord);
                Write("Guess a letter >> ");
                guess = ReadLine();
                if (!char.IsLetter(Convert.ToChar(guess)))
                {
                    throw (new MyException(guess));
                }
                letter = Convert.ToChar(guess.Substring(0, 1));
                letterInWord = false;
                for (pos = 0; pos < selectedWord.Length; ++pos)
                {
                    tempChar = Convert.ToChar(selectedWord.Substring(pos, 1));
                    if (tempChar == letter)
                    {
                        guessedWord = guessedWord.Substring(0, pos) + letter + guessedWord.Substring(pos + 1, (guessedWord.Length - 1 - pos));
                        selectedWord = selectedWord.Substring(0, pos) + '?' + selectedWord.Substring(pos + 1, (guessedWord.Length - 1 - pos));
                        ++foundCount;
                        letterInWord = true;
                    }

                }
                if (letterInWord)
                    WriteLine("Let's GOOOOO! {0} is in the word", letter);
                else
                    WriteLine("Oops, no. {0} is not in the word", letter);
            }
            catch (MyException ex)
            {
                WriteLine("      " + ex.Message);
            }
        }
        WriteLine("You got it! The correct word was {0}", originalWord);
    }

}


    public class MyException : Exception
    {
        public MyException(string message)
            : base("Not a letter: " + message)
        {

        }
    }