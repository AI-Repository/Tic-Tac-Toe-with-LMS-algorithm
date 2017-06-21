using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

interface Algorithm
{
    //gets pesos
    float getW0();
    float getW1();
    float getW2();
    float getW3();
    float getW4();
    float getW5();
    float getW6();

    //sets pesos
    void setW0(float new_weight);
    void setW1(float new_weight);
    void setW2(float new_weight);
    void setW3(float new_weight);
    void setW4(float new_weight);
    void setW5(float new_weight);
    void setW6(float new_weight);

    //get alfa
    float getAlfa();

    //set alfa
    void setAlfta(float new_alfa);

    //funcao avaliacao
    float V(Board board);
    void printV(Board board);

    //FEATURES
    int f0(Board board);
    int f1(Board board);
    int f2(Board board);
    int f3(Board board);
    int f4(Board board);
    int f5(Board board);
    int f6(Board board);
    int f7(Board board);

    //erro
    float error(float nextBoard, float actualBoard);

    //pesos
    void updateWeights(float error, Board actual);
}

