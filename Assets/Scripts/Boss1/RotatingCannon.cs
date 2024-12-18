using UnityEngine;

public class RotatingCannon : MonoBehaviour
{
    float temp = 0;
    [SerializeField] float rotationPerSec;
    [SerializeField] GameObject bullet1;
    [SerializeField] float frequency;

    float timer;

    private void Start()
    {
        timer = 1 / frequency;
    }

    private void Update()
    {
        temp += rotationPerSec;
        temp %= 360;
        transform.rotation = Quaternion.Euler(0, 0, temp);

        timer -= Time.deltaTime;
        if (timer < 0 && fire)
        {
            var gg = Instantiate(bullet1, transform.position, Quaternion.identity);
            gg.GetComponent<EnemyBullet2>().SetSourceTransform(transform);
            timer = 1 / frequency;
        }

    }


    bool fire = false;
    public void StartFire()
    {
        fire = true;
    }

    public void StopFire()
    {
        fire = false;
    }

}
