using UnityEngine;

public class WaterPhsiysc : MonoBehaviour
{   
   private void OnTriggerEnter(Collider other)
   {

    Debug.Log(other.name + "Submerged");
   }
   private void OnTriggerExit(Collider other)
   {

    Debug.Log(other.name + "Dry");
   }
}
