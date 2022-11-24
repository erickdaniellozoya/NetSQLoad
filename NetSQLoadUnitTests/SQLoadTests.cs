namespace NetSQLoadUnitTests
{
    public class Tests
    {
        private string _successDirectory;
        private string _successQueries1File;

        [SetUp]
        public void Setup()
        {
            _successDirectory = $@"{System.AppContext.BaseDirectory}TestQueries\";
            _successQueries1File = $@"{System.AppContext.BaseDirectory}TestQueries\queries1.sql";
        }

        [Test]
        public void Instace_Overload1_Success()
        {
            string path = _successDirectory;
            SQLoad sqload = new(path);
            Assert.Pass();
        }

        [Test]
        public void Instace_Overload2_Success()
        {
            string path = _successDirectory;
            SQLoad sqload = new(path, false);
            Assert.Pass();
        }

        [Test]
        public void Attribute_Get_Path()
        {
            string path = _successDirectory;
            string excpected = _successDirectory;
            SQLoad sqload = new(path);
            Assert.That(sqload.Path, Is.EqualTo(excpected));
        }

        [Test]
        public void Attribute_Get_Files()
        {
            string path = _successDirectory;
            List<string> excpected = new List<string>();
            excpected.Add("queries1.sql");
            excpected.Add("queries2.sql");
            SQLoad sqload = new(path);
            Assert.That(sqload.Files, Is.EqualTo(excpected));
        }

        [Test]
        public void Attribute_Get_CaseSensitive()
        {
            string path = _successQueries1File;
            SQLoad sqload = new(path);
            Assert.That(sqload.CaseSensitive, Is.True);
        }

        [Test]
        public void Attribute_Get_Queries()
        {
            string path = _successQueries1File;
            List<string> excpected = new List<string>();
            excpected.Add("SELECT * FROM Employees;");
            excpected.Add("SELECT * FROM Employees WHERE id = {0};");
            excpected.Add("SELECT * FROM Employees WHERE id = {0};\r\nUPDATE Employees SET active = 0 WHERE id = {0} AND active = {1};");
            SQLoad sqload = new(path);
            Assert.That(sqload.Queries, Is.EqualTo(excpected));
        }
    }
}