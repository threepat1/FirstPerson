
using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField]
    Behaviour[] componentsToDisable;
    string remoteLayerName = "RemotePlayer";
    Camera sceneCam;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponent();
            AssignRemoteLayer();
        }
        else
        {
            sceneCam = Camera.current;
            if (sceneCam != null)
            {
                sceneCam.gameObject.SetActive(false);
            }
        }

        void AssignRemoteLayer()
        {
            gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
        }
        void DisableComponent()
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                componentsToDisable[i].enabled = false;
            }
        }
    }

    private void OnDisable()
    {
        if (sceneCam != null)
        {
            sceneCam.gameObject.SetActive(true);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
