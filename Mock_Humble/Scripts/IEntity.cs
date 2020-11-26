public interface IEntity
{
	int health { get; set; }
	EntityType entityType { get; }
	
}

public enum EntityType {Player, Npc, Animal }