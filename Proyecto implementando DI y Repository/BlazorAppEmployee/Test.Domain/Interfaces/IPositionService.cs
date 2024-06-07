using Test.Domain.Entities;

namespace Test.Domain.Interfaces;
public interface IPositionService
{
    Task<List<Position>> GetPositionsAsync();
}
