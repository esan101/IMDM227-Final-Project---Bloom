using UnityEngine;
using UnityEngine.InputSystem;

public class flowerMouseManager : MonoBehaviour
{
    public GameObject flowerParent; //changed it from flower to flowerParent
    GameObject[] flowers;
    public int flowerLimit = 50;
    int numFlowers = 0;

    //add music
    public AudioClip clickSound;
    AudioSource audioSource;
    public ParticleSystem splash;
    public float minY = -5f;  // bottom of background
    public float maxY = 5f;   // top of background
    

    void Start()
    {
        flowers = new GameObject[flowerLimit];
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
         if (Mouse.current.leftButton.wasPressedThisFrame
             && Physics.Raycast(
                    Camera.main.ScreenPointToRay(
                        Mouse.current.position.ReadValue()),
                        out RaycastHit hit))
        {
            Collider collider = hit.collider;
            GameObject gameObject = collider.gameObject;
            Debug.Log($"In MouseManager, name is [{gameObject.name}]");
            
            if (gameObject.name == "Background")
            {
                
                float mouseY = hit.point.y;
                float backgroundSize = Mathf.InverseLerp(minY, maxY, mouseY);

                //if statement reads mouse's y coordinate. if y is on the lower end of screen, pitch is lower & vice versa
                if (backgroundSize <= 0.33f) //if user clicks on 1/3 lower end of the screen
                {
                    audioSource.pitch = Random.Range(0.98f, 1.02f);
                }
                else if (backgroundSize <= 0.55f) //roughly the middle of the screen
                {
                    audioSource.pitch = Random.Range(1.23f, 1.27f);
                }
                else //if user clicks on the top end of the screen
                {
                    audioSource.pitch = Random.Range(1.48f, 1.52f);
                }

                audioSource.clip = clickSound;
                audioSource.Play();
                
                Debug.Log($"Making a clone of {hit.collider.gameObject.name}");


                Vector3 pos = hit.point; // sets variable pos to be equal to where the mouse clicks on the plane
                Debug.Log("hit.point: " + hit.point);
                Quaternion rotation = Quaternion.Euler(0,0,0);
                Instantiate(splash, pos, rotation); // creates a copy of the particle system "splash" at hit position

                flowers[numFlowers] = Instantiate(flowerParent, pos, rotation); // moved from above Quaternion.identity
                
                flowers[numFlowers].transform.position = pos; //og

                flowers[numFlowers].transform.Translate(pos.x - Random.Range(0f,1f),pos.y,pos.z - Random.Range(0f,1f));

                flowers[numFlowers].SetActive(true);

                ColorSetter cs = flowers[numFlowers].GetComponentInChildren<ColorSetter>(true); 
                cs.SetColor(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));

                numFlowers = numFlowers + 1;
         
            
            }
        }
    }
}
