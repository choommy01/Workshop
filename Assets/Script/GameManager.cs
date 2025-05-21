using UnityEngine;
using Cursor = UnityEngine.Cursor;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
      }
      else
      {
         Destroy(gameObject);
      }
   }

   public InventoryPanel inventoryPanel;

   public void OpenInventoryPanel()
   {
      inventoryPanel.gameObject.SetActive(true);
      inventoryPanel.OnOpen();
      Cursor.visible = true;
      Cursor.lockState = CursorLockMode.None;
      Time.timeScale = 0f;
   }

   public void CloseInventoryPanel()
   {
      inventoryPanel.gameObject.SetActive(false);
      Cursor.visible = false;
      Cursor.lockState = CursorLockMode.Locked;
      Time.timeScale = 1f;
   }

   public float timeCounter = 30f;
   public ItemData targetItem;
   public int targetAmout = 5;

   public TMP_Text timeCounterText;
   public Image targetItemIcon;
   public TMP_Text tarGetCurrentAmountText;

   public bool isPlayerWin = false;

   private void Start()
   {
      targetItemIcon.sprite = targetItem.itemIcon;
   }

   private void Update()
   {
      if (isPlayerWin)
         return;
         
      if (timeCounter > 0f)
      {
         timeCounter -= Time.deltaTime;
         timeCounterText.text = timeCounter.ToString();
         tarGetCurrentAmountText.text = "x " + (targetAmout - InventoryManager.instance.GetItemAmount(targetItem)).ToString();

         if (InventoryManager.instance.GetItemAmount(targetItem) >= targetAmout)//player win
         {
            Debug.Log("Player Win");
            isPlayerWin = true;
         }
      }
      else //player lose
      {
         SceneManager.LoadScene("MainMenu");
      }
   }
}
