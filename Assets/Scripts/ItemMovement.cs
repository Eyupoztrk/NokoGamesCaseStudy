using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public Transform playerBack; // Eþyalarýn sýrt pozisyonu
    private float stackHeight = 0.07f; // Eþyalarýn üst üste binme yüksekliði
    //public GameObject StackPos;
    private List<Transform> stackedItems = new List<Transform>(); // Toplanan eþyalar listesi
    private Player player;

    void Start()
    {
        // Baþlangýçta sýrt pozisyonunu bul
        // playerBack = GameObject.FindGameObjectWithTag("PlayerBack").transform;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checker"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            player.stackedIWoodLogs.Push(gameObject);
            CollectItemToPlayer(gameObject.transform);
           
        }
    }

    public void CollectItemToPlayer(Transform item)
    {
        var StackPos = GameObject.FindGameObjectWithTag("stackPos");
        Vector3 targetPosition = new Vector3(StackPos.transform.position.x, StackPos.transform.position.y, StackPos.transform.position.z) + Vector3.up * (stackHeight * player.stackedIWoodLogs.Count);

        item.position = targetPosition;
        item.rotation = player.gameObject.transform.rotation;
        item.SetParent(player.gameObject.transform, true);
    }
}
