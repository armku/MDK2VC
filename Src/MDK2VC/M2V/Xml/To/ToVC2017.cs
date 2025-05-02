namespace MDK2VC.M2V.Xml
{
    public class ToVC2017 : ToVC2019Base, IToVC
    {
        public void Createvcxproj(SysConfig cfg, int type = 0)
        {
            CreatevcxprojBase(cfg, 141);
        }
    }
}
