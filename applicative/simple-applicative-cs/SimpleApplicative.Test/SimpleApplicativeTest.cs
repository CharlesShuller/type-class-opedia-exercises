using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

using LanguageExt;
using static LanguageExt.Prelude;

using static FTest.FAssert;


using SimpleApplicativeCs;
using SimpleApplicativeCs.ClassInstances;


namespace SimpleApplicative.Test {

    [TestClass]
    public class SimpleApplicateiveTest
    {

        public Func<SimpleApplicative<T>, SimpleApplicative<V>> CurryFmap<T, V>(Func<T, V> func) =>
            curry(
                  (Func<T, V> f, SimpleApplicative<T> sa) =>
                  sa.Map(f)
            )
            (func);


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

        [TestMethod]
        public void FMapGofHIsSameAsFMapGOfFMapH() {
            SimpleApplicative<int> x = SimpleApplicative<int>.New(3);
            Func<int, int> g = x => x + 3;
            Func<int, int> h = x => x * 4;
            Func<int, int> gOfH = compose<int, int, int>(g, h);
            Func<SimpleApplicative<int>, SimpleApplicative<int>> fmapGofH = CurryFmap( gOfH );
            Func<SimpleApplicative<int>, SimpleApplicative<int>> fmapG = CurryFmap( g );
            Func<SimpleApplicative<int>, SimpleApplicative<int>> fmapH = CurryFmap( h );
            Func<SimpleApplicative<int>, SimpleApplicative<int>> fmapGOfFmapH =
                compose<SimpleApplicative<int>, SimpleApplicative<int>, SimpleApplicative<int>>(fmapG, fmapH);


            AreEqual (
                fmapGofH(x),
                fmapGOfFmapH(x),
                "fmap (g . h) === (fmap g) . (fmap h)"
            );
        }
    }
}
