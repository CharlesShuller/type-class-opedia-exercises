using System;

using LanguageExt;
using static LanguageExt.Prelude;

namespace SimpleApplicativeCs {
    [Record]
    public partial struct SimpleApplicative<T> {
        public readonly T Value;

        public SimpleApplicative<V> Map<V>(Func<T, V> f) =>
            SimpleApplicative<V>.New( f(Value) );
    }
}
