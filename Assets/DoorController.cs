using System;
using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject Door;
    public Boolean IsDoorOpened;
    public GameObject OpenText;
    public GameObject CloseText;
    public float rotationSpeed = 2.0f; // Velocità di rotazione

    private bool isRotating = false; // Flag per controllare se la porta sta ruotando
    private Quaternion closedRotation;
    private Quaternion openedRotation;

    void Start()
    {
        OpenText.SetActive(false);
        CloseText.SetActive(false);

        // Imposta le rotazioni chiuse e aperte
        closedRotation = Door.transform.rotation;
        openedRotation = Quaternion.Euler(Door.transform.eulerAngles + new Vector3(0, 90, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!IsDoorOpened)
            {
                OpenText.SetActive(true);
            }
            else
            {
                CloseText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OpenText.SetActive(false);
            CloseText.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isRotating)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!IsDoorOpened)
                {
                    StartCoroutine(RotateDoor(openedRotation)); // Ruota alla posizione aperta
                    IsDoorOpened = true;
                    OpenText.SetActive(false);
                    CloseText.SetActive(true);
                }
                else
                {
                    StartCoroutine(RotateDoor(closedRotation)); // Ruota alla posizione chiusa
                    IsDoorOpened = false;
                    OpenText.SetActive(true);
                    CloseText.SetActive(false);
                }
            }
        }
    }

    private IEnumerator RotateDoor(Quaternion toRotation)
    {
        isRotating = true; // Imposta la flag per indicare che la porta sta ruotando
        Quaternion fromRotation = Door.transform.rotation;
        for (float t = 0; t < 1; t += Time.deltaTime * rotationSpeed)
        {
            Door.transform.rotation = Quaternion.Slerp(fromRotation, toRotation, t);
            yield return null;
        }
        Door.transform.rotation = toRotation; // Assicurati che la rotazione finisca esattamente all'angolo desiderato
        isRotating = false; // Reimposta la flag una volta completata la rotazione
    }
}
