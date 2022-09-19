namespace RunGroupWebApp.Helpers
{
    public class CloudinarySettings
    {

        //2. Cloud ayarları için class oluşturulur. İsterse azure da kullanılabiliyor.

        public string CloudName { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        //3. servis kısmı oluşturulur repository olmamasının nedeni database dısında seyleri de cağırıyor?
    }
}
