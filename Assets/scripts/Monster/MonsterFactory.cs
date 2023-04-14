using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterFactory : MonoBehaviour
{
    private bool isWave = false;
    public GameObject MonsterNormal;
    public GameObject MonsterFast;
    public GameObject StartPoint;
    public float timeBeforeSpawn = 1f;
    private float timeBetweenWaves = 3f;
    private float countdown = 3f;

    public TextMeshProUGUI waveCounterText;
    public GameObject moneyObject;


    public 
    // Start is called before the first frame update
    void Start()
    {
    }



    private int getMonstersByWave(int x)
    {
        return (int)(0.008 * Math.Pow(x, 2) + (1.5539 * x) + 0.0788);
    }
        // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameOver) return;

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        //StartCoroutine();


    }

    IEnumerator SpawnWave()
    {
        if (!isWave)
        {
            isWave = true;
            int mobCount = getMonstersByWave(PlayerStats.playerWaves);
            for (int i = 0; i < mobCount; i++)
            {
                yield return new WaitForSecondsRealtime(.5f);
                int r = Random.Range(1, 100);
                if (r % 2 == 0)
                {
                    Spawn(MonsterNormal);
                }
                else
                {
                    Spawn(MonsterFast);
                }

            }
            PlayerStats.playerWaves++;
            waveCounterText.text = "Vague : " + (PlayerStats.playerWaves-1).ToString();

            isWave = false;
        }
    }
    void Spawn(GameObject monster)
    {
        if(!GameManager.isGameOver)
            Instantiate(monster, StartPoint.transform.position, StartPoint.transform.rotation);
    }
}
