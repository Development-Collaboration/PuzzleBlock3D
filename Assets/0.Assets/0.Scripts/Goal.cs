using UnityEngine;
using System;


[Flags]
public enum GoalType
{
    UnbreakAndUnmove = 1 << 0,
    Unbreakable = 1 << 1,
    Unmoveable = 1 << 2,
    BreakableAndMove = 1 << 3,
    Breakable = 1 << 4,
    Moveable = 1 << 5,
}



//[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]

public class Goal : MonoBehaviour
{
    private Level level;
    private BoxCollider boxCollider;
    // private ITweenUitility iTweenUtility;

    [SerializeField] private GoalType glockType;

    public GoalType GlockType { get; set; }


    private void Awake()
    {
        level = FindObjectOfType<Level>();
        boxCollider = GetComponent<BoxCollider>();

        boxCollider.isTrigger = true;

        // iTweenUtility = GetComponent<ITweenUitility>();


    }

    public void OnBlockReachedGoal()
    {
        print("from goal HI");

        level.GoalInBlock();

    }



    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.gameObject.CompareTag(block))
        {
            print("reached goal");
            other.gameObject.SetActive(false);
        }
        */
    }

}
