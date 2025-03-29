using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Area : MonoBehaviour
{
    private float xOffset = 0.07f; 
    private float yOffset = 0.07f;  
    private int itemsPerRow = 3;   
    private float dropDelay = 0.05f;
    public int capacity;
    public bool isForPlayer;
    public bool isForAIPlayer;



    public Stack<GameObject> AreaItems = new Stack<GameObject>();

     int count = 0; 
     int row = 0;   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("Player") && isForPlayer)
        {
            var player = other.gameObject.GetComponent<Player>();

            var items = player.stackedIWoodLogs.ToArray();

            StartCoroutine(GetItemsFromPlayer(items, player));



        }

        if (other.gameObject.transform.CompareTag("Player") && isForAIPlayer)
        {
            var player = other.gameObject.GetComponent<Player>();

            //var items = player.stackedIWoodLogs.ToArray();

           // StartCoroutine(GetItemsFromPlayer(items, player));

            AreaItems.Clear();
            count = 0;
            row = 0;



        }
    }

    private IEnumerator GetItemsFromPlayer(GameObject[] items,Player player)
    {
        foreach (var item in items)
        {
            if (!isFull())
            {

                float xPos = (count % itemsPerRow) * xOffset;
                float yPos = (row * yOffset);

                item.transform.SetParent(null);
                item.transform.position = new Vector3(transform.position.x + xPos - 0.05f, transform.position.y + yPos, transform.position.z);
                item.transform.rotation = Quaternion.Euler(0, 90, 0);
                item.transform.SetParent(this.gameObject.transform);

                count++;

                if (count % itemsPerRow == 0)
                {
                    row++;
                }
                AreaItems.Push(item);
                player.stackedIWoodLogs.Pop();

                yield return new WaitForSeconds(dropDelay);
            }
            else { break; }

        }

    }

    public bool isFull()
    {
        return (AreaItems.Count > capacity); // not full retruns false
    }

    public void GetItemFromSpawner(GameObject item)
    {
        
            if (!isFull())
            {
            item.GetComponent<Rigidbody>().isKinematic = true;

                float xPos = (count % itemsPerRow) * xOffset;
                float yPos = (row * yOffset);

                item.transform.SetParent(null);
                item.transform.position = new Vector3(transform.position.x + xPos - 0.05f, transform.position.y + yPos, transform.position.z);
                item.transform.rotation = Quaternion.Euler(0, 90, 0);
                item.transform.SetParent(this.gameObject.transform);

                count++;

                if (count % itemsPerRow == 0)
                {
                    row++;
                }
                AreaItems.Push(item);
                //player.stackedIWoodLogs.Pop();

            }
            else { return; }

        
    }

    public GameObject DecreaseItem()
    {
        if (AreaItems.Count > 0)
        {
            GameObject lastItem = AreaItems.Pop(); // Son eklenen itemi al ve kaldýr

            count--; 

            if (count % itemsPerRow == 0 && row > 0)
            {
                row--; 
            }
            return lastItem;
        }

        else
        {
            return null;
        }
    }

}
