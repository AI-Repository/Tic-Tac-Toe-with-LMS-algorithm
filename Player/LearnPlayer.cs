using System;
using System.Collections.Generic;


class LearnPlayer : Player
{
    //private fields
    private char piece;
    private Algorithm algorithm;

    public LearnPlayer(Algorithm lms, int playerType)
    {
        //set algoritmo
        this.algorithm = lms;

        piece = playerType == 1 ? 'X' : 'O';
    }

    public List<Board> getMoves(Board actual)
    {
        return base.getMoves(actual, piece);
    }

    //escolhe de forma a maximizar V(b)
    public Board chooseMove(List<Board> moves)
    {
        Board bestBoard = null;
        float bestBoardValue = float.MinValue, actualBoardValue = float.MinValue;

        //para desempate
        Random random = new Random(DateTime.Now.Millisecond);
        int tie = -1;

        comment("\nPOSSIVEIS MOVIMENTOS LEARNER\n");

        //percorrer todos movimentos
        foreach (Board board in moves)
        {

            comment(board.ToString());
            algorithm.printV(board);

            actualBoardValue = algorithm.V(board);

            comment("\n");

            //se for melhor, ficamos com ele como sucessor
            if (actualBoardValue > bestBoardValue)
            {
                bestBoardValue = actualBoardValue;
                bestBoard = board;
            }
            //se for igual, random 
            else if (actualBoardValue == bestBoardValue)
            {
                tie = random.Next(0, 2);
                if (tie == 0)
                {
                    bestBoardValue = actualBoardValue;
                    bestBoard = board;
                }
            }
        }

        try
        {
            comment("\n--LEARNER-- SELECIONOU\n");
            comment(bestBoard.ToString());
            algorithm.printV(bestBoard);
            comment("\n");
        }
        catch (Exception) { }

        return bestBoard;
    }

    public float computeError(float nextBoard, float actualBoard)
    {
        return base.computeError(nextBoard, actualBoard);
    }

    public void updateWeights(Board actual, float error)
    {
        //tabuleiro b2 e next
        //calcular error
        comment("\nactualizar pesos!!!!!!!!!!!!!!!!!!!!");
        base.updateWeights(algorithm, actual, error);
    }

    //nos turnos pares actualizo peso
    public override Board turnPlay(int turn, List<Board> history)
    {
        comment("TURNO " + turn);

        //actualizar pesos
        if (turn != 0)
        {
            //V(b') - V(b)
            float vb0 = algorithm.V(history[turn - 2]);
            float vb2;

            float error;
            if (algorithm.f5(history[turn]) > 0) //WIN
            {
                vb2 = 100;
                error = computeError(vb2, vb0);
                updateWeights(history[turn - 2], error);
                return null;
            }

            else if (algorithm.f6(history[turn]) > 0) //LOSS
            {
                vb2 = -100;
                error = computeError(vb2, vb0);
                updateWeights(history[turn - 2], error);
                return null;
            }

            else if (algorithm.f7(history[turn]) == 0) //DRAW
            {
                vb2 = 0;
                error = computeError(vb2, vb0);
                updateWeights(history[turn - 2], error);
                return null;
            }
            else
                vb2 = algorithm.V(history[turn]);

            comment("\nEste é um tabuleiro anterior \n" + history[turn - 2].ToString());
            algorithm.printV(history[turn - 2]);

            error = computeError(vb2, vb0);
            updateWeights(history[turn - 2], error);
        }

        //ver movimentos
        List<Board> moves = getMoves(history[turn]);

        //escolher movimento
        Board bestBoard = chooseMove(moves);

        if (algorithm.f5(bestBoard) > 0)
        {
            float vb0 = algorithm.V(history[turn - 0]);
            float vb2 = algorithm.V(bestBoard);
            float error = computeError(vb2, vb0);

            updateWeights(history[turn - 0], error);
            return null;
        }

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

