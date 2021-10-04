using System;

namespace Business
{
    interface IPackage
    {
        void buyPackage(); //zugriffsmethode überdenken
    }

    public class User : IPackage
    {
        private string name;
        private string password;
        private int coins;


        public string Name { get { return name; } set { } }
        public string Password { get { return password; } set { } }
        public int Coins { get { return coins; } set { } }

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
