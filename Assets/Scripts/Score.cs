using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
 
public class Score : NetworkBehaviour
{
    public Text scoreText;
    public int maxScore = 4;

    public AudioSource[] sounds;
    public AudioSource winSound;
    public AudioSource shatterSound;
 
    int score;
 
    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        winSound = sounds[0];
        shatterSound = sounds[1];
        score = 0;
        scoreText.text = score + " out 4 Child saved"; 
    }
    
    //we will call this method from our target script
    // whenever the player collides or shoots a target a point will be added
    public void AddPoint()
    {
        shatterSound.Play();
        score++;
 
        if (score != maxScore)
            scoreText.text = score + " out 4 Child saved"; 
        else
            scoreText.text = "Finish the Maze!";
    }

    public bool checkPoint()
    {
        if (score != maxScore){
            scoreText.text = "Find the last " + (maxScore - score) + " child"; 
            return false;
        }
        else {
            winSound.Play();
            scoreText.text = "Maze Completed!";   
        }
        return true; 
    }

}