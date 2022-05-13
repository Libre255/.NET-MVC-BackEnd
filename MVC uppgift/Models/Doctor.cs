namespace MVC_uppgift.Models
{
    public class Doctor
    {
        static public string HasFever(int temperature)
        {
            if (temperature >= 38)
                return "You have fever!";
            else
                return "You dont have fever";
        }
    }
}
