using UnityEngine;

public partial class BoardController
{
    [SerializeField] BoardView view;

    public ParticleSystem destroyParticlePrefab => view.DestroyParticle;

    public void InitializeView()
    {
        view.Init();
    }

    public Material GetTargetMaterial(int index)
    {
        return view.WallMaterials[index];
    }
}
