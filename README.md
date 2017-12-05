# Rock Paper Scissors

A Kata based on  [http://agilekatas.co.uk/katas/RockPaperScissors-Kata](http://agilekatas.co.uk/katas/RockPaperScissors-Kata)

#### Game Rules
A match takes place between 2 players and is made up of 3 games, with the overall winner being the first player to win 2 games (i.e. best of 3).

Each game consists of both players selecting one of Rock, Paper or Scissors; the game winner is determined based on the following rules:

       Rock beats scissors

       Scissors beats paper

       Paper beats rock

Consider in the design of the application, [the ability to add new moves, such as lizard and Spock](https://en.wikipedia.org/wiki/Rock%E2%80%93paper%E2%80%93scissors#/media/File:Rock_Paper_Scissors_Lizard_Spock_en.svg)

#### Playing options

When the application starts, you will be prompted to select the type of players who will participate in the match

There are three types of player:
* Human Player: The moves are determined by a human using the keyboard, with the programme reading input from the console.

* Random Computer Player: The computer makes random moves

* Tactical Computer Player:
The tactical computer player should always select the choice that would have beaten its last choice, e.g. if it played Scissors in game 2, it should play Rock in game 3.
