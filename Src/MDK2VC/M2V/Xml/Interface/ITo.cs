using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MDK2VC.M2V.Xml
{
    public interface ITo
    {
        void createvcxproj(SysConfig cfg);
        void createfilters(SysConfig cfg);
        void createsln(SysConfig cfg);
    }
}
