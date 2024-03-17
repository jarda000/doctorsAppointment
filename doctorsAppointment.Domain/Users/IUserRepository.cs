using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorsAppointment.Domain.Users;

internal interface IUserRepository
{
    void CreateAsync(User user);
    Task<User> GetByIdAsync(Guid id);
}
