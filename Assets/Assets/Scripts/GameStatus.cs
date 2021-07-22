using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField] private int playerMovementCounts = 0;
    [SerializeField] private int blockMovementCounts = 0;

    [SerializeField] private int blockLeftCounts;

    [SerializeField] private TextMeshProUGUI playerMoved;
    [SerializeField] private TextMeshProUGUI blockMoved;
    [SerializeField] private TextMeshProUGUI gameTime;
    [SerializeField] private TextMeshProUGUI blockLeft;


    private void Start()
    {
        playerMoved.text = "Player Moved: 0";
        blockMoved.text = "Block Moved: 0";
        gameTime.text = "Game Playing Time: 0";

        blockLeft.text = "Block: " + blockLeftCounts; 
    }

    public void PlayerMovementCount(int moveCount)
    {
        playerMovementCounts = moveCount;

        playerMoved.text = "Player Moved: " + playerMovementCounts.ToString();

    }

    public void BlockMovementCounts()
    {
        ++blockMovementCounts;

        blockMoved.text = "Block Moved: " + blockMovementCounts.ToString();
    }

    public void AmountBlockLeft(int blockCounts)
    {
        blockLeftCounts = blockCounts;

        blockLeft.text = "Block: " + blockCounts;

    }

    private void FixedUpdate()
    {
        int time = (int)Time.time;

        gameTime.text = "Game Playing Time: " + time.ToString();
    }

    

   

}
