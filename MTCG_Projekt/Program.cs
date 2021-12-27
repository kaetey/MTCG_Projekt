using System;
using Business;

namespace MTCG_Projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Business.GamePlay gm = new Business.GamePlay();
            gm.Battle();
        }
    }
}
