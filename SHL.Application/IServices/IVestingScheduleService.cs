using SHL.Application.DTO.Company.Request;
using SHL.Domain.Models;

namespace SHL.Application.Interfaces
{
    public interface IVestingScheduleService : IGenericService<VestingSchedule, CreateVestingScheduleDto, UpdateVestingScheduleDto, ReadVestingScheduleDto> {}
}
