using System;

/*
JOGADOR 1 - X
JOGADOR 2 - O
*/
class TicTacToe
{
    //COMENTARIOS
    public static bool isComment = false;
    public static bool isLog = false;
    public static bool isLogWeights = true;
    public static String fileName = "history.txt";
    public static String weights = "weights.txt";

    static void Main()
    {
        //pesos iguais 0.5
        Algorithm algorithm = new LMS();

        int playerID1 = 1, playerID2 = 2;

        //set algoritmo e tipo jogador
        LearnPlayer learner = new LearnPlayer(algorithm, playerID1);
        RandomPlayer randomer = new RandomPlayer(algorithm, playerID2);

        Game game = new Game(learner, randomer, algorithm);
        //game.normalLearning(1000);  //# of iterations
        game.vsHuman();
        //game.Statistic(500);
    }
}

