using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocks : MonoBehaviour {
    [SerializeField] private int numUnlocks = 5;

    /* Unlock list
        1. Fireball
        2. 
        3. 
        4. 
        5. Door 1
     */

    public ArrayList unlocks;
    public ArrayList Unlock
    {
        get { return unlocks; }
    }

    private void Start()
    {
        unlocks = new ArrayList();
        for (int i = 0; i < numUnlocks; i++)
        {
            unlocks.Add(false);
        }
    }
}
