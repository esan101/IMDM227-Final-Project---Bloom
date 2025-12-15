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
    public ParticleSystem splash; // references particle system
    

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
                audioSource.pitch = Random.Range(0.8f, 1.2f); // randomizes pitch
                audioSource.PlayOneShot(clickSound); //sound should play when user clicks on screen
                Debug.Log($"Making a clone of {hit.collider.gameObject.name}");


                Vector3 pos = hit.point; // sets variable pos to be equal to where the mouse clicks on the plane
                Debug.Log("hit.point: " + hit.point);
                Quaternion rotation = Quaternion.Euler(0,0,0);
                Instantiate(splash, pos, rotation); // creates a copy of the particle system "splash" at hit position

                flowers[numFlowers] = Instantiate(flowerParent, pos, rotation); // moved from above Quaternion.identity

                flowers[numFlowers].transform.Translate(pos.x - (0.1f)*Random.Range(0f,1f),pos.y,pos.z - (0.1f)*Random.Range(0f,1f));

                flowers[numFlowers].SetActive(true);

                ColorSetter cs = flowers[numFlowers].GetComponentInChildren<ColorSetter>(true); //added "true"
                cs.SetColor(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));

                numFlowers = numFlowers + 1;
         
            
            }
        }
    }
}
