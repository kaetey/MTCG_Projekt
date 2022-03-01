using System;
using MTCG_GamePlay;

namespace MTCG_Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            MTCG_GamePlay.GamePlay gm = new MTCG_GamePlay.GamePlay();
            gm.Battle();
        }
    }
}
