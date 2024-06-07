using Test.Domain.Entities;
using Test.Domain.Interfaces;

namespace Test.Services;
public class PositionService : IPositionService
{
    public async Task<List<Position>> GetPositionsAsync() =>
        new List<Position>
        {
            new Position { Id = 1, Nombre = "Gerente" },
            new Position { Id = 2, Nombre = "Administrador" },
            new Position { Id = 3, Nombre = "Desarrollador" },
        };
}
