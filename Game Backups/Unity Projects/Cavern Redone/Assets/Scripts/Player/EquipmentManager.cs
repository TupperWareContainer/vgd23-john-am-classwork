using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public GameObject[] equipment;
    private void Start()
    {
        for(int i = 0; i < equipment.Length; i++)
        {
            equipment[i].SetActive(false); 
        }
    }
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1)) ChooseEquipment(1);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) ChooseEquipment(2);
        else if (Input.GetKeyDown(KeyCode.Alpha3)) ChooseEquipment(3);
    }
    void ChooseEquipment(int key)
    {
        switch (key)
        {
            case 1:       ///Flashlight
                if(equipment.Length >= 1)
                {
                    equipment[0].SetActive(!equipment[0].activeInHierarchy);
                   
                    Debug.Log(equipment[0].name + " toggled"); 
                }
                break;
            case 2:           ///Compass 
                if(equipment.Length >= 2)
                {
                    equipment[1].SetActive(!equipment[1].activeInHierarchy);
                    Debug.Log(equipment[1].name + " toggled");
                }
                break;
            case 3:
                if (equipment.Length >= 3)
                {
                    for(int i = 0; i < key; i++)
                    {
                        equipment[i].SetActive(false); 
                    }
                    equipment[2].SetActive(!equipment[2].activeInHierarchy);
                    Debug.Log(equipment[2].name + " toggled");
                }
                break;

        }
    }
}
