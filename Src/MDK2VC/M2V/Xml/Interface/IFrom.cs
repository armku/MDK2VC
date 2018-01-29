using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDK2VC.M2V.Xml
{
    public interface IFrom
    {
        String GetMacroDefine(string path);
        string getIncludePath(string path);
        void getGroups(StringBuilder builder, string path);
    }
}
