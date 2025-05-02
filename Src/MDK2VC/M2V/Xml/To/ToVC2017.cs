using System.Text;

namespace MDK2VC.M2V.Xml
{
    public class ToVC2017 : ToVCBase, IToVC
    {
        public void Createsln(SysConfig cfg)
        {
            var builder = new StringBuilder();

            builder.AppendLine("Microsoft Visual Studio Solution File, Format Version 12.00");
            builder.AppendLine("# Visual Studio 15");
            builder.AppendLine("VisualStudioVersion = 15.0.35213.121");
            builder.AppendLine("MinimumVisualStudioVersion = 10.0.40219.1");

            CreateslnBase(cfg, builder.ToString());
        }
        public void Createvcxproj(SysConfig cfg)
        {
            CreatevcxprojBase(cfg, 141);
        }
    }
}
