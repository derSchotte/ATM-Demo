namespace ATM.Klassen {
    internal class CardHolder {
        public int CardNum { get; private set; }
        public int Pin { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public double Balance { get; set; }

        public CardHolder( int cardNum, int pin, string firstName, string lastName, double balance ) {
            CardNum = cardNum;
            Pin = pin;
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }
    }
}
