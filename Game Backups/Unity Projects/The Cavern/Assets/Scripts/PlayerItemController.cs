using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemController : MonoBehaviour
{
    public GameObject[] items = new GameObject[5];
    [SerializeField] private int activeItem;
   // int numOfItems;

   /* private void Start()
    {
        numOfItems = items.Length; 
    } */
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            ItemSelector(0); 
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            ItemSelector(1);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            ItemSelector(2);
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            ItemSelector(3);
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            ItemSelector(4); 
        }
       
    }
    private void ItemSelector(int itemNo)
    {
        if (items[itemNo] != null || items[itemNo].activeInHierarchy == false)       /// if the item exists and is not currently active, then set the previously held item to inactive and activate the new item
        {
           
            items[activeItem].SetActive(false);
            activeItem = itemNo;
            items[itemNo].SetActive(true);
            Debug.Log($"item no.{itemNo} \"{items[itemNo].name}\" selected");
            
            
        }
    }
}
