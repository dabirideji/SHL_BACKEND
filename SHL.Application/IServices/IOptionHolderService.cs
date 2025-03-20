﻿using SHL.Application.DTO.Company.Request;
using SHL.Domain.Models;

namespace SHL.Application.Interfaces
{
    public interface IOptionHolderService : IGenericService<OptionHolder, CreateOptionHolderDto, UpdateOptionHolderDto, ReadOptionHolderDto> {}
}
