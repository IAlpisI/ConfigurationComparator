using ConfigurationComparatorAPI.Dtos;
using ConfigurationComparatorAPI.Enums;
using ConfigurationComparatorAPI.Manage.Console;
using System.Linq;

namespace ConfigurationComparatorAPI.Manage.Mappers
{
    public static class FilterDtoMapper
    {
        public static void MapFilterCommands(FilterDTO filter, ApiEmulateConsole apiManageConsole)
        {
            apiManageConsole.Write(filter.SourceFileName);
            apiManageConsole.Write(filter.TargetFileName);
            apiManageConsole.Write(((int)Commands.Filter).ToString());
            apiManageConsole.Write(filter.Id);
            apiManageConsole.Write(string.Join(string.Empty, filter.Statuses.Select(x => (int)x)));
        }

        public static void MapDataWithStringTypeId(ApiEmulateConsole apiManageConsole)
        {
            apiManageConsole.Write(((int)Commands.DataWithStringTypeId).ToString());
        }
    }
}
