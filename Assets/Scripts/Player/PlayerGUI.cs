using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerGUI : MonoBehaviour
{

    Vector2 size = new Vector2(240, 40);

    Vector2 healthPosition = new Vector2(20, 20);
    float healthBarDisplay = 1;
    public Texture2D healthBarEmpty;
    public Texture2D healthBarFull;

    Vector2 hungerPosition = new Vector2(20, 60);
    float hungerBarDisplay = 1;
    public Texture2D hungerBarEmpty;
    public Texture2D hungerBarFull;

    Vector2 thirstPosition = new Vector2(20, 100);
    float thirstBarDisplay = 1;
    public Texture2D thirstBarEmpty;
    public Texture2D thirstBarFull;

    Vector2 staminaPosition = new Vector2(20, 140);
    float staminaBarDisplay = 1;
    public Texture2D staminaBarEmpty;
    public Texture2D staminaBarFull;

    int healthFallRate = 150;
    int hungerFallRate = 150;
    int thirstFallRate = 100;
    int StaminaFallRate = 35;

    private FirstPersonController fpsController;
    private CharacterController controller;

    bool canJump = false;

    private LevelLoader levelLoader;

    public float StaminaBarDisplay
    {
        get
        {
            return staminaBarDisplay;
        }

        set
        {
            staminaBarDisplay = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        fpsController = GetComponent<FirstPersonController>();
        controller = GetComponent<CharacterController>();
        levelLoader = FindObjectOfType<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        GuiControls();
    }

    void OnGUI()
    {

        //health GUI
        GUI.BeginGroup(new Rect(healthPosition.x, healthPosition.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), healthBarEmpty);

        GUI.BeginGroup(new Rect(0, 0, size.x * healthBarDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), healthBarFull);

        GUI.EndGroup();
        GUI.EndGroup();

        //hunger GUI
        GUI.BeginGroup(new Rect(hungerPosition.x, hungerPosition.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), hungerBarEmpty);

        GUI.BeginGroup(new Rect(0, 0, size.x * hungerBarDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), hungerBarFull);

        GUI.EndGroup();
        GUI.EndGroup();

        //thirst GUI
        GUI.BeginGroup(new Rect(thirstPosition.x, thirstPosition.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), thirstBarEmpty);

        GUI.BeginGroup(new Rect(0, 0, size.x * thirstBarDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), thirstBarFull);

        GUI.EndGroup();
        GUI.EndGroup();

        //stamina GUI
        GUI.BeginGroup(new Rect(staminaPosition.x, staminaPosition.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), staminaBarEmpty);

        GUI.BeginGroup(new Rect(0, 0, size.x * staminaBarDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), staminaBarFull);

        GUI.EndGroup();
        GUI.EndGroup();

    }

    void GuiControls()
    {
        if (healthBarDisplay <= 0 && thirstBarDisplay <= 0)
        {
            healthBarDisplay -= Time.deltaTime / healthFallRate * 2;
        }
        else if (hungerBarDisplay <= 0 || thirstBarDisplay <= 0)
        {
            healthBarDisplay -= Time.deltaTime / healthFallRate;
        }

        if (healthBarDisplay <= 0)
        {
            CharacterDeath();
        }

        if (hungerBarDisplay >= 0)
        {
            hungerBarDisplay -= Time.deltaTime / hungerFallRate;
        }

        if (hungerBarDisplay <= 0)
        {
            hungerBarDisplay = 0;
        }

        if (hungerBarDisplay >= 1)
        {
            hungerBarDisplay = 1;
        }

        if (thirstBarDisplay >= 0)
        {
            thirstBarDisplay -= Time.deltaTime / thirstFallRate;
        }

        if (thirstBarDisplay <= 0)
        {
            thirstBarDisplay = 0;
        }

        if (thirstBarDisplay >= 1)
        {
            thirstBarDisplay = 1;
        }

        if (controller.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            fpsController.RunSpeed = 10;
            staminaBarDisplay -= Time.deltaTime / StaminaFallRate;
        }
        else
        {
            fpsController.WalkSpeed = 6;
            staminaBarDisplay += Time.deltaTime / StaminaFallRate;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
        {
            staminaBarDisplay -= 0.2f;
            Wait();
        }

        if (canJump == false)
        {
            fpsController.Jump = false;
        }

        if (controller.isGrounded)
        {
            canJump = true;
        }

        if (staminaBarDisplay <= 0.2)
        {
            canJump = false;
            fpsController.Jump = false;
            fpsController.RunSpeed = fpsController.WalkSpeed;
        }

        if (staminaBarDisplay >= 1)
        {
            staminaBarDisplay = 1;
        }

        if (staminaBarDisplay <= 0)
        {
            staminaBarDisplay = 0;
            fpsController.RunSpeed = 6;
        }
    }

    void CharacterDeath()
    {
        LevelLoader.loadLevel("Level_01");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        canJump = false;
    }
}
