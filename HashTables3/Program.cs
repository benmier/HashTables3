using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables3
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }

    class Word
    {
        public string theWord;
        public string definition;
        public int key;
        public Word next;
        public Word(string theWord, string definition)
        {
            this.theWord = theWord;
            this.definition = definition;
        }

        public string toString()
        {
            return theWord + " : " + definition;
        }
    }

    class WordList
    {
        public Word firstWord = null;
        public void insert(Word newWord, int hashKey)
        {
            Word previous = null;
            Word current = firstWord;
            newWord.key = hashKey;

            while (current != null && newWord.key > current.key)
            {
                previous = current;
                current = current.next;
            }

            if (previous == null)
            {
                firstWord = newWord;
            }
            else
            {
                previous.next = newWord;
            }

            newWord.next = current;
        }

        public void displayWordList()
        {
            Word current = firstWord;
            while(current != null)
            {
                Console.WriteLine(current);
                current = current.next;
            }
        }

        public Word find(int hashKey)
        {
            Word current = firstWord;
            while(current != null && current.key <= hashKey)
            {
                if(current.key == hashKey)
                {
                    return current;
                }

                current = current.next;
            }

            return null;
        }
    }

    class HashFuntion3
    {
        WordList[] theArray;
        int arraySize;

        public List<string> elementsToAdd = new List<string>
        {
            { "ace", "Very good" },
            { "act", "Take action" },
            { "add", "Join (something) to something else" },
            { "age", "Grow old" },
            { "ago", "Before the present" },
            { "aid", "Help, assist, or support" },
            { "aim", "Point or direct" },
            { "air", "Invisible gaseous substance" },
            { "all", "Used to refer to the whole quantity" },
            { "amp",
                    "Unit of measure for the strength of an electrical current" },
            { "and", "Used to connect words" }, { "ant", "A small insect" },
            { "any", "Used to refer to one or some of a thing" },
            { "ape", "A large primate" },
            { "apt", "Appropriate or suitable in the circumstances" },
            { "arc", "A part of the circumference of a curve" },
            { "are", "Unit of measure, equal to 100 square meters" },
            { "ark", "The ship built by Noah" },
            { "arm", "Two upper limbs of the human body" },
            { "art", "Expression or application of human creative skill" },
            { "ash", "Powdery residue left after the burning" },
            { "ask", "Say something in order to obtain information" },
            { "asp", "Small southern European viper" },
            { "ass", "Hoofed mammal" },
            { "ate", "To put (food) into the mouth and swallow it" },
            { "atm", "Unit of pressure" },
            { "awe", "A feeling of reverential respect" },
            { "axe", "Edge tool with a heavy bladed head" },
            { "aye", "An affirmative answer" }
    };

        HashFuntion3(int size)
        {
            arraySize = size;
            theArray = new WordList[size];
            for (int i = 0; i < arraySize; i++)
            {
                theArray[i] = new WordList();
            }
        }

        public int stringHashFunction(string wordToHash)
        {
            int hashKeyValue = 0;
            for (int i = 0; i < wordToHash.Length; i++)
            {
                int charCode = wordToHash[i] - 96;
                int hashKeyValueTemp = hashKeyValue;
                hashKeyValue = (hashKeyValue * 27 + charCode) % arraySize;
                Console.WriteLine(
                    $"Hash Key Value {hashKeyValue} * 27 + Character Code {charCode} % arraySize = {arraySize} hashKeyValue\n");
            }
            return hashKeyValue;
        }
    }
}
