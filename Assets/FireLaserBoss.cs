using UnityEngine;

public class FireLaserBoss : MonoBehaviour
{
    RaycastHit2D hit;
    LayerMask mask;
    LineRenderer lineRenderer;
    public GameObject hitEffect;
    ParticleSystem particleSystem;

    [SerializeField] LaserState laserState;
    void Start()
    {
        mask = LayerMask.GetMask("Player");
        lineRenderer = GetComponent<LineRenderer>();
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Stop();
    }
    void Update()
    {
        switch (laserState)
        {
            case (LaserState.Loading):
                particleSystem.Play();
                break;

            case (LaserState.Fire):
                FireLaser();
                break;

            case (LaserState.CoolDown):
                particleSystem.Stop();
                lineRenderer.positionCount = 0;
                break;
        }

    }

    void FireLaser()
    {
        lineRenderer.positionCount = 2;
        Debug.Log(transform.up);
        hit = Physics2D.Raycast(transform.position, transform.up, 35, mask);

        if (hit.collider != null)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
            var effect = Instantiate(hitEffect, hit.point, Quaternion.identity);

        }

        else
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position + transform.up * 35);
        }
    }

    public void ChangeLaserState(LaserState s)
    {
        laserState = s;
    }

}



public enum LaserState
{
    Loading,
    Fire,
    CoolDown
}
