module Main where

import SimpleApplicative

simpleApplicative :: SimpleApplicative Int
simpleApplicative =
  SimpleApplicative 12

main :: IO ()
main =
  putStrLn (show simpleApplicative)
