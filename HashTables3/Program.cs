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
    }

    class HashFuntion3
    {
        WordList[] theArray;
        int arraySize;
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
