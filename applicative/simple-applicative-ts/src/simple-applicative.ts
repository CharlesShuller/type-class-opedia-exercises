export class SimpleApplicative<T> {
    constructor(
        readonly value : T
    ) {}

    fmap<V>( fun: (x: T) => V )
    : SimpleApplicative<V> {
        return fmap(fun, this);
    }
}

export function fromValue<T>(value : T)
: SimpleApplicative<T> {
    return new SimpleApplicative(value);
}

export function fmap<T, V>( fun: (x: T) => V, sa: SimpleApplicative<T> )
: SimpleApplicative<V> {
    return fromValue( fun(sa.value) );
}