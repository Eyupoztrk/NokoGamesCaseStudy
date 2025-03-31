using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AreaType
{
    None,
    Process,
    LastProduct,
    Trash,
    Money
}

public enum OwnerType
{
    None,
    Player,
    AI
}

public enum AIInteractionType
{
    None,
    Input,
    Output
}

public class Area : MonoBehaviour
{
    private float xOffset = 0.07f;
    private float yOffset = 0.07f;
    private int itemsPerRow = 3;
    private float dropDelay = 0.05f;
    public int capacity;

    public AreaType areaType;
    public OwnerType ownerType;
    public AIInteractionType aiInteractionType;

    public Stack<GameObject> AreaItems = new Stack<GameObject>();

    int count = 0;
    int row = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.CompareTag("Player") && ownerType == OwnerType.Player)
        {
            var player = other.gameObject.GetComponent<Player>();
            var items = player.CollectedItems.ToArray();

            switch (areaType)
            {
                case AreaType.Money:
                    StartCoroutine(GetItemsFromPlayerForMoney(items, player));
                    break;
                case AreaType.LastProduct:
                    GiveItemToPlayer(player);
                    break;
                case AreaType.Process:
                    StartCoroutine(GetItemsFromPlayer(items, player));
                    break;
            }
        }

        if (other.gameObject.transform.CompareTag("AIPlayer") && ownerType == OwnerType.AI)
        {
            var aiPlayer = other.gameObject.GetComponent<AIPlayer>();

            switch (aiInteractionType)
            {
                case AIInteractionType.Input:
                    TransferItemsToAI(aiPlayer);
                    break;
                case AIInteractionType.Output:
                    var items = aiPlayer.CollectedItems.ToArray();
                    StartCoroutine(GetItemsFromPlayer(items, aiPlayer));
                    break;
            }
        }
    }

    private void TransferItemsToAI(AIPlayer aiPlayer)
    {
        var count = AreaItems.Count;
        for (int i = 0; i < count; i++)
        {
            var item = DecreaseItem();
            item.GetComponent<ItemMovement>().CollectItemToAiPlayer(item.transform);
            aiPlayer.CollectedItems.Push(item);
        }
    }

    private IEnumerator GetItemsFromPlayer(GameObject[] items, Player player)
    {
        foreach (var item in items)
        {
            if (!isFull())
            {
                PositionItem(item);
                AreaItems.Push(item);
                player.CollectedItems.Pop();
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
                PositionItem(item);
                AreaItems.Push(item);
                aiPlayer.CollectedItems.Pop();
                yield return new WaitForSeconds(dropDelay);
            }
            else { break; }
        }
    }

    private IEnumerator GetItemsFromPlayerForMoney(GameObject[] items, Player player)
    {
        foreach (var item in items)
        {
            if (!isFull() && item.gameObject.transform.CompareTag("Product"))
            {
                GameManager.Instance.EarnMoney(50);
                PositionItem(item);
                AreaItems.Push(item);
                player.CollectedItems.Pop();
                yield return new WaitForSeconds(dropDelay);
            }
            else { break; }
        }
    }

    private void GiveItemToPlayer(Player player)
    {
        var count = AreaItems.Count;
        for (int i = 0; i < count; i++)
        {
            var item = DecreaseItem();
            item.GetComponent<ItemMovement>().CollectItemToPlayer(item.transform);
            player.CollectedItems.Push(item);
        }
    }

    public bool isFull()
    {
        return (AreaItems.Count >= capacity);
    }

    public void GetItemFromSpawner(GameObject item)
    {
        if (!isFull())
        {
            item.GetComponent<Rigidbody>().isKinematic = true;
            PositionItem(item);
            AreaItems.Push(item);
        }
    }

    private void PositionItem(GameObject item)
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
    }

    public GameObject DecreaseItem()
    {
        if (AreaItems.Count > 0)
        {
            GameObject lastItem = AreaItems.Pop();

            count--;

            if (count % itemsPerRow == 0 && row > 0)
            {
                row--;
            }
            return lastItem;
        }
        return null;
    }
}
