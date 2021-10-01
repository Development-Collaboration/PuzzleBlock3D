using UnityEngine;

public class Goal : MonoBehaviour
{
    private Level level;

    private void Awake()
    {
        level = FindObjectOfType<Level>();

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
