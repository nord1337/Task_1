using Application.Dtos;
using Application.Extension;
using Application.Interfaces;
using Application.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services;

internal class ValuesRepo : IValuesRepo
{
    private readonly IDbContext _context;
    private readonly IMapper _mapper;

    public ValuesRepo(IDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddValues(IEnumerable<AddValueDto> values)
    {
        var entityValues = _mapper.Map<IEnumerable<ValueEntity>>(values);

        // что подразумевается под порядковым номером? это идентификатор или просто индекс в списке?

        await _context.AddRangeAsync(entityValues);

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<GetValueDto>> GetValues(FilterModel filterModel)
    {
        var query = GetFilterQuery(filterModel);

        return await query
            .OrderBy(x => x.Code)
            .ProjectTo<GetValueDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }

    private IQueryable<ValueEntity> GetFilterQuery(FilterModel filterModel)
        => _context.ValueEntities
            .WhereIf(string.IsNullOrEmpty(filterModel.ValueFilter) is false, x => x.Value == filterModel.ValueFilter)
            .WhereIf(filterModel.CodeFilter.HasValue, x => x.Code == filterModel.CodeFilter.Value);
}
