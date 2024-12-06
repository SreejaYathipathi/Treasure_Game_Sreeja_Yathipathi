using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    private Animator chestAnimator; // Assign the Animator in the Inspector
    private bool isOpen = false;   // Tracks the state of the chest
    private bool isInsideTrigger = false;
    [SerializeField] private Transform OpenChestText;
    private int _itemCollect = 0;
    [SerializeField] private ItemData[] ItemPrefabs;
    private int _itemsInUI = 4;
    [SerializeField] private GameObject _itemPos;

    void Update()
    {
        if (isInsideTrigger == true && Input.GetButtonDown("F"))
        {
            OpenChest();
        }
    }

    void OpenChest()
    {
        
        chestAnimator.SetBool("IsOpen", !isOpen); // Update Animator parameter

        if (isOpen == false)
        {
            OpenChestText.gameObject.SetActive(false); // Hide message when chest is opened
            // Start item spawn after a delay
            StartCoroutine(SpawnItemsWithDelay(1f)); // delay
            isOpen = true;
        }
    }

    IEnumerator SpawnItemsWithDelay(float delay)
    {
        if (isOpen == false)
        {
            
            yield return new WaitForSeconds(delay); // Wait for the chest opening animation

            for (int x = 0; x < _itemsInUI; x++)
            {
                // Spawn a random item
                ItemData spawnedItem = Instantiate(ItemPrefabs[Random.Range(0, ItemPrefabs.Length)],
                    _itemPos.transform.position, Quaternion.identity
                );


                // Apply a simple pop-out effect
                Rigidbody rb = spawnedItem.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    rb = spawnedItem.gameObject.AddComponent<Rigidbody>();
                }

                rb.AddForce(transform.right * (10) * -1, ForceMode.Impulse);

                yield return new WaitForSeconds(1f);

            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the "Player" tag
        {
            isInsideTrigger = true;
            chestAnimator = GetComponent<Animator>();


            if (isOpen == false)
            {
                OpenChestText.gameObject.SetActive(true); // Show "Press F to open" when chest is closed
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInsideTrigger = false;
            OpenChestText.gameObject.SetActive(false); // Hide "Press F to open" when player exits trigger area
        }
    }

}
