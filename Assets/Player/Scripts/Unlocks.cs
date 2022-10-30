using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocks : MonoBehaviour
{
    [SerializeField] private int numUnlocks = 5;

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
