using ConfigurationComparatorAPI.Dtos;
using ConfigurationComparatorAPI.Manage.Console;
using ConfigurationComparatorAPI.Models;
using System.Linq;

namespace ConfigurationComparatorAPI.Manage.Mappers
{
    public static class FilterDtoMapper
    {
        public static void MapInitializeData(ConfigurationFiles confFies, ApiEmulateConsole apiManageConsole)
        {
            apiManageConsole.AddCommand(confFies.Source);
            apiManageConsole.AddCommand(confFies.Target);
        }

        public static void MapFilterCommands(FilterDTO filter, ApiEmulateConsole apiManageConsole)
        {
            apiManageConsole.AddCommand(Commands.Filter);
            apiManageConsole.AddCommand(filter.Id);
            apiManageConsole.AddCommand(string.Join(string.Empty, filter.Statuses.Select(x => (int)x)));
        }

        public static void MapDataWithStringTypeId(ApiEmulateConsole apiManageConsole)
        {
            apiManageConsole.AddCommand(Commands.DataWithStringTypeId);
        }
    }
}
