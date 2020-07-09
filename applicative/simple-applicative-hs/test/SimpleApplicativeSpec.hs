module SimpleApplicativeSpec (spec) where

import Test.Hspec

import SimpleApplicative

spec :: Spec
spec = do
  describe "SimpleApplicative" $ do
    it "Can contain a value" $
      let
        simpleApplicative = SimpleApplicative 1
      in
        simpleApplicative `shouldBe` (SimpleApplicative 1)

    describe "is a Functor" $ do
      it "Can map a value" $
        let
          mappedSimpleApplicative =  fmap (+1) (SimpleApplicative 1)
        in
          mappedSimpleApplicative `shouldBe` (SimpleApplicative 2)

      it "Conforms to the law: fmap id = id" $
        fmap id (SimpleApplicative 1) `shouldBe` (SimpleApplicative 1)

      it "Conforms to the law: (fmap g . h) = (fmap g) . (fmap h)" $
        let
          g = (+1)
          h = (*3)
          fmapComposed = fmap (g . h)
          composedFmap = (fmap g) . (fmap h)
        in
          fmapComposed (SimpleApplicative 1) `shouldBe` composedFmap (SimpleApplicative 1)

    describe "is an Applicative" $ do
      it "Can be made with pure" $
        pure 1 `shouldBe` SimpleApplicative 1

      it "Can be applied" $
        let
          saFun = pure (+ 1) :: SimpleApplicative (Int -> Int)
        in
          saFun <*> (pure 1) `shouldBe` (pure 2)

      it "Conforms to the applicative identity law" $
        (pure id) <*> (pure 1) `shouldBe` (pure 1 :: SimpleApplicative Int)

      it "Conforms to the applicative homomorphism law" $
        let
          f = (+2)
          x = 3 :: Int
        in
          pure f <*> pure x `shouldBe` (pure (f x) :: SimpleApplicative Int)

      it "Conforms to the applicative interchange law" $
        let
          u = pure (*2) :: SimpleApplicative (Int -> Int)
          y = 3 :: Int
        in
          u <*> pure y `shouldBe` pure ($ y) <*> u

      it "Conforms to the composition interchange law" $
        let
          u = pure (*2) :: SimpleApplicative (Int -> Int)
          v = pure (+3) :: SimpleApplicative (Int -> Int)
          w = pure 3 :: SimpleApplicative Int
        in
          u <*> (v <*> w) `shouldBe` pure (.) <*> u <*> v <*> w

      it "Properly relates to functors" $
        let
          g = (+3) :: Int -> Int
          x = pure (2) :: SimpleApplicative Int
        in
          fmap g x `shouldBe` pure g <*> x
