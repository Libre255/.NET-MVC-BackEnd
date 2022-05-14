namespace MVC_uppgift.Models
{
    public class Game
    {
        public static string GuessTheNumber(int UserGuess, int SecretNumber)
        {
            if(UserGuess != SecretNumber)
            {
                if (UserGuess > SecretNumber)
                {
                    return "You guessed to high";
                }
                else if (UserGuess < SecretNumber)
                {
                    return "You guessed to low";
                }else
                {
                    return "Aok";
                }
            }else
            {
                return "Congratulations you found the secret number!";
            }
        }
    }
}
