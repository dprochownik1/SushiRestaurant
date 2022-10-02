namespace Sushi.Web
{
    public class StaticDetails
    {
        public static string DishApiBase { get; set; }

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE,
        }
    }
}
