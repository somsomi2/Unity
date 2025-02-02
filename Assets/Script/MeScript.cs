using UnityEngine;
using UnityEngine.Video;

public class MeScript : MonoBehaviour
{
    public AudioClip clip1, clip2;
    private AudioSource audioSource; 
    public VideoClip vclip1;
    private VideoPlayer videoPlayer;
    private GameObject videowall;

    public Material Todomet;
    public Material doit;
    private int youdidit = 0;
    float speed = 5.0f;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        videowall = GameObject.Find("Video wall(F)");
        videoPlayer = videowall.GetComponent<VideoPlayer>();

        GameObject[] Task = new GameObject[2244]; 
        int columns = 33; 
        float spacing = 1.5f; 
 
        for (int i = 0; i < Task.Length; i++)
        {
            Task[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            
           
            int row = i / columns; 
            int column = i % columns; 
            
            
            Task[i].transform.position = new Vector3(column * spacing - 24, 1, row * spacing - 62); 
            Task[i].name = "Todo_" + i.ToString(); 
            Task[i].GetComponent<Renderer>().material = Todomet;
            Task[i].AddComponent<Rigidbody>();
            Task[i].GetComponent<Rigidbody>().mass = 0.1f;

            if (i == 410 || i == 612 || i == 742 || i == 938 || i == 1266 || i == 1565 || i == 1800 || i == 2225)
            {
                Task[i].GetComponent<Renderer>().material = doit;
            }           
        }
    }

    void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = verticalInput * speed * Time.deltaTime;
        horizontalInput = horizontalInput * speed * Time.deltaTime;
        transform.Translate(Vector3.forward * verticalInput);
        transform.Translate(Vector3.right * horizontalInput);
        /*transform.Translate(0, 0, Input.GetAxis("Vertical") / 5.0f);
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);*/

    }

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.name == "Todo_410" || collision.gameObject.name == "Todo_612" ||
        collision.gameObject.name == "Todo_742" || collision.gameObject.name == "Todo_938" ||
        collision.gameObject.name == "Todo_1266" || collision.gameObject.name == "Todo_1565" ||
        collision.gameObject.name == "Todo_1800" || collision.gameObject.name == "Todo_2225")
    {
        youdidit++;

        if (youdidit >= 8)
        {
            audioSource.clip = clip2;
        }
        else
        {
            audioSource.clip = clip1;
        }

        audioSource.Play();
        Destroy(collision.gameObject);
    }

    if (collision.gameObject.name.Contains("Todo_2225"))
    {
        videowall.GetComponent<OpenScript>().youMakeit = true;

        videowall.GetComponent<VideoPlayer>().clip = vclip1;
        videowall.GetComponent<VideoPlayer>().Play();
    }
}

}

