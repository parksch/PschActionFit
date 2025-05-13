using UnityEngine;

public partial class StageEditorManager
{
    [SerializeField] Camera target;
    [SerializeField] Vector3 defaultVec3 = new Vector3(0, 10, 0);
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float defaultSize = 6;
    [SerializeField] float minSize;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            target.transform.position = defaultVec3;
            target.orthographicSize = defaultSize;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0 || scroll < 0)
        {
            target.orthographicSize -= scroll;

            if (target.orthographicSize < minSize)
            {
                target.orthographicSize = minSize;
            }
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0 || vertical != 0)
        {
            Vector3 pos = new Vector3(0, 0, 0);
            pos.x += horizontal;
            pos.z += vertical;
            target.transform.position += Time.deltaTime * pos * moveSpeed;
        }




    }
}
