using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
  public string tagTarget = "Player";
  public List<Collider2D> detectedObjects = new List<Collider2D>();

  void OnTriggerEnter2D(Collider2D collider){

        if (collider.gameObject.tag == tagTarget){
            detectedObjects.Add(collider);
        }

    }

    void OnTriggerExit2D(Collider2D collider){

        if (collider.gameObject.tag == tagTarget){
            detectedObjects.Remove(collider);
        }

    }

}
