# Tic-Tac-Toe-LMS-rule

<h3>Teaching a Computer to Play TicTacToe using <bold>LMS</bold></h3>

## Training rules:
* V(b) = true target function. Actual board
* V'(b) = learned target function. Selected board
* alfa = 0.1

## LMS weight update rule:
* Select a training example b;
* Compute the error(b) = V(b) - V'(b)
* update weights w_i = w_i + alfa * V(b) * error(b)

## Target Function: 

V(b) = w_0 + w_1 * x1 + w_2 * x2 + w_3 * x3 + w_4 * x4 + w_5 * x5 + w_6 * x6;


## Metrics used:

* x1 = # of instances where there are 2 x's in a row with an open subsequent square.
* x2 = # of instances where there are 2 o's in a row with an open subsequent square.
* x3 = # of instances where there is an x in a completely open row.
* x4 = # of instances where there is an o in a completely open row.
* x5 = # of instances of 3 x's in a row (value of 1 signifies end game)
* x6 = # of instances of 3 o's in a row (value of 1 signifies end game)

credits: http://www.christopia.net/blog/teaching-a-computer-to-play-tictactoe
