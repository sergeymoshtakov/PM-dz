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
        public void ElipsisExcetionTest()
        {
            Helper helper = new Helper();
            var ex = Assert.ThrowsException<ArgumentNullException>(
                () => helper.Ellipsis(null!, 3)
                );
            Assert.IsTrue(ex.Message.Contains("input"),"Exception should contain 'input' substring");
            var ex1 = Assert.ThrowsException<ArgumentException>(
                () => helper.Ellipsis("dsdgfsd", 2)
                );
            Assert.IsTrue(ex1.Message.Contains("less than 3"), "Exception should contain 'less than 3' substring");
            var ex2 = Assert.ThrowsException<ArgumentException>(
                () => helper.Ellipsis("abcd", 6)
                );
            Assert.IsTrue(ex2.Message.Contains("greater than input length"), "Exception should contain 'greater than input length' substring");
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

        [TestMethod]
        public void CombineUrlTest()
        {
            Helper helper = new Helper();
            Dictionary<String[], String> testCases = new ()
            {
                {new[] {"/home", "index"}, "/home/index"},
                {new[] {"/shop", "cart"}, "/shop/cart"},
                {new[] {"auth/", "logout"}, "/auth/logout"},
                {new[] {"forum/", "topic/"}, "/forum/topic"},
            };
            foreach(var testCase in testCases)
            {
                Assert.AreEqual(
                    testCase.Value,
                    helper.CombineUrl(testCase.Key[0], testCase.Key[1]),
                    $"{testCase.Value} -- {testCase.Key[0]} + {testCase.Key[1]}"
                    );
            }
        }

        [TestMethod]
        public void CombineUrlMultiTest()
        {
            Helper helper = new Helper();
            Dictionary<String[], String> testCases = new()
            {
                {new[] {"/home", "index", "123"}, "/home/index/123"},
                {new[] {"/shop", "cart", "/123"}, "/shop/cart/123"},
                {new[] {"auth/", "logout", "123/"}, "/auth/logout/123"},
                {new[] {"forum/", "topic/", "/123/"}, "/forum/topic/123"},
                {new[] { "/home///", "index"}, "/home/index"},
                {new[] { "///home/", "/index"}, "/home/index"},
                {new[] { "home/", "////index"}, "/home/index"},
                {new[] { "shop/", "////cart", "//user/", "..", "//123"}, "/shop/cart/user/123"},
                {new[] { "/shop/", "/cart/", "/user//", "/..//", "//123"}, "/shop/cart/user/123"}
            };
            foreach (var testCase in testCases)
            {
                Assert.AreEqual(
                    testCase.Value,
                    helper.CombineUrl(testCase.Key),
                    $"{testCase.Value} -- {testCase.Key[0]} + {testCase.Key[1]}"
                    );
            }
        }

        [TestMethod]
        public void CombineUrlExceptionTest()
        {
            Helper helper = new Helper();
            Assert.IsNotNull(
                () => helper.CombineUrl("/home", null!)
                );
            Assert.AreEqual("/home", helper.CombineUrl("home", null!));
            Assert.AreEqual("/home", helper.CombineUrl("home", null!, null!));
            Assert.AreEqual("/home", helper.CombineUrl("home", null!, null!, null!));
            Assert.AreEqual("/section/subsection", helper.CombineUrl("section///", "///subsection//", null!));
            var ex = Assert.ThrowsException<ArgumentException>(() => helper.CombineUrl(null!, null!));
            Assert.AreEqual("Arguments are null!", ex.Message);
            Assert.AreEqual(
                "Arguments are null!",
                Assert.ThrowsException<ArgumentException>(() => helper.CombineUrl(null!, null!, null!, null!)).Message);
            Assert.AreEqual(
                "Arguments are null!",
                Assert.ThrowsException<ArgumentException>(() => helper.CombineUrl(null!, null!, null!)).Message);
            Assert.AreEqual(
                "Arguments are null!",
                Assert.ThrowsException<ArgumentException>(() => helper.CombineUrl(null!)).Message);
            Assert.AreEqual(
                "Not null argument after null one",
                Assert.ThrowsException<ArgumentException>(() => helper.CombineUrl(null!, "/subsection")).Message
                );
            Assert.AreEqual(
                "Not null argument after null one",
                Assert.ThrowsException<ArgumentException>(() => helper.CombineUrl(null!, null!, "/subsection")).Message
                );
            Assert.AreEqual(
                "Not null argument after null one",
                Assert.ThrowsException<ArgumentException>(() => helper.CombineUrl(null!, "/subsection", null!)).Message
                );
            Assert.AreEqual(
                "Not null argument after null one",
                Assert.ThrowsException<ArgumentException>(() => helper.CombineUrl("section", null!, "/subsection")).Message
                );
        }
    }
}