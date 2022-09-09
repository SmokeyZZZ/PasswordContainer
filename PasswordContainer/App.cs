using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PasswordContainer
{
    class App
    {
        List<Profile> Passwords = new List<Profile>();
        public void Program()
        {
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
                    default:
                        Console.WriteLine("no action matched with this key");
                        break;
                }
                
                
            } while (input!='E');
        }
        public Profile AddNewPassword()
        {
            Console.WriteLine("Write the name of the wanted service");
            string name = Console.ReadLine();
            Console.WriteLine("Write the password");
            string password = Console.ReadLine();
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
        private int SelectThePassword(int index) 
        {
            
            for (int i = 0; i < Passwords.Count; i++)
            {
                if(index == (i + 1)) 
                {
                    Clipboard.SetText(Passwords[i].Password);
                    return i;
                    
                }
            }

            return 0; 

        }
        private void CopyThePassword() 
        {
            //copierà la password in qualche modo
            
        }


    }
}