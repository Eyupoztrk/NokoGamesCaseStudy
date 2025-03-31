using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public Transform playerBack; 
    private float stackHeight = 0.07f; 
    private Player player;
    private AIPlayer aIPlayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        aIPlayer = GameObject.FindGameObjectWithTag("AIPlayer").GetComponent<AIPlayer>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checker") && gameObject.transform.CompareTag("Log"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            player.CollectedItems.Push(gameObject);
            CollectItemToPlayer(gameObject.transform);
           
        }
    }

    public void CollectItemToPlayer(Transform item)
    {
        var StackPos = GameObject.FindGameObjectWithTag("stackPos");
        Vector3 targetPosition = new Vector3(StackPos.transform.position.x, StackPos.transform.position.y, StackPos.transform.position.z) + Vector3.up * (stackHeight * player.CollectedItems.Count);

        item.position = targetPosition;
        item.rotation = player.gameObject.transform.rotation;
        item.SetParent(player.gameObject.transform, true);
    }

    public void CollectItemToAiPlayer(Transform item)
    {
        var StackPos = GameObject.FindGameObjectWithTag("stackPosForAIPlayer");
        Vector3 targetPosition = new Vector3(StackPos.transform.position.x, StackPos.transform.position.y, StackPos.transform.position.z) + Vector3.up * (stackHeight * aIPlayer.CollectedItems.Count);

        item.position = targetPosition;
        item.rotation = aIPlayer.gameObject.transform.rotation;
        item.SetParent(aIPlayer.gameObject.transform, true);
    }

}
