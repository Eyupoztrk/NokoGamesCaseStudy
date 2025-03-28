using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CutSystem : MonoBehaviour
{
    private GameObject player;
    public float elapsedTime;



    protected virtual void Starting()
    {
        print("start");
        elapsedTime = 0;
        player = GameObject.FindGameObjectWithTag("Player");
       // player.GetComponent<PlayerMovement>().Cut();
    }

    public virtual IEnumerator Cutting(Slider treeSlider, float cuttingTime)
    {
        
        while (player.GetComponent<PlayerMovement>().isCutting)
        {
            yield return new WaitForSeconds(0.01f);
            elapsedTime += Time.deltaTime;
            treeSlider.value = elapsedTime;

            if(elapsedTime >= cuttingTime)
            {
                player.GetComponent<PlayerMovement>().Idle();
                yield break;
            }

        }



    }
}
