namespace KodluyoruzWEB.Service
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}