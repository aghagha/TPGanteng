using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelDesign : MonoBehaviour {
    public float coolDown, coolDown2;
    public Text scoreText, loseWord;
    public Animator anim, loseBgAnim;
    
    float lastSpawn, lastSpawn2;
    float score = 0;
    GameObject enemyPrefab, enemy2Prefab;

	// Use this for initialization
	void Start () {
        lastSpawn = Time.realtimeSinceStartup;
        enemyPrefab = (GameObject)Resources.Load("Prefab/Enemy");
        enemy2Prefab = (GameObject)Resources.Load("Prefab/Enemy2");
        Physics2D.IgnoreLayerCollision(8, 8);
	}
	
	// Update is called once per frame
	void Update () {
        if ((Time.realtimeSinceStartup * Time.timeScale) - lastSpawn > coolDown)
        {
            lastSpawn = Time.realtimeSinceStartup;
            if (coolDown > 0.8f) coolDown -= 0.002f;
            Spawn();
        }
        if ((Time.realtimeSinceStartup * Time.timeScale) - lastSpawn2 > coolDown2)
        {
            lastSpawn2 = Time.realtimeSinceStartup;
            if (coolDown2 > 3f) coolDown -= 0.002f;
            Spawn(enemy2Prefab);
        }
    }

    void Spawn(GameObject theEnemy)
    {
        GameObject enemy;
        float horizontalPos = Random.Range(0, 1);
        if(horizontalPos == 0)
        {
            horizontalPos = -1 * Random.Range(3.02f, 7.8f);
        }
        else horizontalPos = Random.Range(3.02f, 7.8f);
        Vector2 spawnPoint = new Vector2(horizontalPos, 6.85f);

        enemy = (GameObject) Instantiate(theEnemy, spawnPoint, Quaternion.identity);
    }

    void Spawn()
    {
        GameObject enemy;
        Vector2 spawnPoint = new Vector2(Random.Range(-7.8f, 7.8f), 6.85f);

        enemy = (GameObject)Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
    }

    public void AddScore(float amount)
    {
        score += amount;
        setScoreText(score);
    }

    void setScoreText(float score)
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        scoreText.color = Color.yellow;
        anim.SetBool("isOver", true);
        loseBgAnim.SetBool("isOver", true);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
    }
}
