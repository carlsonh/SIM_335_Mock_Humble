using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TrapBehaviour : MonoBehaviour
{
	[FormerlySerializedAs("trapType")] [SerializeField]
	private TrapTargetType trapTargetType;

	private Trap _trap;

	private void Awake()
	{
		_trap = new Trap();
	}

	private void OnTriggerEnter(Collider other)
	{
		var characterMover = other.GetComponent<IEntity>();
		_trap.HandleCharacterEntered(characterMover, trapTargetType);
	}
}

public enum TrapTargetType
{
	Player,
	Npc,
	Animal,
	Any
}

public class Trap
{
	public void HandleCharacterEntered(IEntity target, TrapTargetType trapTargetType)
	{
		switch (trapTargetType)
		{
			case TrapTargetType.Player:
				if (target.entityType == EntityType.Player)
				{
					Debug.Log("Damaged player");
					target.health--;
				}
				break;

			case TrapTargetType.Npc:
				if (target.entityType == EntityType.Npc)
				{
					Debug.Log("Damaged npc");
					target.health--;
				}
				break;

			case TrapTargetType.Animal:
				if (target.entityType == EntityType.Animal)
				{
					Debug.Log("Damaged Animal");
					target.health++;
				}
				break;
			case TrapTargetType.Any:
					Debug.Log("Damaged Anonymous");
					target.health--;
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(trapTargetType), trapTargetType, null);
		}
	}
}