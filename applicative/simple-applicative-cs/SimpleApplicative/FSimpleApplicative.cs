using System;
using System.Diagnostics.Contracts;

using LanguageExt.TypeClasses;
using static LanguageExt.Prelude;

using SimpleApplicativeCs;

namespace SimpleApplicativeCs.ClassInstances {
    public struct FSimpleApplicative<A, B>
        : Functor<SimpleApplicative<A>, SimpleApplicative<B>, A, B> {

        public static readonly FSimpleApplicative<A, B> Inst = default(FSimpleApplicative<A, B>);

        [Pure]
        public SimpleApplicative<B> Map(SimpleApplicative<A> ma, Func<A, B> f) =>
            ma.Map(f);
    }
}
