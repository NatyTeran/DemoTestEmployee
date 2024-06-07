using Test.Domain.Entities;
using Test.Domain.Interfaces;

namespace Test.Services
{
    public class StateService : IStateService
    {
        public async Task<List<State>> GetStatesAsync() =>
            new List<State> {
                new State { Id = 1, Nombre = "Activo" },
                new State { Id = 1, Nombre = "Inactivo" }
            };
    }
}
