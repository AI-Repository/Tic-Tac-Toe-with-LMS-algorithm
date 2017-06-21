using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class LMS : Algorithm
{
    //pesos
    private float _w0 = 0.5f, _w1 = 0.5f, _w2 = 0.5f, _w3 = 0.5f, _w4 = 0.5f, _w5 = 0.5f, _w6 = 0.5f;
    private float _alfa = 0.1f;

    /*
    CONSTRUTOR
    */
    public LMS() { }

    public LMS(float w0, float w1, float w2, float w3, float w4, float w5, float w6, float alfa)
    {
        this._w0 = w0;
        this._w1 = w1;
        this._w2 = w2;
        this._w3 = w3;
        this._w4 = w4;
        this._w5 = w5;
        this._w6 = w6;
        this._alfa = alfa;
    }

    /*
    PESOS
    */
    public float getW0()
    {
        return _w0;
    }

    public float getW1()
    {
        return _w1;
    }

    public float getW2()
    {
        return _w2;
    }

    public float getW3()
    {
        return _w3;
    }

    public float getW4()
    {
        return _w4;
    }

    public float getW5()
    {
        return _w5;
    }

    public float getW6()
    {
        return _w6;
    }

    public void setW0(float new_weight)
    {
        _w0 = new_weight;
    }

    public void setW1(float new_weight)
    {
        _w1 = new_weight;
    }

    public void setW2(float new_weight)
    {
        _w2 = new_weight;
    }

    public void setW3(float new_weight)
    {
        _w3 = new_weight;
    }

    public void setW4(float new_weight)
    {
        _w4 = new_weight;
    }

    public void setW5(float new_weight)
    {
        _w5 = new_weight;
    }

    public void setW6(float new_weight)
    {
        _w6 = new_weight;
    }

    /*
    ALFA
    */
    public float getAlfa()
    {
        return _alfa;
    }

    public void setAlfta(float new_alfa)
    {
        _alfa = new_alfa;
    }

    /*
    FUNCAO AVALIACAO
    */
    public float V(Board board)
    {
        float result = _w0 + _w1 * f1(board) + _w2 * f2(board) + _w3 * f3(board) + _w4 * f4(board) + _w5 * f5(board) +
                       _w6 * f6(board);
        return result;
    }

    public void printV(Board board)
    {
        float result = _w0 + _w1 * f1(board) + _w2 * f2(board) + _w3 * f3(board) + _w4 * f4(board) + _w5 * f5(board) +
                       _w6 * f6(board);

        Game.comment(TicTacToe.isComment, "v: " + _w0 + " + " + _w1 + " *  " + f1(board) + " + " + _w2 + " *  " + f2(board) + " + " + _w3 + " *  " + f3(board) +
    " + " + _w4 + " *  " + f4(board) + " + " + _w5 + " *  " + f5(board) + " + " + _w6 + " *  " + f6(board) + " = " + result);

        Game.writeToFile(TicTacToe.isLog, TicTacToe.fileName,
            "v: " + _w0 + " + " + _w1 + " *  " + f1(board) + " + " + _w2 + " *  " + f2(board) + " + " + _w3 + " *  " +
            f3(board) +
            " + " + _w4 + " *  " + f4(board) + " + " + _w5 + " *  " + f5(board) + " + " + _w6 + " *  " + f6(board) +
            " = " + result);
    }

    /*
    FEATURES
    */
    public int f0(Board board)
    {
        return 1;
    }

    //# of instances where there are 2 x's in a row with an open subsequent square.
    public int f1(Board board)
    {
        int result = 0;
        char piece = 'X';

        //LINHAS
        result += LinePieces(board, 0, piece, 2, 1);
        result += LinePieces(board, 1, piece, 2, 1);
        result += LinePieces(board, 2, piece, 2, 1);

        //COLUNAS
        result += CollumnPieces(board, 0, piece, 2, 1);
        result += CollumnPieces(board, 1, piece, 2, 1);
        result += CollumnPieces(board, 2, piece, 2, 1);

        //DIAGONAL
        result += DiagonalPieces1(board, piece, 2, 1);
        result += DiagonalPieces2(board, piece, 2, 1);

        return result;
    }

    //# of instances where there are 2 x's in a row with an open subsequent square.
    public int f2(Board board)
    {
        int result = 0;
        char piece = 'O';

        //LINHAS
        result += LinePieces(board, 0, piece, 2, 1);
        result += LinePieces(board, 1, piece, 2, 1);
        result += LinePieces(board, 2, piece, 2, 1);

        //COLUNAS
        result += CollumnPieces(board, 0, piece, 2, 1);
        result += CollumnPieces(board, 1, piece, 2, 1);
        result += CollumnPieces(board, 2, piece, 2, 1);

        //DIAGONAL
        result += DiagonalPieces1(board, piece, 2, 1);
        result += DiagonalPieces2(board, piece, 2, 1);

        return result;
        //diagonal
    }

    //# of instances where there is an x in a completely open row
    public int f3(Board board)
    {
        int result = 0;
        char piece = 'X';

        //LINHAS
        result += LinePieces(board, 0, piece, 1, 2);
        result += LinePieces(board, 1, piece, 1, 2);
        result += LinePieces(board, 2, piece, 1, 2);

        //COLUNAS
        result += CollumnPieces(board, 0, piece, 1, 2);
        result += CollumnPieces(board, 1, piece, 1, 2);
        result += CollumnPieces(board, 2, piece, 1, 2);

        //DIAGONAL
        result += DiagonalPieces1(board, piece, 1, 2);
        result += DiagonalPieces2(board, piece, 1, 2);

        return result;
    }

    //# of instances where there is an o in a completely open row
    public int f4(Board board)
    {
        int result = 0;
        char piece = 'O';

        //LINHAS
        result += LinePieces(board, 0, piece, 1, 2);
        result += LinePieces(board, 1, piece, 1, 2);
        result += LinePieces(board, 2, piece, 1, 2);

        //COLUNAS
        result += CollumnPieces(board, 0, piece, 1, 2);
        result += CollumnPieces(board, 1, piece, 1, 2);
        result += CollumnPieces(board, 2, piece, 1, 2);

        //DIAGONAL
        result += DiagonalPieces1(board, piece, 1, 2);
        result += DiagonalPieces2(board, piece, 1, 2);

        return result;
    }

    //# of instances of 3 x's in a row
    public int f5(Board board)
    {
        int result = 0;
        char piece = 'X';

        //LINHAS
        result += LinePieces(board, 0, piece, 3, 0);
        result += LinePieces(board, 1, piece, 3, 0);
        result += LinePieces(board, 2, piece, 3, 0);

        //COLUNAS
        result += CollumnPieces(board, 0, piece, 3, 0);
        result += CollumnPieces(board, 1, piece, 3, 0);
        result += CollumnPieces(board, 2, piece, 3, 0);

        //DIAGONAL
        result += DiagonalPieces1(board, piece, 3, 0);
        result += DiagonalPieces2(board, piece, 3, 0);

        return result;
    }

    //# of instances of 3 O's in a row
    public int f6(Board board)
    {
        int result = 0;
        char piece = 'O';

        //LINHAS
        result += LinePieces(board, 0, piece, 3, 0);
        result += LinePieces(board, 1, piece, 3, 0);
        result += LinePieces(board, 2, piece, 3, 0);

        //COLUNAS
        result += CollumnPieces(board, 0, piece, 3, 0);
        result += CollumnPieces(board, 1, piece, 3, 0);
        result += CollumnPieces(board, 2, piece, 3, 0);

        //DIAGONAL
        result += DiagonalPieces1(board, piece, 3, 0);
        result += DiagonalPieces2(board, piece, 3, 0);

        return result;
    }

    //# free spots
    public int f7(Board board)
    {
        int result = 0;
        char piece = '-';

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board.getPiece(i, j).Equals(piece))
                    result++;
            }
        }

        return result;
    }

    //error
    public float error(float nextBoard, float actualBoard)
    {
        return nextBoard - actualBoard;
    }

    //pesos
    public void updateWeights(float error, Board actual)
    {
        float alfa = getAlfa();
        float newW0 = getW0() + alfa * f0(actual) * error;
        float newW1 = getW1() + alfa * f1(actual) * error;
        float newW2 = getW2() + alfa * f2(actual) * error;
        float newW3 = getW3() + alfa * f3(actual) * error;
        float newW4 = getW4() + alfa * f4(actual) * error;
        float newW5 = getW5() + alfa * f5(actual) * error;
        float newW6 = getW6() + alfa * f6(actual) * error;

        Game.comment(TicTacToe.isComment, "NovosPesos:\nw0 = " + getW0() + " + " + alfa + " * " + f0(actual) + " * " + error + " = " + newW0);
        Game.comment(TicTacToe.isComment, "w1 = " + getW1() + " + " + alfa + " * " + f1(actual) + " * " + error + " = " + newW1);
        Game.comment(TicTacToe.isComment, "w2 = " + getW2() + " + " + alfa + " * " + f2(actual) + " * " + error + " = " + newW2);
        Game.comment(TicTacToe.isComment, "w3 = " + getW3() + " + " + alfa + " * " + f3(actual) + " * " + error + " = " + newW3);
        Game.comment(TicTacToe.isComment, "w4 = " + getW4() + " + " + alfa + " * " + f4(actual) + " * " + error + " = " + newW4);
        Game.comment(TicTacToe.isComment, "w5 = " + getW5() + " + " + alfa + " * " + f5(actual) + " * " + error + " = " + newW5);
        Game.comment(TicTacToe.isComment, "w6 = " + getW5() + " + " + alfa + " * " + f6(actual) + " * " + error + " = " + newW6 + "\n\n");

        Game.writeToFile(TicTacToe.isLog, TicTacToe.fileName, "NovosPesos:\nw0 = " + getW0() + " + " + alfa + " * " + f0(actual) + " * " + error + " = " + newW0);
        Game.writeToFile(TicTacToe.isLog, TicTacToe.fileName, "w1 = " + getW1() + " + " + alfa + " * " + f1(actual) + " * " + error + " = " + newW1);
        Game.writeToFile(TicTacToe.isLog, TicTacToe.fileName, "w2 = " + getW2() + " + " + alfa + " * " + f2(actual) + " * " + error + " = " + newW2);
        Game.writeToFile(TicTacToe.isLog, TicTacToe.fileName, "w3 = " + getW3() + " + " + alfa + " * " + f3(actual) + " * " + error + " = " + newW3);
        Game.writeToFile(TicTacToe.isLog, TicTacToe.fileName, "w4 = " + getW4() + " + " + alfa + " * " + f4(actual) + " * " + error + " = " + newW4);
        Game.writeToFile(TicTacToe.isLog, TicTacToe.fileName, "w5 = " + getW5() + " + " + alfa + " * " + f5(actual) + " * " + error + " = " + newW5);
        Game.writeToFile(TicTacToe.isLog, TicTacToe.fileName, "w6 = " + getW5() + " + " + alfa + " * " + f6(actual) + " * " + error + " = " + newW6 + "\n\n");

        setW0(newW0);
        setW1(newW1);
        setW2(newW2);
        setW3(newW3);
        setW4(newW4);
        setW5(newW5);
        setW6(newW6);
    }

    /*
    AUXILIARES FEATURES
    */
    //ve se temos 2 peças na linha
    private int LinePieces(Board board, int line, char piece, int numberX, int numberEmpty)
    {
        int countXX = 0, countEmpty = 0;
        for (int i = 0; i < 3; i++)
        {
            if (board.getPiece(line, i).Equals(piece))
                countXX += 1;
            if (board.getPiece(line, i).Equals('-'))
                countEmpty += 1;
        }

        if (countXX == numberX && countEmpty == numberEmpty)
            return 1;
        else
            return 0;
    }

    //ve se temos 2 peças na coluna
    private int CollumnPieces(Board board, int columm, char piece, int numberX, int numberEmpty)
    {
        int countXX = 0, countEmpty = 0;
        for (int i = 0; i < 3; i++)
        {
            if (board.getPiece(i, columm).Equals(piece))
                countXX += 1;
            if (board.getPiece(i, columm).Equals('-'))
                countEmpty += 1;
        }

        if (countXX == numberX && countEmpty == numberEmpty)
            return 1;
        else
            return 0;
    }

    //ve se temos 2 peças na diagonal
    private int DiagonalPieces1(Board _board, char piece, int numberX, int numberEmpty)
    {
        int countXX = 0, countEmpty = 0;
        for (int i = 0; i < 3; i++)
        {
            if (_board.getPiece(i, i).Equals(piece))
                countXX += 1;
            if (_board.getPiece(i, i).Equals('-'))
                countEmpty += 1;
        }

        if (countXX == numberX && countEmpty == numberEmpty)
            return 1;
        else
            return 0;
    }

    //ve se temos 2 peças na diagonal
    private int DiagonalPieces2(Board board, char piece, int numberX, int numberEmpty)
    {
        int countXX = 0, countEmpty = 0;
        int auxIndex = 0;
        for (int i = 2; i >= 0; i--)
        {
            if (board.getPiece(i, auxIndex).Equals(piece))
                countXX += 1;
            if (board.getPiece(i, auxIndex++).Equals('-'))
                countEmpty += 1;
        }

        if (countXX == numberX && countEmpty == numberEmpty)
            return 1;
        else
            return 0;
    }

}

