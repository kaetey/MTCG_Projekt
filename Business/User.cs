using System;

namespace MTCG_GamePlay
{
    class User : IPackage
    {
        private string name { get; set; }
        private string password { get; set; }
        private int coins { get; set; }

        public User(){}

        public User(string name, string password, int coins)
        {
            this.name = name;
            this.password = password;
            this.coins = coins;
        }

        void IPackage.buyPackage()
        {

        }
    }
}
