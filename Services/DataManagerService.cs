using Apple_Banana.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleBanana.Services
{
    public class DataManagerService : IDataManager
    {
        public string GetFile(string[] args)
        {
           // check if the args has content
           if(args.Length > 0)
           {
                // get file
                string file = args[0];
                   
                // check if the file exist
                if(File.Exists(file))                
                    // read file content
                    return File.ReadAllText(file);                
                else                
                    Console.WriteLine("Error: File not found");                
           }
           else
           {
                // Instruct the user to provide the file
                Console.WriteLine("Please provide a file");
                Environment.Exit(1);
                return "";
           }
            return string.Empty;
        }

        public void outPutVerse(string verse)
        {
            Console.WriteLine("   MODIFIED VERSE");
            Console.WriteLine(verse);
        }
    }
}
