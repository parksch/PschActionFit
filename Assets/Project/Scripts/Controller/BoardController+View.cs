using UnityEngine;

public partial class BoardController
{
    [SerializeField] BoardView view;

    public ParticleSystem destroyParticlePrefab => view.DestroyParticle;

    public void InitializeView()
    {
        view.Init();
    }
}
