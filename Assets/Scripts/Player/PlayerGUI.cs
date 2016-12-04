using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerGUI : MonoBehaviour
{
	public float maxHealth;
	public float maxStamina;
	public bool isDead = false;
    Vector2 size = new Vector2(240, 40);

    Vector2 healthPosition = new Vector2(20, 20);
	public float currentHealth = maxHealth;
    public Texture2D healthBarEmpty;
    public Texture2D healthBarFull;

    Vector2 staminaPosition = new Vector2(20, 60);
	public float currentStamina = maxStamina;
    public Texture2D staminaBarEmpty;
    public Texture2D staminaBarFull;

    void OnGUI()
    {
        //health GUI
        GUI.BeginGroup(new Rect(healthPosition.x, healthPosition.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), healthBarEmpty);

        GUI.BeginGroup(new Rect(0, 0, size.x * currentHealth, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), healthBarFull);

        GUI.EndGroup();
        GUI.EndGroup();

        //stamina GUI
        GUI.BeginGroup(new Rect(staminaPosition.x, staminaPosition.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), staminaBarEmpty);

        GUI.BeginGroup(new Rect(0, 0, size.x * currentStamina, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), staminaBarFull);

        GUI.EndGroup();
        GUI.EndGroup();

    }

	public void TakeDamage(float dmg){
		currentHealth -= dmg;

		if (currentHealth <= 0 && isDead != true) {
			isDead = true;
			CharacterDeath ();
		}
	}

	public void GainStamina(float staminaRate){
		currentStamina += staminaRate;
	}

	public void LoseStamina(float staminaRate){
		currentStamina -= staminaRate;
	}

	void CharacterDeath()
	{
		LevelLoader.loadLevel("Level_01");
	}

	void SetActiveState(bool state){
		//Disable components of character
		//Rather than simply deleting the entire object we want to store the character data
	}

	public void Reset(){
		currentHealth = maxHealth;
		currentStamina = maxStamina;
		SetActiveState (true);
		isDead = false;
	}

}
