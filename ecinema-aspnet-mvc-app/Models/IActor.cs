namespace ecinema_aspnet_mvc_app.Models
{
    public interface IActor
    {
        int Id { get; set; }
        string FullName { get; set; }

        string Bio { get; set; }

        string PictureUrl { get; set; }
    }
}
