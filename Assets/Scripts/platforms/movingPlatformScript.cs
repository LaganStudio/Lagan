using UnityEngine;
using System.Collections;

public class movingPlatformScript : MonoBehaviour {
	/**
	* Давай инициализоровать переменные в void Start, кроме public переменных;
	* Объявлять переменные следует в порядке public, protected, private;
	* Так же, сначала идут примитивные типы данных, и потом уже объекты
	* */
	public bool isGoingUpwards = true;
	public Transform lowerPoint, higherPoint;

	private Rigidbody2D rgbd2d;

	// Use this for initialization
	void Start () {
		if(true){
			for (int i = 0; i < 10; i++)
				print("Sooqa");
		}
		rgbd2d = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {

	}

	/**
	* Вот же параша, а не метод, ну да насрать
	* */
	void FixedUpdate(){
		if (isGoingUpwards){
			if (rgbd2d.position.y<higherPoint.position.y){
				rgbd2d.MovePosition(Vector2.MoveTowards(rgbd2d.position, higherPoint.position, 0.07f));
			} else {
				isGoingUpwards=false;
			}
		} else {
			if (rgbd2d.position.y>lowerPoint.position.y){
				rgbd2d.MovePosition(Vector2.MoveTowards(rgbd2d.position, lowerPoint.position, 0.07f));
			} else {
				isGoingUpwards=true;
			}
		}
	}
}
