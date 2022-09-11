using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace PasswordContainer
{
    class App
    {
        const string FILEPATH = "C:\\VS Projects\\PasswordContainer\\PasswordContainer\\src\\db.txt";
        List<Profile> Passwords = new List<Profile>();
        
        
        public void Program()
        {
            InitializePasswords();
            char input;
            Console.WriteLine("WELCOME TO THE SMOKEY'S PASSWORD CONTAINER");
           
            do
            {
                PrintUI();
                
                input = Console.ReadLine()[0];
                Console.Clear();


                switch (input)
                {
                    case 'A':
                        Passwords.Add(AddNewPassword());
                        break;
                    case 'S':
                        ShowTheCatalogue();
                        break;
                    case 'C':
                        SelectThePassword(TakeTheInput());
                        break;
                    case 'E':
                        Console.WriteLine("EXIT...");
                        break;
                    default:
                        Console.WriteLine("no action matched with this key");
                        break;
                }
                
              
                
            } while (input!='E');
            
        }
        public Profile AddNewPassword()
        {
            StreamWriter sw = new StreamWriter(FILEPATH, true);
            Console.WriteLine("Write the name of the wanted service");
            string name = Console.ReadLine();
            Console.WriteLine("Write the password");
            string password = "";
            while (true)
            {
                var key = System.Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                    break;
                password += key.KeyChar;
            }
            sw.WriteLine("{0} {1}", name, password);
            sw.Close();
            return new Profile(name, password);

        }
        public void ShowTheCatalogue()
        {
            Console.WriteLine("Here's your passwords:");
            for (int i = 0; i < Passwords.Count; i++)
            {
                Console.WriteLine(i+1+"- " + Passwords[i].ServiceName+": " + Passwords[i].Password);
            }
        }
        public void PrintUI()
        {
            Console.WriteLine("A - ADD A NEW PASSWORD");
            Console.WriteLine("S - SHOW ALL THE CATALOGUE");
            Console.WriteLine("C - SELECT ONE SERVICE AND COPY THE PASSWORD");
            Console.WriteLine("E - EXIT TO THIS PROGRAM");
        }
        private int TakeTheInput() 
        {
            Console.WriteLine("type the index of your desired service");
            char input;

            input = Console.ReadLine()[0];
            int index = (int)Char.GetNumericValue(input);
            return index;
        }
        private void SelectThePassword(int index) 
        {
            
            for (int i = 0; i < Passwords.Count; i++)
            {
                if(index == (i + 1)) 
                {
                    Clipboard.SetText(Passwords[i].Password); 
                }
            }
        }
        private void InitializePasswords() 
        {
            List<string> fileLines = File.ReadAllLines(FILEPATH).ToList();
            foreach(string line in fileLines) 
            {
               
                string[] elements = line.Split(" ");
                Passwords.Add(new Profile(elements[0], elements[1]));

            }
        }
    }
}