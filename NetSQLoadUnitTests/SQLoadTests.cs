namespace NetSQLoadUnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Attribute_SQLRoute()
        {
            string path = @"";
            SQLoad sqload = new(path);
            string query = sqload.Query("query3", 1, "'hola' AND 1=1");
            Assert.AreEqual(path, sqload.Path);
        }

        [Test]
        public void Test()
        {
            string query = "-- query1";
            var queryName = query.Split("--");
            Assert.Pass();
        }
    }
}