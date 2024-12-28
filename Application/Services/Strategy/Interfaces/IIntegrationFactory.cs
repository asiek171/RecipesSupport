using Application.Enums;

namespace Application.Services.Strategy.Interfaces
{
    public interface IIntegrationFactory
    {
        IIntegrationStrategy GetStrategy(SystemType systemType);
    }
}
