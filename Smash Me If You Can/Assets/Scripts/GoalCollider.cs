using UnityEngine;
using UnityEngine.UI;


public class GoalCollider : MonoBehaviour
{
    private GameObject character;
    private GameObject ball;
    public Vector3 center;
    int score;
    public Text scoreText;

    void Start()
    {
        ball = GameObject.Find("Ball");
        character = GameObject.Find("Character");
    }



    private void OnTriggerEnter(Collider collider)

    {
        print("COLLISION DETECTED");
        if (collider.gameObject.CompareTag("Ball"))
        {

            score++;
            scoreText.text = "Score: " + score.ToString();
            character.transform.position = center;
            ball.transform.position = center;
        }
    }
}
