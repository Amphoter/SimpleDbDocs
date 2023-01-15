namespace DbDocsGenerator.ExcelLogic
{
    public static class ExcelHelper
    {
        private const int maxNameLength = 31;

        public static string GenerateLinesheetName(string name)
        {
            if (name.Length > maxNameLength)
            {
                var diff = name.Length - maxNameLength;
                return name.Remove(name.Length - diff, diff);
            }

            return name;
        }
    }
}
