using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObjects : MonoBehaviour
{
    public GameObject FlashLight;
    public GameObject FlashLightOnPlayer;
    public GameObject Axe;
    public GameObject AxeOnPlayer;
    public Transform playerTransform;

    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && FlashLightOnPlayer.activeSelf)
        {
            DropItem(FlashLight, FlashLightOnPlayer);
        }
        else if (Input.GetKey(KeyCode.T) && AxeOnPlayer.activeSelf)
        {
            DropItem(Axe, AxeOnPlayer);
        }
    }

    void DropItem(GameObject sceneItem, GameObject playerItem)
    {
        //Qua sposto l'oggetto da droppare sotto di me
        sceneItem.transform.position = playerTransform.position;
        sceneItem.transform.rotation = playerTransform.rotation;

        //Attivo l'oggetto nella scena
        sceneItem.SetActive(true);

        //Disattivo l'oggetto nel First Person Controller
        playerItem.SetActive(false);
    }

}
