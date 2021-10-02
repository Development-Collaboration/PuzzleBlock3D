using System.Collections;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //
    [SerializeField] private TextMeshProUGUI playerMoved;
    [SerializeField] private TextMeshProUGUI blockMoved;
    [SerializeField] private TextMeshProUGUI gameTime;
    [SerializeField] private TextMeshProUGUI blockLeft;

    [SerializeField] private TextMeshProUGUI rewind;


    //
    private int playerMovementCounts;
    private int blockMovementCounts;
    private int blockLeftCounts;

    private int timeMin;
    private float timeSec;

    private int rewindCount;
    private BasicMovement[] basicMovementArray;

    private PlayerMovement playerMovement;


    private void Start()
    {
        playerMoved.text = "Player Moved: 0";
        blockMoved.text = "Block Moved: 0";
        gameTime.text = "Game Playing Time: 0:0";
        blockLeft.text = "Block Left: " + blockLeftCounts;

        rewind.text = "Rewind: 0";
        

        StartCoroutine(CountdownTimer());

        basicMovementArray = FindObjectsOfType<BasicMovement>();


        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    IEnumerator CountdownTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);

            ++timeSec;

            if (timeSec > 60)
            {
                ++timeMin;

                timeSec = 0;
            }
            gameTime.text = "Game Playing Time: " + timeMin.ToString() + ":" + ((int)timeSec).ToString();

        }

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

    public void OnRewind()
    {
        playerMovement.RewindGravityPos();


        //
        for (int i = 0; i < basicMovementArray.Length; ++i)
        {
            if (basicMovementArray[i] != null)
            {
                basicMovementArray[i].RewindPoints();
                //playerMovementArray[i].RewindGravity();
            }

            
        }




        ++rewindCount;

        rewind.text = "Rewind: " + rewindCount;

    }





}
