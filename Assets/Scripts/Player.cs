using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float cash;
	public float energy, food, study, society;
	public float perEnergy, perFood, perSociety;
	// Use this for initialization
	void Start () {
	}

	// Adding money to a player from: work, parents etc.
	public void AddMoney(float money){
		this.cash += money;
	}

	// Substract money from player
	public void SpendMoney(float money){
		this.cash -= money;
	}

	public void LifeLine(float hours){
		energy -= (perEnergy * hours);
		food -= (perFood * hours);
		society -= (perSociety * hours);
	}

	public void ResetStudy(){
		this.study = 0.0f;
	}

	public void Learn(float percent){
		study += percent;
	}

	public void Eat(float percent){
		this.food += percent;
	}

	public void Meeting(float percent){
		this.society += percent;
	}

}
