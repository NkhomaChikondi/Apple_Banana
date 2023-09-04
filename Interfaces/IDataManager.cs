using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apple_Banana.Interfaces
{
    public interface IDataManager
    {
        string GetFile(string[] args);
        void outPutVerse(string Verse);
    }
}
