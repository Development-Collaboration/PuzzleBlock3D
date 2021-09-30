
using UnityEngine;

//
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]


[RequireComponent(typeof(BlockMovement))]


public class Block : MonoBehaviour
{


    private BlockMovement blockMovement;
    private Level level;


    private void Awake()
    {
        blockMovement = GetComponent<BlockMovement>();

        level = FindObjectOfType<Level>();

        CountBlocks();

    }

    private void Start()
    {
        //CountBlocks();
    }

    private void CountBlocks()
    {
        level.CountBlocks();
    }

    public void GoalInBlock()
    {
        level.GoalInBlock();

        Destroy(this.gameObject);
    }


}
