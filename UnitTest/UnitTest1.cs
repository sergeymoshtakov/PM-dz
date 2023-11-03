using App;

namespace UnitTest
{
    [TestClass]
    public class HelperTest
    {
        [TestMethod]
        public void EllipsisTest()
        {
            Helper helper = new Helper();
            Assert.IsNotNull(helper, "new Helper() should not be null");
            Assert.AreEqual(
                "He...",
                helper.Ellipsis("Hello, world", 5));
            Assert.AreEqual(
                "Hel...",
                helper.Ellipsis("Hello, world", 6));
            Assert.AreEqual(
                "Tes...",
                helper.Ellipsis("Test string", 6));
        }
        [TestMethod]
        public void FinalizeTest()
        {
            Helper helper = new Helper();
            Assert.IsNotNull(helper, "new Helper() should not be null");
            Assert.AreEqual(
                "I love Paris.",
                helper.Finalize("I love Paris"));
            Assert.AreEqual(
                "Guten Tag.",
                helper.Finalize("Guten Tag."));
            Assert.AreEqual(
                "Hello world.",
                helper.Finalize("Hello world"));
            Assert.AreEqual(
                "Sprechen Sie Deutsch?.",
                helper.Finalize("Sprechen Sie Deutsch?"));
        }
    }
}