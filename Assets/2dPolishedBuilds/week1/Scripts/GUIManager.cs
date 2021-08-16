using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GUIManager : MonoBehaviour
{
    //score
    //public float score;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI loseText;

    [SerializeField] private Button restart;
    [SerializeField] private Button quit;
    
    
    
    
    //[SerializeField] private Enemy eEnem;
    [SerializeField] private GameData gData;
    private float finalScore;
    
    // Start is called before the first frame update
    void Start()
    {
        gData = FindObjectOfType<GameData>();
        gData.playerScore = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreText.text = $"Score: {gData.playerScore}";
        livesText.text = $"Lives: {gData.lives}";
        OnDeath();
    }

    private void OnDeath()
    {
        if (gData.lives == 0)
        {
            finalScore = gData.playerScore;
            scoreText.gameObject.SetActive(false);
            livesText.gameObject.SetActive(false);
            loseText.text = $"GAME OVER \n Your final score was {finalScore}\n Try again?";
            restart.gameObject.SetActive(true);
            quit.gameObject.SetActive(true);

        }
    }

    public void Restart() => SceneManager.LoadScene("SampleScene");

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit;
        #endif
    }

}
