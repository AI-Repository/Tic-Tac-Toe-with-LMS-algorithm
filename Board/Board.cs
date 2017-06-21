using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Board
{
    //tabuleiro
    private char[,] _board;

    //dimensoes tabuleiro
    private int yy = 3, xx = 3;

    //contrutor
    public Board()
    {
        //iniciar tabuleiro
        initBoard();
    }

    public Board(char[,] boardCopy)
    {
        _board = new char[yy, xx];
        for (int i = 0; i < yy; i++)
            for (int j = 0; j < xx; j++)
            {
                if (!boardCopy.Equals("-"))
                    this._board[i, j] = boardCopy[i, j];
                else
                    this._board[i, j] = '-';
            }
    }

    /*
    GETS
    */
    //obter tabuleiro
    public char[,] getBoard()
    {
        return this._board;
    }

    //obter peça na posiçao x
    public char getPiece(int yy, int xx)
    {
        return this._board[yy, xx];
    }

    //dimensoes tabuleiro
    public int getHeight()
    {
        return yy;
    }

    //dimensoes tabuleiro
    public int getWidth()
    {
        return xx;
    }

    /*
    SETS
    */
    //inicializar tabuleiro a vazio
    private void initBoard()
    {
        _board = new char[yy, xx];
        for (int i = 0; i < yy; i++)
            for (int j = 0; j < xx; j++)
                this._board[i, j] = '-';
    }

    //meter peça no tabuleiro
    public void setPiece(int yy, int xx, char piece)
    {
        this._board[yy, xx] = piece;
    }

    //copiamos peças para tabuleiro
    public void setBoard(char[,] pieces)
    {
        this._board = pieces;
    }

    //copiar tabuleiro
    public Board copy()
    {
        Board copy = new Board();
        copy.setBoard(this._board);
        return copy;
    }

    //imprimir tabuleiro
    public void print()
    {
        for (int i = 0; i < yy; i++)
        {
            for (int j = 0; j < xx; j++)
            {
                Console.Write(this._board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public override String ToString()
    {
        String result = "";
        for (int i = 0; i < yy; i++)
        {
            for (int j = 0; j < xx; j++)
            {
                result += this._board[i, j].ToString();
                result += " ";
            }
            result += "\n";
        }
        return result;
    }
}

