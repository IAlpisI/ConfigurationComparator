using ConfigurationComparatorAPI.Dtos;
using ConfigurationComparatorAPI.Enums;
using ConfigurationComparatorAPI.Manage.Console;
using System.Linq;

namespace ConfigurationComparatorAPI.Manage.Mappers
{
    public static class FilterDtoMapper
    {
        public static void MapInitializeData(FilterDTO filter, ApiEmulateConsole apiManageConsole)
        {
            apiManageConsole.AddCommand(filter.SourceFileName);
            apiManageConsole.AddCommand(filter.TargetFileName);
        }

        public static void MapFilterCommands(FilterDTO filter, ApiEmulateConsole apiManageConsole)
        {
            apiManageConsole.AddCommand(((int)Commands.Filter).ToString());
            apiManageConsole.AddCommand(filter.Id);
            apiManageConsole.AddCommand(string.Join(string.Empty, filter.Statuses.Select(x => (int)x)));
        }

        public static void MapDataWithStringTypeId(ApiEmulateConsole apiManageConsole)
        {
            apiManageConsole.AddCommand(((int)Commands.DataWithStringTypeId).ToString());
        }
    }
}
