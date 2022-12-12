using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WinOrLose
{
    public static bool win = false;

    //set whether win condition was met or not
    public static void EndCondition(bool input) {
        win = input;
    }
}
