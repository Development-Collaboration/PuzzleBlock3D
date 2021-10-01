
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

    }

    private void Start()
    {
        CountBlocks();
    }

    private void CountBlocks()
    {
        level.CountBlocks();
    }

    public void BlockReachedGoal(Goal goal)
    {
        goal.OnBlockReachedGoal();

        //level.GoalInBlock();

        Destroy(this.gameObject);
    }


}
