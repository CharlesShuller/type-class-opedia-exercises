using System;
using System.Diagnostics.Contracts;

using LanguageExt.TypeClasses;
using static LanguageExt.Prelude;

using SimpleApplicativeCs;

namespace SimpleApplicativeCs.ClassInstances {
    public struct ApplSimpleApplicative<A, B> :
        Functor< SimpleApplicative<A>, SimpleApplicative<B>, A, B >,
        Applicative< SimpleApplicative< Func<A, B> >, SimpleApplicative<A>, SimpleApplicative<B>, A, B > {

        public static readonly ApplSimpleApplicative<A, B> Inst = default(ApplSimpleApplicative<A, B>);

        [Pure]
        public SimpleApplicative<B> Map(
            SimpleApplicative<A> ma,
            Func<A, B> f
        ) =>
            FSimpleApplicative<A, B>.Inst.Map(ma, f);

        [Pure]
        public SimpleApplicative<A> Pure(A x) =>
            SimpleApplicative<A>.New(x);

        [Pure]
        public SimpleApplicative<B> Apply(
            SimpleApplicative< Func<A, B> > fab,
            SimpleApplicative<A> fa
        ) =>
            SimpleApplicative<B>.New( fab.Value(fa.Value) );

        [Pure]
        public SimpleApplicative<B> Action(
            SimpleApplicative<A> fa,
            SimpleApplicative<B> fb
        ) => fb;

    }
}
