using SHL.Application.DTO.Company.Request;
using SHL.Domain.Models;

namespace SHL.Application.Interfaces
{
    public interface IStaffService : IGenericService<Staff, CreateStaffDto, UpdateStaffDto, ReadStaffDto> {
        Task<ReadStaffDto> StaffLogin(string email,string password);
    }
}
