namespace Daniel.Ecommerce.Services.WebApi.Helpers
{
    // clase para acceder a app settings en en memoria
    public class AppSettings
    {
        public string Key {  get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set;}
    }
}
