

using System;
using System.Collections.Generic;

class RandomPlayer : Player
{
    //private fields
    private char piece;
    private Algorithm algorithm;

    private bool isComment = true;
    private bool isLog = false;
    private String fileName = "games.txt";

    public RandomPlayer(Algorithm lms, int playerType)
    {
        //set algoritmo
        this.algorithm = lms;

        this.piece = playerType == 1 ? 'X' : 'O';
    }

    public List<Board> getMoves(Board actual)
    {
        return base.getMoves(actual, piece);
    }

    //escolhe random
    public Board chooseMove(List<Board> moves)
    {
        int numberMoves = moves.Count;

        if (numberMoves == 0)
            return null;

        //queremos jogada aleatoria
        Random random = new Random(DateTime.Now.Millisecond);
        int index = random.Next(0, numberMoves);

        try
        {
            Game.comment(TicTacToe.isComment, "--RANDOM-- SELECIONOU\n");
            Game.comment(TicTacToe.isComment, moves[index].ToString());
            Game.comment(TicTacToe.isComment, algorithm.V(moves[index]).ToString());

            Game.writeToFile(TicTacToe.isLog, TicTacToe.fileName, "--RANDOM-- SELECIONOU\n");
            Game.writeToFile(TicTacToe.isLog, TicTacToe.fileName, moves[index].ToString());
            algorithm.printV(moves[index]);
            Game.writeToFile(TicTacToe.isLog, TicTacToe.fileName, "\n\n");
        }
        catch (Exception) { }

        return moves[index];
    }

    public override Board turnPlay(int turn, List<Board> history)
    {
        comment("TURNO " + turn);

        //ver movimentos
        List<Board> moves = getMoves(history[turn]);

        //escolher movimento
        Board bestBoard = chooseMove(moves);

        return bestBoard;
    }

    /*
    EXTRA
    */
    public void comment(string s)
    {
        base.comment(s);
    }

    public void writeToFile(string s)
    {
        base.writeToFile(s);
    }
}

