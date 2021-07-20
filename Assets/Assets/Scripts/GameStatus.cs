using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField] private int playerMovementCounts = 0;
    [SerializeField] private int blockMovementCounts = 0;


    [SerializeField] private TextMeshProUGUI playerMoved;
    [SerializeField] private TextMeshProUGUI blockMoved;
    [SerializeField] private TextMeshProUGUI gameTime;


    private void Start()
    {
        playerMoved.text = "Player Moved: 0";
        blockMoved.text = "Block Moved: 0";
        gameTime.text = "Game Playing Time: 0";
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

    private void FixedUpdate()
    {
        int time = (int)Time.time;

        gameTime.text = "Game Playing Time: " + time.ToString();
    }



}
