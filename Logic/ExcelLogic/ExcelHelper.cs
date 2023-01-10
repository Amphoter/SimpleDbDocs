namespace DbDocsGenerator.ExcelLogic
{
    public class ExcelHelper
    {
        private const int maxName = 31;

        public static string GenerateLinesheetName(string name)
        {
            if (name.Length > maxName)
            {
                var diff = name.Length - maxName;
                return name.Remove(name.Length - diff, diff);
            }

            return name;
        }
    }
}
