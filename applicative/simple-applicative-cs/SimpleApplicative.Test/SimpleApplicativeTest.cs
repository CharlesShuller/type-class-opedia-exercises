using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

using LanguageExt;
using static LanguageExt.Prelude;

using static FTest.FAssert;


using SimpleApplicativeCs;

namespace SimpleApplicative.Test {
    [TestClass]
    public class SimpleApplicateiveTest
    {
        [TestMethod]
        public void SimpleConstructionTest() =>
            IsNotNull(
                SimpleApplicative<int>.New(12),
                "New must not return null"
            );

    }
}
