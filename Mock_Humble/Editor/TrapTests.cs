using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;


public class TrapTests 
{

    [Test]
    //NPC in all trap types
    [TestCase(EntityType.Npc, TrapTargetType.Npc, -1)]
    [TestCase(EntityType.Npc, TrapTargetType.Player, 0)]
    [TestCase(EntityType.Npc, TrapTargetType.Animal, 0)]
    
    //Player in all trap types
    [TestCase(EntityType.Player, TrapTargetType.Npc, 0)]
    [TestCase(EntityType.Player, TrapTargetType.Player, -1)]
    [TestCase(EntityType.Player, TrapTargetType.Animal, 0)]
    
    //Animal in all trap types
    [TestCase(EntityType.Animal, TrapTargetType.Npc, 0)]
    [TestCase(EntityType.Animal, TrapTargetType.Player, 0)]
    [TestCase(EntityType.Animal, TrapTargetType.Animal, -1)]
    
    //All entities in "Any"
    [TestCase(EntityType.Npc, TrapTargetType.Any, -1)]
    [TestCase(EntityType.Player, TrapTargetType.Any, -1)]
    [TestCase(EntityType.Animal, TrapTargetType.Any, -1)]
    public void EnttiyEntering_TargetedTrap_ChangesHealth(EntityType entityType, TrapTargetType trapTargetType, int expectedHealthChange)
    { 
        //Arrange
        var trap = new Trap(); 
        var player = Substitute.For<IEntity>();
        player.entityType.Returns(entityType);
        var startingHealth = player.health;
        Debug.Log("Testing " + entityType + " in " + trapTargetType + " trap with expected health change " + expectedHealthChange);

        //Act
        trap.HandleCharacterEntered(player, trapTargetType);
        
        //Assert
        Assert.AreEqual(expectedHealthChange, player.health - startingHealth);
    } 
    
    
    
}
