using DbDocsGenerator.ExcelLogic;

namespace UnitTests
{
    public class ExcelHelperTests
    {
        private const int MaxLenght = 31;

        [Fact]
        public void GeneraleLineSheetName_ArgMoreThen31Symbols()
        {
            var nameArg = "asdfghjklwqertyuioqp[peqwertyui112";

            var generatedName = ExcelHelper.GenerateLinesheetName(nameArg);

            Assert.NotEqual(nameArg, generatedName);
            Assert.Equal(generatedName.Length, MaxLenght);
        }

        [Fact]
        public void GeneraleLineSheetName_ArgLessThen31Symbols()
        {
            var nameArg = "TestName";

            var generatedName = ExcelHelper.GenerateLinesheetName(nameArg);

            Assert.Equal(nameArg, generatedName);
        }
    }
}