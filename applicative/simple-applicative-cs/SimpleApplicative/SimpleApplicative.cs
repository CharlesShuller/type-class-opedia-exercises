using System;

using LanguageExt;
using static LanguageExt.Prelude;

namespace SimpleApplicativeCs {
    [Record]
    public partial struct SimpleApplicative<T> {
        public readonly T Value;
    }
}
