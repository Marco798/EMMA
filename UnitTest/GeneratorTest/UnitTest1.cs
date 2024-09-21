using Generator;

namespace GeneratorTest {
	[TestClass]
	public class GeneratorTest {
		[TestMethod]
		public void CallMain() {
			try {
				Directory.SetCurrentDirectory(@"..\..\..\..\..\Generator\bin\Debug\net8.0\");
				Program.Main();
			}
			catch (Exception ex) {
				Assert.Fail(ex.Message);
			}
		}
	}
}