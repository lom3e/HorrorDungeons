using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpFlashlight : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject FlashLightOnPlayer;

    void Start()
    {
        FlashLightOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                PickUpText.SetActive(false);
                FlashLightOnPlayer.SetActive(true);

            }

        }

    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }

}
