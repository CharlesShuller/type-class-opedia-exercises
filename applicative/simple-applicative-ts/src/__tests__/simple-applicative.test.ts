import {SimpleApplicative, fromValue} from "../simple-applicative"
import {fmap} from "../simple-applicative"
import {pure, apply} from "../simple-applicative"

type SimpleApplicativeNum = SimpleApplicative<number>;

function id<T>(x: T): T {
    return x;
}

function g(x: number): number {
    return x + 2;
}

function h(x: number): number {
    return x * 3;
}

function gOfH(x: number): number {
    return g(h(x));
}

function fmapG(sa: SimpleApplicativeNum)
: SimpleApplicativeNum {
    return fmap(g, sa);
}

function fmapH(sa: SimpleApplicativeNum)
: SimpleApplicativeNum {
    return fmap(h, sa);
}

function fmapGOfH(sa: SimpleApplicativeNum)
: SimpleApplicativeNum {
    return fmap(gOfH, sa);
}

function fmapGOfFmapH(sa: SimpleApplicativeNum)
: SimpleApplicativeNum {
    return fmapG(fmapH(sa));
}

test("Can be instantiated", () => {
    const sa: SimpleApplicative<number> = new SimpleApplicative(5);

    expect(sa.value).toBe(5);
});

test("Can be created with a function", () => {
    const sa = fromValue(5);

    expect(sa.value).toBe(5);
});

test("Has an fmap implementation", () => {
    const sa1 = fromValue(5);
    const sa2 = fmap( x => x + 1, sa1 );

    expect(sa2.value).toBe(6);
});

test("Has an fmap member", () => {
    const sa1 = fromValue(5);
    const sa2 = sa1.fmap( x => x + 1 );

    expect(sa2.value).toBe(6);
});

test("conforms to fmap id = id", () => {
    const sa1 = fromValue(5);
    const fmapId =
        (sa: SimpleApplicative<number>) =>
            fmap(id, sa);

    expect(fmapId(sa1).value).toBe(id(sa1).value);
});

test("conforms to fmap (g . h) = (fmap g) . (fmap h)", () => {
    const sa1 = fromValue(5);
    expect(fmapGOfH(sa1).value).toBe(fmapGOfFmapH(sa1).value);
});

test("Can be constructed with pure", () => {
    expect(pure(5).value).toBe(fromValue(5).value);
});

test("Can be constructed containing a function with pure", () => {
    const sa1 = pure( g );
    expect(sa1.value).toBe(g);
});

test("Can be applied", () => {
    const saApFun = pure( (x: number) => x + 3 );
    const saRes = apply(saApFun, pure(1))

    expect(saRes.value).toBe(4);
});


test("Conforms to the applicative identity law", () => {
    const v: SimpleApplicativeNum = pure(1);
    const pureIdApV: SimpleApplicativeNum = apply(pure(id as (x: number) => number), v);

    expect(pureIdApV).toEqual(v);
});

test("Conforms to the applicative homomorphism law", () => {
    const x = 1;
    const pureG = pure( g );
    const pureX = pure ( x );
    const pureGofX = pure( g(x) );

    expect( apply(pureG, pureX) ).toEqual( pureGofX );
});

//Skipping the applicative interchange law, it needs stuff that typescript doesn't have, notably the ability
//to do this:  pure ($ y) <*> u, where the $ is the function application operator.

//Skipping the applicative composition law, it needs a composition operator, which typescript does not have