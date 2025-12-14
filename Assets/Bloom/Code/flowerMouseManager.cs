using UnityEngine;
using UnityEngine.InputSystem;

public class flowerMouseManager : MonoBehaviour
{
    public GameObject flower;
    GameObject[] flowers;
    public int flowerLimit = 50;
    int numFlowers = 0;

    //add music
    public AudioClip clickSound;
    AudioSource audioSource;

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
                audioSource.pitch = Random.Range(0.8f, 1.2f);
                audioSource.PlayOneShot(clickSound); //sound should play when user clicks on screen
                Debug.Log($"Making a clone of {hit.collider.gameObject.name}");
                flowers[numFlowers] = Instantiate(flower);
                ColorSetter cs = flowers[numFlowers].GetComponent<ColorSetter>();
                cs.SetColor(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));

                // Spin spinCube = cubes[numCubes].GetComponent<Transform>();
                // spinCube.SpinCube(0,Random.Range(0f,1f) * Time.deltaTime, 0);
                // Spin spinCube = cubes[numCubes];
                // spinCube.SpineCube(0, Random.Range(0f,360f) * Time.deltaTime,0);

                Vector3 pos = hit.point;
                Debug.Log("hit.point: " + hit.point);

                pos.y = 1;

                
                // Instantiate(cube);
                flowers[numFlowers].transform.position = pos;
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
        for (int i = 0; i < numFlowers; i++)
            {
                flowers[i].transform.Rotate(0, Random.Range(0f,360f) * Time.deltaTime,0);
                
            }
    }
}
