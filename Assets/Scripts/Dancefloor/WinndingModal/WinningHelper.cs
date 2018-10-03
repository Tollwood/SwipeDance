public class WinningHelper {
    public static  string getRating(int maxScore, int score)
    {
        string rating = "";
        float percentage = 100f / maxScore * score;
        if (percentage > 95)
        {
            rating = "Master";
        }
        else if (percentage <= 95 && percentage > 70)
        {
            rating = "Professional";
        }
        else if (percentage <= 70 && percentage > 50)
        {
            rating = "Hobbiest";
        }
        else if (percentage <= 50 && percentage > 30)
        {
            rating = "Novice";
        }
        else if (percentage <= 30)
        {
            rating = "Untrained";
        }
        return rating;
    }

   
}