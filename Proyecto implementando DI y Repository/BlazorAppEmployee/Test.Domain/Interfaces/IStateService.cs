using Test.Domain.Entities;

namespace Test.Domain.Interfaces;
public interface IStateService
{
    Task<List<State>> GetStatesAsync();
}
