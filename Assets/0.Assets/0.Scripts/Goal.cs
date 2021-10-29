using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]

public class Goal : MonoBehaviour
{
    private Level level;
    private BoxCollider boxCollider;
    // private ITweenUitility iTweenUtility;


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
