using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

abstract class Player
{
    //retorna movimentos tabuleiro
    public List<Board> getMoves(Board actual, char piece)
    {
        List<Board> moves = new List<Board>();

        for (int i = 0; i < actual.getHeight(); i++)
        {
            for (int j = 0; j < actual.getWidth(); j++)
            {
                if (actual.getPiece(i, j).Equals('-'))
                {
                    //copiamos referencia
                    Board copy = new Board(actual.getBoard());

                    //metemos possivel movimento no tabuleiro
                    copy.setPiece(i, j, piece);

                    //juntamos aos sucessores
                    moves.Add(copy);
                }
            }
        }
        return moves;
    }

    //retorna movimento random
    public Board chooseMove(List<Board> moves)
    {
        return null;
    }

    //calcular error
    public float computeError(float nextBoard, float actualBoard)
    {
        return nextBoard - actualBoard;
    }

    //actualizar pesos
    public void updateWeights(Algorithm algorithm, Board actual, float error)
    {
        algorithm.updateWeights(error, actual);
    }

    //turno jogo
    public abstract Board turnPlay(int turn, List<Board> history);

    //COMENTARIOS
    public void comment(string s)
    {
        Game.comment(TicTacToe.isComment, s);
        Game.writeToFile(TicTacToe.isLog, TicTacToe.fileName, s);
    }

    public void writeToFile(string s)
    {
        Game.writeToFile(TicTacToe.isLog, TicTacToe.fileName, s);
    }
}

