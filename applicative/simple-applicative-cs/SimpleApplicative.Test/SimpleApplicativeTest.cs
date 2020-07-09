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

        [TestMethod]
        public void CanMapAValue() =>
            AreEqual(
                SimpleApplicative<int>.New(1)
                    .Map( x => x + 1 ),
                SimpleApplicative<int>.New(2),
                "We should be able to increment with a map"
            );

        [TestMethod]
        //fmap id = id
        //We use a simple id function in the map, and just a new instance as the second arg as a
        //predictable return of id.
        public void MapIdIsSameAsId() =>
            AreEqual(
                SimpleApplicative<int>.New(1)
                    .Map( x => x ),
                SimpleApplicative<int>.New(1),
                "Map of the id function is the same as the id of the map"
            );

        }
    }
}
