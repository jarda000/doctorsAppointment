namespace doctorsAppointment.Domain.Users;

internal interface IUserRepository
{
    void CreateAsync(User user);
    Task<User> GetByIdAsync(Guid id);
}
