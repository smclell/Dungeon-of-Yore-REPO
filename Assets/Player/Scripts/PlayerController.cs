using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeedX;
    [SerializeField] private float playerSpeedY;
    [SerializeField] public GameObject playerMeleeAttack;

    // Update is called once per frame
    void Update()
    {
        #region Movement

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(playerSpeedX * inputX, playerSpeedY * inputY, 0);

        movement *= Time.deltaTime;

        transform.Translate(movement);
        transform.rotation = Quaternion.identity;

        #endregion

        #region Attack

        if (Input.GetButtonDown("Fire1") && !playerMeleeAttack.activeSelf)
        {
            Vector3 positionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            positionMouse.z = transform.position.z;

            Vector3 towardsMouseFromPlayer = positionMouse - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(positionMouse);

            targetRotation.x = 0;
            targetRotation.y = 0;

            Vector3 vectorAttack = ((Quaternion.AngleAxis(targetRotation.z, Vector3.forward) * gameObject.transform.rotation) * Vector3.left * 2) + transform.position;

            playerMeleeAttack.transform.position = vectorAttack;
            playerMeleeAttack.SetActive(true);
        }
        #endregion
    }
}
