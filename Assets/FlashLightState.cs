using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlashLightState : MonoBehaviour
{

    public GameObject FlashLightIllumination;
    public bool FlashLightEnabled;


    // Start is called before the first frame update
    void Start()
    {
        FlashLightIllumination.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && !FlashLightEnabled)
        {
            FlashLightIllumination.SetActive(true);
            FlashLightEnabled = true;
        }
        else if (Input.GetKey(KeyCode.F) && FlashLightEnabled) {
            FlashLightIllumination.SetActive(false);
            FlashLightEnabled= false;
        }

        
    }
    
    

}
