using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAxe : MonoBehaviour
{
    public GameObject PickUpText;
    public GameObject AxeOnPlayer;

    // Start is called before the first frame update
    void Start()
    {
        AxeOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                AxeOnPlayer.SetActive(true);
                PickUpText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PickUpText.SetActive(false);
    }

}
