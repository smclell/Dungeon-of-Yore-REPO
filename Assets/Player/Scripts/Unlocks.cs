using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocks : MonoBehaviour {
    [SerializeField] private int numUnlocks = 5;

    /* Unlock list
        1. Fireball
        2. Ground Slam
        3. 
        4. 
        5. Door 1
        6. Door 2
        7. Door 3
        8. Door 4
        9. Door 5
        10. Door 6
        11. Door Final
     */

    public ArrayList unlocks; // list of unlocks
    public ArrayList Unlock
    {
        get { return unlocks; }
    }

    private void Start()
    {
        //set defaults for unlocks
        unlocks = new ArrayList();
        for (int i = 0; i < numUnlocks; i++)
        {
            unlocks.Add(false);
        }
    }
}
