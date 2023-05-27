namespace ServiceStation.BLL.DTO.Requests
{
    public class JwtRtquest
    {
        public string ClientName { get; set; }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}