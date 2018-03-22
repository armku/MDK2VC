using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDK
{
    public interface IToVC2017
    {
        void VC_Creat_readme(string DocName, string ProjectName);
        void VC_Creat_Sln(string DocName, string ProjectName, string[] Targets);
    }
}
