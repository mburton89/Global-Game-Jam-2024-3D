using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private float initialScale = 2f;
    private float initialRadius = 0.5f;
    public float ballSize;
    public BallMovement Ball;

    private void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }
    }

   
    // Start is called before the first frame update
    void Start()
    {
        Ball = FindObjectOfType<BallMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
