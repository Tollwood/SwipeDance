using System;

public class MoveTypeHelper
    {
    public static string MoveTypeToString(MoveTypes moveType, bool isLeftMove)
    {
        switch (moveType)
        {
            case MoveTypes.UP:
                return isLeftMove ? "UP" : "";
            case MoveTypes.UP_UP:
                return "UP";
            case MoveTypes.UP_DOWN:
                return isLeftMove ? "UP" : "DOWN";
            case MoveTypes.DOWN_UP:
                return isLeftMove ? "DOWN" : "UP";
            case MoveTypes.DOWN:
                return isLeftMove ? "DOWN" : "";
            case MoveTypes.DOWN_DOWN:
                return "DOWN";
            case MoveTypes.LEFT:
                return isLeftMove ? "LEFT" : "";
            case MoveTypes.LEFT_LEFT:
                return "LEFT";
            case MoveTypes.RIGHT:
                return isLeftMove ? "RIGHT" : "";
            case MoveTypes.RIGHT_RIGHT:
                return "Right";
            case MoveTypes.LEFT_RIGHT:
                return isLeftMove ? "LEFT" : "RIGHT";
            case MoveTypes.RIGHT_LEFT:
                return isLeftMove ? "RIGHT" : "LEFT";
        }
        return "";
    }

    public static MoveTypes randomMove(MoveTypes exlude, int difficulty){
        
        MoveTypes nextMoveValue = exlude;
        while (exlude == nextMoveValue) {
            Array values = Enum.GetValues(typeof(MoveTypes));
            System.Random random = new System.Random();
            int maxValue = difficulty > 0 ? values.Length : 4; 
            nextMoveValue =  (MoveTypes)values.GetValue(random.Next(maxValue));
        }
        return nextMoveValue;
    }
}