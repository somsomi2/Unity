using UnityEngine;

public class OpenScript : MonoBehaviour
{
    public bool youMakeit = false;
    void Update()
    {
        if (youMakeit)
        {
            float myAngle = transform.eulerAngles.y;
            if (myAngle <= 360)
            {
                myAngle += 0;
            }

            if (myAngle < 180)
            {
                gameObject.transform.Rotate(0, 0.02f, 0);
            }
        }
    }
}