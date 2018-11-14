/*
 1.  Створити клас(и) для реалізації Англо-українського словника.Використати одну з колекцій, що може працювати з парами Ключ-Значення
(SortedList,SortedList<>, Dictionary<>, SortedDictionary<> )

Передбачити наступні можливості словника
	- Вивід інформації про всі пари(слово - переклад)
	- Додавання нової пари слово - переклад
	- Зміна слова- перекладу
	- Пошук перекладу для англ.слова
	- Пошук перекладу для укр.слова
	
	- Вилучення пари з словника
	- Редагування пари з словника
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_dictionary
{
    class Program
    {
        class Dictionary
        {
            SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();

            // Додавання нової пари слово - переклад
            public void AddWord(string eng, string ukr)
            {
                dictionary.Add(eng, ukr);
            }

            // Зміна слова- перекладу
            public void ChangeWord()
            {
                Console.Write("Enter word for change translation:\t");
                string eng = Console.ReadLine();
                if (dictionary.TryGetValue(eng, out string result))
                {
                    
                    Console.Write("Enter new translate:\t");
                    string ukr = Console.ReadLine();
                    dictionary[eng] = ukr;
                    Console.WriteLine($"\n'{eng}' was change translation on '{ukr}'");
                }
                else
                {
                    Console.WriteLine($"\n'{eng}' was  NOT found");
                }
            }

            // Пошук перекладу для англ.слова
            public void FindEng(string search)
            {
                if (dictionary.TryGetValue(search, out string result))
                {
                    Console.WriteLine($"\n'{search}' was found and  its value is '{dictionary[search]}'");
                }
                else
                {
                    Console.WriteLine($"\n'{search}' was  NOT found");
                }
            }

            // Пошук перекладу для укр.слова
            public void FindUkr(string search)
            {
                var word = dictionary.TakeWhile(x => x.Value == search);
                Console.WriteLine(word);
                /*
                if (dictionary.TryGetValue(dictionary[search], out string result))
                {
                    Console.WriteLine($"\n'{search}' was found and  its value is '{dictionary[search]}'");
                }
                else
                {
                    Console.WriteLine($"\n'{search}' was  NOT found");
                }
                */
            }

            //  Вилучення пари з словника
            public void RemoveWord()
            {
                Console.Write("Enter word for delete:\t");
                string eng = Console.ReadLine();
                if (dictionary.TryGetValue(eng, out string result))
                {
                    dictionary.Remove(eng);
                    Console.WriteLine($"\nWord '{eng}' was deleted from dictionary");
                }
                else
                {
                    Console.WriteLine($"\n'{eng}' was  NOT found");
                }
            }

            /*
            // Редагування пари з словника
            public void EditWord()
            {
                Console.Write("Enter word for edit:\t");
                string eng = Console.ReadLine();
                if (dictionary.TryGetValue(eng, out string result))
                {
                    
                    Console.Write("Enter new translate:\t");
                    string newEng = Console.ReadLine();
                    
                    Console.Write("Enter new translate:\t");
                    string ukr = Console.ReadLine();
                    dictionary[eng] = ukr;
                    Console.WriteLine($"\n'{eng}' was change translation on '{ukr}'");
                }
                else
                {
                    Console.WriteLine($"\n'{eng}' was  NOT found");
                }
            }
            */

            // Вивід інформації про всі пари(слово - переклад)
            public void Print()
            {
                Console.WriteLine();
                foreach (var el in dictionary)
                {
                    Console.WriteLine($"{el.Key} -\t{el.Value}");
                }
                Console.WriteLine();
            }
        }
       

        static void Main(string[] args)
        {
            Dictionary vocabulary = new Dictionary();
            vocabulary.AddWord("true", "iстина");
            vocabulary.AddWord("car", "машина");
            vocabulary.AddWord("pencil", "олiвець");
            vocabulary.AddWord("book", "книга");

            vocabulary.Print();
            vocabulary.FindEng("car");
            vocabulary.FindUkr("книга");
            vocabulary.ChangeWord();
            vocabulary.Print();
            vocabulary.RemoveWord();
            vocabulary.Print();



            Console.ReadKey();
        }
    }
}

