using System;

using LanguageExt;
using static LanguageExt.Prelude;

using SimpleApplicativeCs.ClassInstances;

namespace SimpleApplicativeCs {
    public static class SimpleApplicativeExtensions {
        public static SimpleApplicative<B> Apply<A, B>(
            this SimpleApplicative<Func<A,B>> fab,
            SimpleApplicative<A> fa
        ) =>
            ApplSimpleApplicative<A,B>.Inst.Apply(fab, fa);
    }
}
