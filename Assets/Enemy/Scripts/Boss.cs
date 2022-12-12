using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject key;
    //spawn key at given transform with given unlock position
    public void SpawnKey(Transform trans, int unlockPos) {
        GameObject placedKey = Instantiate(key, trans.position, trans.rotation);
        placedKey.GetComponent<AbilityUnlock>().unlockPos = unlockPos;
    }
}
