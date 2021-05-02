using UnityEngine;
using System.Collections;
using System;



namespace Pathfinding {
	/// <summary>
	/// Sets the destination of an AI to the position of a specified object.
	/// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
	/// This component will then make the AI move towards the <see cref="target"/> set on this component.
	///
	/// See: <see cref="Pathfinding.IAstarAI.destination"/>
	///
	/// [Open online documentation to see images]
	/// </summary>
	[UniqueComponent(tag = "ai.destination")]
	[HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		/// 


		private EnemyAttack enemy_attack;
		public Animator animator;
		[SerializeField]
		private bool patrol_horizontal = false;
		[SerializeField]
		private bool patrol_vertical = true;
		[SerializeField]
		private float stop_time = 4;
		private Transform player_transform;
		public float lookRadius = 10f;
		[SerializeField]
		private int patrol_range = 14;
		public Transform target;
		private Vector3 inicial_pos;
		private Vector3 patroling_pos;
		public Timer patrol_timer;
		public enemy_animator animations;
		private float closeToStop = 8.5f;
		private float movementSize = 1; // It's value are only 1 or -1, 
		private float maxSpeedAUX;
		IAstarAI ai;
		bool moving = true;
		Timer attack_preparation;
		public SoldierFieldOfView soldierView;
		void onDrawGizmosSelected()
		{

			Gizmos.color = Color.red;
			Gizmos.DrawSphere(transform.position, lookRadius);
		}

		void OnEnable() {
			ai = GetComponent<IAstarAI>();
			// Update the destination right before searching for a path as well.
			// This is enough in theory, but this script will also update the destination every
			// frame as the destination is used for debugging and may be used for other things by other
			// scripts as well. So it makes sense that it is up to date every frame.
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable() {
			if (ai != null) ai.onSearchPath -= Update;
		}


		void Start()
		{
			player_transform = GameObject.FindGameObjectWithTag("Player").transform;
			inicial_pos = transform.position;
			patroling_pos = inicial_pos;
			target = player_transform;
			patrol_timer = new Timer(stop_time);
			animations = gameObject.GetComponent<enemy_animator>();
			enemy_attack = gameObject.GetComponent<EnemyAttack>();
			attack_preparation = new Timer(0.4f);
			
		}
		private void AttackMode() {
			ai.destination = target.position;
		}
		private void Notmove()
		{

			AIPath aipath = gameObject.GetComponent<AIPath>();
			aipath.enabled = false;
			moving = false;


		}
		private void MoveAgain()
		{
			AIPath aipath = gameObject.GetComponent<AIPath>();
			aipath.enabled = true;
			moving = true;
		}
		private void FlipSize() {

			if (patrol_vertical)
			{
				inicial_pos.y = inicial_pos.y + (movementSize * patrol_range);
				movementSize = movementSize * -1;
				ai.destination = inicial_pos;
			}
			else if (patrol_horizontal)
			{
				inicial_pos.x = inicial_pos.x + (movementSize * patrol_range);
				movementSize = movementSize * -1;
				ai.destination = inicial_pos;
			}
		}

		private float Distance(Vector3 pos)
		{
			return (Math.Abs(pos.x - transform.position.x) + Math.Abs(pos.y - transform.position.y));
		}
		/// <summary>Updates the AI's destination every frame</summary>
		void Update() {
			// 
			if (target != null && ai != null)
			{

				if ((Distance(target.position) < lookRadius) && soldierView.SeeingEnemy())
				{
					//Must change if it was idle.
					animations.StopIdle();
					AttackMode();
					Debug.Log(Distance(target.position));
					//Check if we are so close to the Player that we have to stop. 

					// Range of attack 
					if (Distance(target.position) <= 3)
					{
						Notmove();
						animations.TurnSide(target.position);
						animations.StartReadyToAttack();
						if (attack_preparation.timeOver()) enemy_attack.attack();
					}

					// When the player is close, the enemy stops running and starts walking "OnGuard" 
					else if ((Distance(target.position) < closeToStop))
					{
						attack_preparation.setTimer();
						if (!moving) { MoveAgain(); }
						animations.TurnSide(target.position);
						animations.StartOnGuard();
					}
					// Range of start running
					else
					{
						if (!moving) { MoveAgain(); }
						animations.TurnSide(target.position);
						animations.StartRunning();
					}
				}
				else // Enemy can't see the player, so the enemy patrols
				{
					ai.destination = inicial_pos;
					if (Distance(inicial_pos) < 4)
					{
						animations.StartIdle();
						patrol_timer.setTimer(); // Only set if it wasn't set before.
												 //It's capable of start again when the time counter is equal to cero.    		
						if (patrol_timer.timeOver())
						{
							FlipSize();
							animations.StopIdle();
						}

					}
					else
					{
						animations.StartWalking();
					}
				}

			}
		}
	}
}



