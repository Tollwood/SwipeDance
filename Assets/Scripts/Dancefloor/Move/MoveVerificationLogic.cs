using System.Linq;
using UnityEngine;

public class MoveVerificationLogic {

    private static float offSet = 0.5f;
	
    public static bool verifyMove(Line firstLine, Line secondLine, MoveTypes currentMove)
    {
        if (firstLine.GetPoints() == null || firstLine.GetPoints().Count <= 2)
        {
            return false;
        }
        Vector2 first = firstLine.GetPoints().First();
        Vector2 last = firstLine.GetPoints().Last();

        bool singleLineDrawn = secondLine == null || secondLine.GetPoints() == null || secondLine.GetPoints().Count <= 2;

        if(singleLineDrawn){
            switch (currentMove)
            {
                case MoveTypes.UP:
                    return IsUp(first, last);
                case MoveTypes.DOWN:
                    return IsDown(first, last);
                case MoveTypes.LEFT:
                    return IsLeft(first, last);
                case MoveTypes.RIGHT:
                    return IsRight(first, last);
            } 
        } else {
            switch (currentMove)
            {
                case MoveTypes.UP_UP:
                    return IsUp(first, last) && IsUp(secondLine.GetPoints().First(), secondLine.GetPoints().Last());
                case MoveTypes.DOWN_DOWN:
                    return IsDown(first, last) && IsDown(secondLine.GetPoints().First(), secondLine.GetPoints().Last());
                case MoveTypes.LEFT_LEFT:
                    return IsLeft(first, last) && IsLeft(secondLine.GetPoints().First(), secondLine.GetPoints().Last());
                case MoveTypes.RIGHT_RIGHT:
                    return IsRight(first, last) && IsRight(secondLine.GetPoints().First(), secondLine.GetPoints().Last());
                case MoveTypes.UP_DOWN:
                    return IsUp(first, last) && IsDown(secondLine.GetPoints().First(), secondLine.GetPoints().Last());
                case MoveTypes.DOWN_UP:
                    return IsDown(first, last) && IsUp(secondLine.GetPoints().First(), secondLine.GetPoints().Last());
                case MoveTypes.LEFT_RIGHT:
                    return IsLeft(first, last) && IsRight(secondLine.GetPoints().First(), secondLine.GetPoints().Last());
                case MoveTypes.RIGHT_LEFT:
                    return IsRight(first, last) && IsLeft(secondLine.GetPoints().First(), secondLine.GetPoints().Last());
            }
        }

        return false;

    }

    private static bool IsUp(Vector2 first, Vector2 last)
    {
        return first.y < last.y
                    && first.x + offSet >= last.x
                    && first.x - offSet <= last.x;
    }

    private static bool IsDown(Vector2 first, Vector2 last)
    {
        return first.y > last.y
                    && first.x + offSet >= last.x
                    && first.x - offSet <= last.x;
    }

    private static bool IsLeft(Vector2 first, Vector2 last)
    {
        return first.x > last.x
                    && first.y + offSet >= last.y
                    && first.y - offSet <= last.y;
    }

    private static bool IsRight(Vector2 first, Vector2 last)
    {
        return first.x < last.x
                    && first.y + offSet >= last.y
                    && first.y - offSet <= last.y;
    }
}
