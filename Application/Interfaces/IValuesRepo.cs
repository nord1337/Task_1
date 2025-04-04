using Application.Dtos;
using Application.Models;

namespace Application.Interfaces;

public interface IValuesRepo
{
    Task<IEnumerable<GetValueDto>> GetValues(FilterModel filterModel);

    Task AddValues(IEnumerable<AddValueDto> values);
}
