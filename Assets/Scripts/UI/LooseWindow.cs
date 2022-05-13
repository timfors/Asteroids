using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LooseWindow : SessionUI
{
    [SerializeField] private TextMeshProUGUI score;
    
    public override void Init(SessionData data)
    {
        base.Init(data);
        score.text = data.Score.ToString();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
