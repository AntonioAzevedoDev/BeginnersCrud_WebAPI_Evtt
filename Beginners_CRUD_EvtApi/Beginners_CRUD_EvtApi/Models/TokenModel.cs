namespace Beginners_CRUD_EvtApi.Models
{
    public class TokenModel
    {
        public TokenModel(string token)
        {
            Token = token;
            ExpirationTime = DateTime.UtcNow.AddHours(-3).AddMinutes(30);
        }

        public string Token { get; set; }
        public DateTime ExpirationTime { get; set; }

    }
}
