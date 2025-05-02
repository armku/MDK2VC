namespace MDK2VC.M2V.Xml
{
    public class ToVC2022 : ToVC2019Base, IToVC
    {
        public void Createsln(SysConfig cfg)
        {
            CreateslnBase(cfg, "# Visual Studio Version 16", "VisualStudioVersion = 16.0.29201.188");
        }
        public void Createvcxproj(SysConfig cfg)
        {
            CreatevcxprojBase(cfg, 143);
        }
    }
}
