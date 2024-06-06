using UnityEngine;

public class DoorController : MonoBehaviour
{
    public float openAngle = 90f; // Angolo di apertura
    public float closeAngle = 0f; // Angolo di chiusura
    public float smooth = 2f; // Velocità di apertura/chiusura
    private bool isOpen = false; // Stato della porta
    private Quaternion targetRotation; // Rotazione di destinazione

    void Start()
    {
        targetRotation = transform.rotation;
    }

    void Update()
    {
        // Lerp per una transizione graduale
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * smooth);
    }

    public void ToggleDoor()
    {
        // Alterna tra aperto e chiuso
        isOpen = !isOpen;
        if (isOpen)
        {
            targetRotation = Quaternion.Euler(transform.eulerAngles.x, 90f, transform.eulerAngles.z);
        }
        else
        {
            targetRotation = Quaternion.Euler(transform.eulerAngles.x, closeAngle, transform.eulerAngles.z);
        }
    }
}
