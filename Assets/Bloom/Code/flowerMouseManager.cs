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
            // look at name of gameobject, if gameobject name = background then 
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
                //flowers[numFlowers] = Instantiate(flower); //original
                //flowers[numFlowers] = Instantiate(flower); //added
                //flowers[numFlowers].SetActive(true); //added

                //ColorSetter cs = flowers[numFlowers].GetComponent<ColorSetter>(); //og
                //cs.SetColor(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f)); //og

                // flowers[numFlowers] = Instantiate(flower);

                // set position BEFORE enabling
                //flowers[numFlowers].transform.position = pos; //og

                // now enable it
                //flowers[numFlowers].SetActive(true);

                //ColorSetter cs = flowers[numFlowers].GetComponent<ColorSetter>();
                //cs.SetColor(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));

                // Spin spinCube = cubes[numCubes].GetComponent<Transform>();
                // spinCube.SpinCube(0,Random.Range(0f,1f) * Time.deltaTime, 0);
                // Spin spinCube = cubes[numCubes];
                // spinCube.SpineCube(0, Random.Range(0f,360f) * Time.deltaTime,0);

                Vector3 pos = hit.point;
                Debug.Log("hit.point: " + hit.point);
               // pos.y = 1;
                
                // Instantiate(cube);
                Quaternion rotation = Quaternion.Euler(0,0,0);
                Instantiate(splash, pos, rotation);

                flowers[numFlowers] = Instantiate(flowerParent, pos, rotation); // moved from above Quaternion.identity
                
                flowers[numFlowers].transform.position = pos; //og

                //flowers[numFlowers].transform.Translate(pos.x - (0.1f)*Random.Range(0f,1f),pos.y,pos.z - (0.1f)*Random.Range(0f,1f));

                flowers[numFlowers].SetActive(true);

                ColorSetter cs = flowers[numFlowers].GetComponentInChildren<ColorSetter>(true); 
                cs.SetColor(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));

                numFlowers = numFlowers + 1;
         
            
            }
        // for (int i = 0; i < numCubes; ++i)
        // {
        //     float r = Random.Range(0f,255f);
        //     float g = Random.Range(0f,255f);
        //     float b = Random.Range(0f,255f);
        //     ColorSetter scn = cubes[i].GetComponent<ColorSetter>();
            
        //     scn.SetColor(r,g,b);


            // getcomponentsinchildren for cubes
            // or add to interface?
            
            // trying to scale the cube so it disappears
            // cubes[i].transform.localScale = new Vector3(1,1,1);
            // if (cubes[i].transform.localScale.y > 0)
            // {
            //     cubes[i].transform.localScale = new Vector3(1,0,1);
            //     Debug.Log ("aahhhahahah: " + cubes[i].transform.localScale);

            //     if (cubes[i].transform.localScale.y < 0)
            //     {
            //         cubes[i].transform.localScale = new Vector3(0,0,0);
            //     }
            // }
            

            
            
            // possibility for later: have each instance of the cube spin at different rates
        }
        // for (int i = 0; i < numFlowers; i++)
        //     {
        //         flowers[i].transform.Rotate(0, Random.Range(0f,360f) * Time.deltaTime,0);
                
        //     }
    }
}
