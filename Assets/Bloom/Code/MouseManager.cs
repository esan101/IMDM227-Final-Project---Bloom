using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    public GameObject cube;
    GameObject[] cubes;
    public int cubeLimit = 50;
    int numCubes = 0;
    void Start()
    {
        cubes = new GameObject[cubeLimit];
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
                Debug.Log($"Making a clone of {hit.collider.gameObject.name}");
                cubes[numCubes] = Instantiate(cube);
                ColorSetter cs = cubes[numCubes].GetComponent<ColorSetter>();
                cs.SetColor(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));

                // Spin spinCube = cubes[numCubes].GetComponent<Transform>();
                // spinCube.SpinCube(0,Random.Range(0f,1f) * Time.deltaTime, 0);
                // Spin spinCube = cubes[numCubes];
                // spinCube.SpineCube(0, Random.Range(0f,360f) * Time.deltaTime,0);

                Vector3 pos = hit.point;
                Debug.Log("hit.point: " + hit.point);

                pos.y = 1;

                
                // Instantiate(cube);
                cubes[numCubes].transform.position = pos;
                numCubes = numCubes + 1;
         
            
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
        for (int i = 0; i < numCubes; i++)
            {
                cubes[i].transform.Rotate(0, Random.Range(0f,360f) * Time.deltaTime,0);
                
            }
    }
}
