using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{

    public Area inputArea;
    public Area outputArea;

    public Transform inputSpawnerPos;
    public Transform outputSpawnerPos;
    public GameObject targetObjectForMachine;

    public float moveSpeed = 5f; // Hareket hýzý
    public float processTime = 1f;

    protected bool isProcessing = false;

    protected IEnumerator AutoProcess()
    {
        while (true)
        {
            yield return new WaitUntil(() => inputArea.AreaItems.Count > 0 && !outputArea.isFull());
            yield return StartCoroutine(ProcessItem());
        }
    }

    protected virtual IEnumerator ProcessItem()
    {

        while (inputArea.AreaItems.Count > 0 && !outputArea.isFull())
        {
            GameObject inputItem = inputArea.DecreaseItem();

            yield return StartCoroutine(MoveToPosition(inputItem, inputSpawnerPos.position));
            yield return new WaitForSeconds(processTime);
            Destroy(inputItem);

            GameObject outputItem = Instantiate(targetObjectForMachine, outputSpawnerPos.position, Quaternion.Euler(0, 90, 0));
            yield return new WaitForSeconds(processTime);
            outputArea.GetItemFromSpawner(outputItem);
        }

        isProcessing = false; 
    }


    private IEnumerator MoveToPosition(GameObject obj, Vector3 targetPosition)
    {
        while (Vector3.Distance(obj.transform.position, targetPosition) > 0.1f)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
