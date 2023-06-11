namespace VouViajar.Auth.Application.Messages
{
    public class AgenciaMessage
    {
        public AgenciaMessage()
        {
        }

        public AgenciaMessage(string id, string email)
        {
            this.Id = id;
            this.Email = email;
        }

        string Id { get; set; }
        string Email { get; set; }

    }
}
