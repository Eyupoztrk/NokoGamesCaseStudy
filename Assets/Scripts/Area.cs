using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour
{
    private float xOffset = 0.07f; 
    private float yOffset = 0.07f;  
    private int itemsPerRow = 3;   
    private float dropDelay = 0.05f;
    public int capacity;

    public bool isInput;
    public bool isOutput;
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

       if (other.gameObject.transform.CompareTag("AIPlayer") && isForAIPlayer)
        {

            if(isInput)
            {
                print("is input");
                var ai_player = other.gameObject.GetComponent<AIPlayer>();


                var count = AreaItems.Count;
                for (int i =0;i<count;i++)
                {
                    var item = DecreaseItem();
                    item.GetComponent<ItemMovement>().CollectItemToAiPlayer(item.gameObject.transform);
                    ai_player.stackedIWoodLogs.Push(item);

                }
            }

            if(isOutput)
            {
                var ai_player = other.gameObject.GetComponent<AIPlayer>();

                var items = ai_player.stackedIWoodLogs.ToArray();

                StartCoroutine(GetItemsFromPlayer(items, ai_player));

              /*  AreaItems.Clear();
                count = 0;
                row = 0;*/
            }



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
                item.transform.position = new Vector3(transform.position.x + xPos - 0.1f, transform.position.y + yPos, transform.position.z);
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

    private IEnumerator GetItemsFromPlayer(GameObject[] items, AIPlayer aiPlayer)
    {
        foreach (var item in items)
        {
            if (!isFull())
            {

                float xPos = (count % itemsPerRow) * xOffset;
                float yPos = (row * yOffset);

                item.transform.SetParent(null);
                item.transform.position = new Vector3(transform.position.x + xPos - 0.1f, transform.position.y + yPos, transform.position.z);
                item.transform.rotation = Quaternion.Euler(0, 90, 0);
                item.transform.SetParent(this.gameObject.transform);

                count++;

                if (count % itemsPerRow == 0)
                {
                    row++;
                }
                AreaItems.Push(item);
               
                aiPlayer.stackedIWoodLogs.Pop();

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
