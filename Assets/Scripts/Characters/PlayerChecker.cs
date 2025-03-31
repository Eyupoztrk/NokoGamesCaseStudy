using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Tree"))
        {
            print("cutting");
            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerMovement>().Cut();

            var tree = other.gameObject.GetComponent<Tree>();
            StartCoroutine(tree.Cutting(tree.treeSlider,tree.cuttingTime));

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("Tree"))
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerMovement>().Idle();

            var tree = other.gameObject.GetComponent<Tree>();
            StopCoroutine(tree.Cutting(tree.treeSlider, tree.cuttingTime));

        }
    }
}
