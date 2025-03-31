using System.Collections;
using UnityEngine;

public class AIPlayerMovement : MonoBehaviour
{
    public Transform inputArea;
    public Transform outputArea;
    public Transform trashArea;
    public float speed = 2f;
    public float idleTime = 2f;
    public Animator animator;

    private bool isMoving = false;

    void Start()
    {
        StartCoroutine(MoveRoutine());
    }

    IEnumerator MoveRoutine()
    {
        while (true)
        {
            if (CanCollectFromInput())
            {
                yield return MoveToTarget(inputArea);
                yield return new WaitForSeconds(idleTime);

                yield return MoveToTarget(outputArea);
                yield return new WaitForSeconds(idleTime);
            }
            else
            {
                yield return new WaitForSeconds(idleTime);
            }
        }
    }

    IEnumerator MoveToTarget(Transform target)
    {
        isMoving = true;
        animator.SetBool("isRun", true);
        animator.SetBool("isIdle", false);

        while (Vector3.Distance(transform.position, target.position) > 0.2f)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
        animator.SetBool("isRun", false);
        animator.SetBool("isIdle", true);
    }

    private bool CanCollectFromInput()
    {
        var inputAreaComponent = inputArea.GetComponent<Area>();
        var outputAreaComponent = outputArea.GetComponent<Area>();
        return inputAreaComponent.AreaItems.Count > 0 && !outputAreaComponent.isFull();
    }
}