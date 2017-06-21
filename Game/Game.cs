using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//que tipo de jogo (ate ao fim) ???????
//aprendizagem
//minmax
//normal
//jogar com Human
class Game
{
    //private fields
    private List<Board> history = new List<Board>();
    private Board nextBoard;

    private LearnPlayer learner;
    private RandomPlayer randomerPlayer;

    private Algorithm algorithm;

    private int roundNumber = 0;

    public Game(LearnPlayer learner, RandomPlayer randomerPlayer, Algorithm algorithm)
    {
        //inicializar
        this.algorithm = algorithm;
        this.learner = learner;
        this.randomerPlayer = randomerPlayer;
    }

    /*
    APRENDIZAGEM
    */
    public void normalLearning(int times)
    {
        for (int i = 0; i < times; i++)
        {
            if (roundNumber == 0)
            {
                //tabuleiro inicial jogo
                history.Add(new Board());
                nextBoard = history[0];
            }

            while (nextBoard != null)
            {
                nextBoard = learner.turnPlay(roundNumber++, history);
                if (nextBoard == null)
                    break;
                history.Add(nextBoard);

                nextBoard = randomerPlayer.turnPlay(roundNumber++, history);
                if (nextBoard == null)
                    break;
                history.Add(nextBoard);
            }
            roundNumber = 0;
            history.Clear();

            if (i % 100 == 0)
                Console.WriteLine(i);
        }

        //escrever pesos no file
        writeToFile(TicTacToe.isLogWeights, TicTacToe.weights, algorithm.getW0().ToString());
        writeToFile(TicTacToe.isLogWeights, TicTacToe.weights, algorithm.getW1().ToString());
        writeToFile(TicTacToe.isLogWeights, TicTacToe.weights, algorithm.getW2().ToString());
        writeToFile(TicTacToe.isLogWeights, TicTacToe.weights, algorithm.getW3().ToString());
        writeToFile(TicTacToe.isLogWeights, TicTacToe.weights, algorithm.getW4().ToString());
        writeToFile(TicTacToe.isLogWeights, TicTacToe.weights, algorithm.getW5().ToString());
        writeToFile(TicTacToe.isLogWeights, TicTacToe.weights, algorithm.getW6().ToString());
    }

    //TODO
    public void minmaxLearning(int times)
    {
        throw new NotImplementedException();
    }

    /*
    HUMAN
    */
    public void vsHuman()
    {
        //ler pesos
        readWeights();

        Board board = new Board();

        while (true)
        {
            //cpu
            List<Board> moves = learner.getMoves(board);
            board = learner.chooseMove(moves);

            Console.WriteLine("\n CPU PLAYED: \n");

            board.print();

            if (algorithm.f5(board) > 0)
            {
                Console.WriteLine("\n YOU LOSE \n");
                break;
            }
            else if (algorithm.f7(board) == 0)
            {
                Console.WriteLine("\n DRAW\n");
                break;
            }


            Console.WriteLine("\n\n");

            //humano
            board = interact(board, 'O');
            Console.WriteLine("");

            Console.WriteLine("\n YOU PLAYED: \n");

            board.print();
            Console.WriteLine("\n\n");

            if (algorithm.f6(board) > 0)
            {
                Console.WriteLine("\n YOU WIN \n");
                break;
            }
            else if (algorithm.f7(board) == 0)
            {
                Console.WriteLine("\n DRAW\n");
                break;
            }
        }        
    }

    public void Statistic(int rounds)
    {
        //ler pesos
        readWeights();

        Board board = new Board();
        int win = 0, draw = 0, loss = 0;

        for (int i = 0; i < rounds; i++)
        {
            float result = auxStatistic();

            if (result == 1)
                win++;
            else if (result == 0)
                draw++;
            else if (result == -1)
                loss++;
        }

        Console.WriteLine("Learner % Vic " + win/(float) rounds);
        Console.WriteLine("Draw % " + draw / (float)rounds);
        Console.WriteLine("Random % Vic " + loss / (float)rounds);
    }

    private int auxStatistic()
    {
        Board board = new Board();

        while (true)
        {
            List<Board> moves = learner.getMoves(board);
            board = learner.chooseMove(moves);

            if (algorithm.f5(board) > 0)
            {
                return 1;
            }
            else if (algorithm.f7(board) == 0)
            {
                return 0;
            }

            moves = randomerPlayer.getMoves(board);
            board = randomerPlayer.chooseMove(moves);

            if (algorithm.f6(board) > 0)
            {
                return -1;
            }
            else if (algorithm.f7(board) == 0)
            {
                return 0;
            }
        }
    }

    //console
    private static Board interact(Board actual, char piece)
    {
        Board next = new Board(actual.getBoard());
        var input = Console.ReadKey();

        switch (input.KeyChar)
        {
            case '1':
                next.setPiece(2, 0, piece);
                break;
            case '2':
                next.setPiece(2, 1, piece);
                break;
            case '3':
                next.setPiece(2, 2, piece);
                break;
            case '4':
                next.setPiece(1, 0, piece);
                break;
            case '5':
                next.setPiece(1, 1, piece);
                break;
            case '6':
                next.setPiece(1, 2, piece);
                break;
            case '7':
                next.setPiece(0, 0, piece);
                break;
            case '8':
                next.setPiece(0, 1, piece);
                break;
            case '9':
                next.setPiece(0, 2, piece);
                break;
            default:
                break;
        }
        return next;
    }

    /*
    EXTRA
    */
    public static void comment(Boolean enableComment, String s)
    {
        if (enableComment)
            Console.WriteLine(s);
    }

    public static void writeToFile(Boolean enableWrite, String fileName, String text)
    {
        if (enableWrite)
        {
            using (StreamWriter writer =
                new StreamWriter(fileName, true))
            {
                writer.WriteLine(text);
            }
        }
    }

    private void readWeights()
    {
        List<float> pesos = new List<float>();
        string line;

        // Read the file and display it line by line.
        System.IO.StreamReader file = new System.IO.StreamReader(TicTacToe.weights);

        while ((line = file.ReadLine()) != null)
        {
            pesos.Add(float.Parse(line));
        }
        file.Close();

        //set pesos
        algorithm.setW0(pesos[0]);
        algorithm.setW1(pesos[1]);
        algorithm.setW2(pesos[2]);
        algorithm.setW3(pesos[3]);
        algorithm.setW4(pesos[4]);
        algorithm.setW5(pesos[5]);
        algorithm.setW6(pesos[6]);
    }
}

