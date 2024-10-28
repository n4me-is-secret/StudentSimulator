using UnityEngine;
using UnityEngine.UI;

public class DoorOpener : MonoBehaviour
{

    public Transform door; // Объект двери 
    public Text messageText; // UI текст для сообщения игроку 
    public float openSpeed = 2.0f; // Скорость открытия двери 
    public float openAngle = 90.0f; // Угол на который дверь открывается 

    private bool isPlayerNear = false; // Проверка, находится ли игрок рядом 
    private bool isDoorOpen = false; // Проверка, открыта ли дверь 
    private Quaternion initialRotation; // Начальная ротация двери 
    private Quaternion targetRotation; // Целевая ротация двери 

    void Start() 
    { 
        initialRotation = door.rotation; 
        targetRotation = Quaternion.Euler(door.eulerAngles.x, door.eulerAngles.y, door.eulerAngles.z + openAngle); 
        messageText.gameObject.SetActive(false); // Изначально скрываем текст сообщения 
    } 

    void Update() 
    { 
        if (isPlayerNear && !isDoorOpen) // "Return" это "Enter" на клавиатуре 
        { 
            isDoorOpen = true; 
            StartCoroutine(OpenDoor()); 
        } 
    } 

    void OnTriggerEnter(Collider other) 
    { 
        if (other.CompareTag("Player")) 
        { 
            isPlayerNear = true; 
            messageText.text = "Нажмите Enter чтобы открыть дверь"; 
            messageText.gameObject.SetActive(true); 
        } 
    } 

    void OnTriggerExit(Collider other) 
    { 
        if (other.CompareTag("Player")) 
        { 
            isPlayerNear = false; 
            messageText.gameObject.SetActive(false); 
        } 
    } 

    System.Collections.IEnumerator OpenDoor() 
    { 
        float time = 0; 
        while (time < 1) 
        { 
            door.rotation = Quaternion.Slerp(initialRotation, targetRotation, time); 
            time += Time.deltaTime * openSpeed; 
            yield return null; 
        } 
        door.rotation = targetRotation; 
    } 
    
}
