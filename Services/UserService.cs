using DAL.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService
    {
        private readonly InterviewContext _interviewContext;
        private readonly ILogger<UserService> _logger;

        public UserService(InterviewContext interviewContext, ILogger<UserService> logger)
        {
            _interviewContext = interviewContext ?? throw new ArgumentNullException(nameof(interviewContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<User> IsUserAuthenticate(User user)
        {
            return await Task.Run(() => _interviewContext.Users.Where(a => a.UserName == user.UserName && a.Password == user.Password && a.Active == true).FirstOrDefault());
        }
    }
}
