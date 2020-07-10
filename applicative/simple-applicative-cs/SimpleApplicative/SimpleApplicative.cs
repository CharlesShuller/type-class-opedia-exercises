using System;

using LanguageExt;
using static LanguageExt.Prelude;

using SimpleApplicativeCs.ClassInstances;

namespace SimpleApplicativeCs {
    [Record]
    public partial struct SimpleApplicative<T> {
        public readonly T Value;

        public SimpleApplicative<V> Map<V>(Func<T, V> f) =>
            FSimpleApplicative<T, V>.Inst.Map(this, f);
    }
}
