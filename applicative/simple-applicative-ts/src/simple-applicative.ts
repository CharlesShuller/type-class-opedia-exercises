export interface ApplicativeFunction<T, V> {
    (x: T): V;
}

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

export function pure<T>( x: T )
: SimpleApplicative<T> {
    return fromValue(x);
}

export function apply<T, V>( saApFun: SimpleApplicative< ApplicativeFunction<T, V> >, sa: SimpleApplicative<T> )
: SimpleApplicative<V> {
    return pure( saApFun.value(sa.value) );
}