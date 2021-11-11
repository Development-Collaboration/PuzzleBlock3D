using System.Collections;
using UnityEngine;
using System;

using UnityEngine.VFX;


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

    [SerializeField] private GoalType goalType;

    public GoalType GloalType
    {
        get { return goalType; }
        set { goalType = value; }
    }


    [Header("VFX at Goal")]
    [SerializeField] private VisualEffect vfx;
    [SerializeField] private float fireworksDuration;
    [SerializeField] private uint fireworksSpawnRate;

    private void Awake()
    {
        level = FindObjectOfType<Level>();
        boxCollider = GetComponent<BoxCollider>();

        boxCollider.isTrigger = true;

        // iTweenUtility = GetComponent<ITweenUitility>();

    }

    private void Start()
    {
        //
        StopFireworks();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayFireworks();
        }

    }


    public void OnBlockReachedGoal()
    {
        print("from goal HI");

        level.GoalInBlock();

    }


    public void StopFireworks()
    {
        vfx.SetUInt("SpawnRate", 0);
    }


    public void PlayFireworks(uint spawnRate = 1, float duration = 0f)
    {
        StartCoroutine(FireworksTimer(spawnRate,duration));
    }

    IEnumerator FireworksTimer(uint spawnRate, float duration)
    {

        // default
        if(duration == 0f)
        {
            // default, 1/1  convert from inspector;
            duration = fireworksDuration;
            spawnRate = fireworksSpawnRate;

            vfx.SetUInt("SpawnRate", spawnRate);

            while (duration >= 0)
            {

                duration -= Time.deltaTime;
                print(duration + " fireworksDuration");
                yield return null;

            }

        }

        StopFireworks();
        yield return null;
    }



}
