using UnityEngine;
using UnityEngine.UI;
public class ScoreCounter : MonoBehaviour
{

    public static int scoreAmount = 0;
    Text playerScore;

    // Start is called before the first frame update
    void Start()
    {
        playerScore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        playerScore.text = "Score: " + scoreAmount;
    }
}
