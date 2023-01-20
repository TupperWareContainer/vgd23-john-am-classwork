using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForLevelMiniature : MonoBehaviour
{
    [Header("Outside References")]
    public GameObject levelMiniature;
    public GameObject connectingLevel;
    public PickupObject player;

    [Header("Preferences")]
    public bool mendLevel;
    public bool applyGravityMod;
    public bool applySpeedMod; 
    public Transform miniaturePlacement;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.Equals(levelMiniature))
        {
            if (!player.hasEquipped) ApplyEffects();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.Equals(levelMiniature)) ReverseEffects(); 
    }

    void ApplyEffects()
    {
      
        levelMiniature.transform.parent = miniaturePlacement;
        levelMiniature.transform.rotation = Quaternion.Euler(Vector3.zero); 
        levelMiniature.transform.position = miniaturePlacement.position;
        levelMiniature.GetComponent<Rigidbody>().velocity = Vector3.zero; 
        if (mendLevel)
        {
            if (connectingLevel != null)
            {
                connectingLevel.SetActive(true);
            }
            else Debug.LogWarning("mendLevel is true despite there being no assigned connecting level!");
        }
    }
    void ReverseEffects()
    {
        if (connectingLevel != null) connectingLevel.SetActive(false);
        miniaturePlacement.DetachChildren(); 
    }


}
