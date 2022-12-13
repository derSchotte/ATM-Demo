using ATM.Klassen;
using System.Diagnostics;

namespace ATM {
    internal class Menu {
        static CardHolder cardHolder;

        static List<CardHolder> cardHolders = new() {
            new CardHolder(01255894, 5467,"John","Jones",54.03),
            new CardHolder(04587995, 5643,"Alexa","Martines",153.24),
            new CardHolder(04531678, 1151,"Georg","Griffith",5000),
            new CardHolder(01156498, 5324,"Ashley","Harding",364.12),
            new CardHolder(01156498, 5324,"Melanie","Meyer",11200564.02)
        };

        static void MenuOptions() {
            Console.WriteLine( "Please choose from one of the following options..." );
            Console.WriteLine( "1. Deposit" );
            Console.WriteLine( "2. Withdraw" );
            Console.WriteLine( "3. Show Balance" );
            Console.WriteLine( "4. Exit" );
        }

        static void Deposit( CardHolder cardHolder ) {
            Console.WriteLine( "How much $$ would you like to deposit?" );
            double deposit = Double.Parse(Console.ReadLine() );
            cardHolder.Balance = deposit + cardHolder.Balance;
            Console.WriteLine( $"Thank you for your $$. Your new balance is: {cardHolder.Balance}" );
        }

        static void Withdraw( CardHolder cardHolder ) {
            Console.WriteLine( "How much $$ would you like to withdraw?" );
            double withdrawal = Double.Parse(Console.ReadLine() );

            if( cardHolder.Balance < withdrawal ) {
                Console.WriteLine( "Sorry, Insufficient balance ;(" );
            } else {
                cardHolder.Balance = cardHolder.Balance - withdrawal;
                Console.WriteLine( "You're good to go! Thank you" );
            }
        }

        static void ShowBalance( CardHolder cardHolder ) {
            Console.WriteLine( $"Current balance: {cardHolder.Balance}" );
        }

        public static CardHolder PromptUser() {
            Console.WriteLine( "Welcome to SimpleATM" );
            Console.WriteLine( "Please insert your debit card" );
            int debitCardNum;
            bool check = false;

            do {
                check = int.TryParse( Console.ReadLine(), out debitCardNum );
                cardHolder = cardHolders.FirstOrDefault( a => a.CardNum == debitCardNum );

                if( !check ) {
                    Console.WriteLine( "You entered the wrong number, or no numbers at all" );
                }
            } while( !check );

            return cardHolder;
        }

        public static void UserPin( CardHolder cardHolder ) {
            Console.WriteLine( "Please enter your pin!" );
            int userPin = 0;
            bool check = false;

            do {
                check = int.TryParse( Console.ReadLine(), out userPin );

                if( !check ) {
                    Console.WriteLine( "Incorrect pin. Please try again!" );
                }

                if( cardHolder.Pin == userPin ) { break; }
            } while( !check );

            RunATM();
        }

        static void RunATM() {
            int option = 0;
            bool check;

            Console.WriteLine( $"Welcome {cardHolder.FirstName}" );

            do {
                MenuOptions();
                check = int.TryParse( Console.ReadLine(), out option );

                if( !check ) {
                    Console.WriteLine( "This is not an option!" );
                }

                switch( option ) {
                    case 1:
                    Deposit( cardHolder );
                    break;
                    case 2:
                    Withdraw( cardHolder );
                    break;
                    case 3:
                    ShowBalance( cardHolder );
                    break;
                    case 4:
                    break;
                    default:
                    option = 0;
                    break;
                }

            } while( option != 4 );

            Console.WriteLine( "Thank you! Have a nice day" );
        }
    }
}
