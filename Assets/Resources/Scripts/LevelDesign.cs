using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LevelDesign : MonoBehaviour {
    public float coolDown, coolDown2;
    public Text scoreText, loseWord;
    public Animator anim, scoreAnim;
    public bool type1, type2, type3;
    GameObject buttonParent;
    public Button backButton;
    
    float lastSpawn, lastSpawn2;
    float score = 0;
    GameObject enemyPrefab, enemy2Prefab;
    MyPlayerPref myPlayerPref;

	// Use this for initialization
	void Start () {
        lastSpawn = Time.realtimeSinceStartup;
        enemyPrefab = (GameObject)Resources.Load("Prefab/Enemy");
        enemy2Prefab = (GameObject)Resources.Load("Prefab/Enemy2");
        myPlayerPref = GetComponent<MyPlayerPref>();
        buttonParent = GameObject.Find("Canvas/Button");
        Physics2D.IgnoreLayerCollision(8, 8);
        setScoreText(0);
	}
	
	// Update is called once per frame
	void Update () {
        EnemyOne();
        EnemyTwo();

        //testing gameover
        if (Input.GetKeyDown(KeyCode.G))
        {
            myPlayerPref.SetHighScore(score, SceneManager.GetActiveScene().name);
        }
    }

    void EnemyOne()
    {
        if ((Time.realtimeSinceStartup * Time.timeScale) - lastSpawn > coolDown && type1)
        {
            lastSpawn = Time.realtimeSinceStartup;
            if (coolDown > 0.8f) coolDown -= 0.002f;
            Spawn();
        }
    }

    void EnemyTwo()
    {
        if ((Time.realtimeSinceStartup * Time.timeScale) - lastSpawn2 > coolDown2 && type2)
        {
            lastSpawn2 = Time.realtimeSinceStartup;
            if (coolDown2 > 3f) coolDown -= 0.002f;
            Spawn(enemy2Prefab);
        }
    }

    void Spawn(GameObject theEnemy)
    {
        GameObject enemy;
        float horizontalPos = Random.Range(0, 2);
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
        scoreText.text = "Score : " + score.ToString();
    }

    public void GameOver()
    {
        float tempScore = myPlayerPref.GetHighScore(SceneManager.GetActiveScene().name);
        if(score > tempScore)
        {
            scoreAnim.SetBool("NewHighScore", true);
            myPlayerPref.SetHighScore(score, SceneManager.GetActiveScene().name);
            scoreText.color = Color.yellow;
            scoreText.text = "NEW HIGHSCORE!\n" + score.ToString();
        }
        buttonParent.SetActive(false);
        Time.timeScale = 0;
        anim.SetBool("isOver", true);
        backButton.transform.localScale = new Vector3(0.6548014f, 0.6548014f, 0.6548014f);
    }

    public void TestGameOver()
    {
        float tempScore = myPlayerPref.GetHighScore(SceneManager.GetActiveScene().name);
        float testScore = 99;
        
            scoreAnim.SetBool("NewHighScore", true);
            //myPlayerPref.SetHighScore(score);
            scoreText.color = Color.yellow;
            scoreText.text = "NEW HIGHSCORE!\n" + testScore.ToString();
        Time.timeScale = 0;
        anim.SetBool("isOver", true);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public float getScore()
    {
        return score;
    }
}
