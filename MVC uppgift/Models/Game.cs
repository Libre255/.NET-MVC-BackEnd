namespace MVC_uppgift.Models
{
    public class Game
    {
        public static bool foundTheNr = false;
        public static string GuessTheNumber(int UserGuess, int SecretNumber)
        {
            if(UserGuess != SecretNumber)
            {
                foundTheNr = false;
                if (UserGuess > SecretNumber)
                {
                    return "You guessed to high";
                }
                else if (UserGuess < SecretNumber)
                {
                    return "You guessed to low";
                }else
                {
                    return "";
                }
            }else
            {
                foundTheNr = true;
                return "Congratulations you found the secret number!";
            }
        }
    }
}
