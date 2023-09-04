
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AppleBanana.Services;
using Apple_Banana.Interfaces;

namespace AppleBanana
{
    public class Program
    {
        static void Main(string[] args)
        {
            // register dependencies            
            var serviceProvider = new ServiceCollection().AddSingleton<IDataManager,DataManagerService>().BuildServiceProvider();
            var VerseProvider = new ServiceCollection().AddSingleton<IVerseProcessor, VerseProcessorService>().BuildServiceProvider();

            // Resolve dependencies
            var appleBananaService = serviceProvider.GetRequiredService<IDataManager>();
            var verseService = VerseProvider.GetRequiredService<IVerseProcessor>();

            var file = appleBananaService.GetFile(args);

            // get vowel
            char vowel = verseService.getVowel();

            if (vowel == '\0')
                return;
            else
            {
                // get verse processor
                var modifiedVerse = verseService.processVerse(file, vowel);
                appleBananaService.outPutVerse(modifiedVerse);
            }

            // dispose the dependencies
            serviceProvider.Dispose();
            VerseProvider.Dispose();

        }
    }
}
