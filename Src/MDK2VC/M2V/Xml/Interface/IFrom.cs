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
        String getGroups(string path);
        String getGroupsToFilters(string path);
        String getGroupsToProj( string path);
        String getGrouptoFilters(string path);
    }
}
