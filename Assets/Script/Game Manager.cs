using Unity.Netcode;
using UnityEngine;

public class NetworkLevelManager : NetworkBehaviour
{
  [Header("Levels")]
  public GameObject level0;
  public GameObject level1;
  public GameObject level2;
  public GameObject level3;

  [Header("Pause Board & Pointer")]
  public GameObject pauseBoard;
  public GameObject rightPointer;

  void Start()
  {
    if (IsServer)
      SwitchLevelServerRpc(0);
  }
  public override void OnNetworkSpawn()
  {
    base.OnNetworkSpawn();

    if (IsServer)
    {
      // 一開始只啟動 Lv0
      ActivateLevel(0);
      // 廣播給所有 client
      SwitchLevelClientRpc(0);
    }
  }


  public void RequestSwitchLevel(int lv)
  {
    // Client 呼叫 → Server RPC
    if (!IsServer)
      SwitchLevelServerRpc(lv);
    else
      ActivateLevel(lv);
  }

  [Rpc(SendTo.Server, InvokePermission = RpcInvokePermission.Everyone)]
  void SwitchLevelServerRpc(int lv)
  {
    ActivateLevel(lv);
    SwitchLevelClientRpc(lv);   // 廣播給所有 client
  }

  [ClientRpc]
  void SwitchLevelClientRpc(int lv)
  {
    ActivateLevel(lv);
  }

  void ActivateLevel(int lv)
  {
    pauseBoard.SetActive(lv != 0);
    rightPointer.SetActive(lv == 0);
    level0.SetActive(lv == 0);
    level1.SetActive(lv == 1);
    level2.SetActive(lv == 2);
    level3.SetActive(lv == 3);
  }
}
