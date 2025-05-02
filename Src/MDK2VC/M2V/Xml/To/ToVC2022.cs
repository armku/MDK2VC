namespace MDK2VC.M2V.Xml
{
    public class ToVC2022 : ToVC2019Base, IToVC
    {
        public void Createsln(SysConfig cfg)
        {
            CreateslnBase(cfg);
        }
        public void Createvcxproj(SysConfig cfg)
        {
            CreatevcxprojBase(cfg, 143);
        }
    }
}
