module SimpleApplicative
  (
    SimpleApplicative(..)
  ) where

data SimpleApplicative a = SimpleApplicative a
  deriving(Show, Ord, Eq)


instance Functor SimpleApplicative where
  fmap g (SimpleApplicative x) = SimpleApplicative $ g x

instance Applicative SimpleApplicative where
  pure x = SimpleApplicative x
  (SimpleApplicative g) <*> (SimpleApplicative x) = SimpleApplicative (g x)
