namespace ServiceStation.BLL.DTO.Responses
{
    public class JwtResponse
    {
        public int ClientId { get; set; }

        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
