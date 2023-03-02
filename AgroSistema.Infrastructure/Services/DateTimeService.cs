using AgroSistema.Application.Common.Interface;

namespace AgroSistema.Infrastructure.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
