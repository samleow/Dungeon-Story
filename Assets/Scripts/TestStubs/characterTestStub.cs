using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class NewBehaviourScript : MonoBehaviour
{

    Character character = new Character();

    int test_healthmax = 5;
    int test_healthcurrent = 1;
    int test_attack = 1;
    string test_classname = "testclass";
    string test_description = "testdescription";

            void Start()
    {
        character.health_max = test_healthmax;
        character.health_current = test_healthcurrent;
        character.attack = test_attack;
        character.description = test_description;
        character.class_name = test_classname;
        checkAssert();
    }

    void checkAssert(){
        Assert.AreEqual(test_healthmax, character.health_max);
        Assert.AreEqual(test_healthcurrent, character.health_current);
        Assert.AreEqual(test_attack, character.attack);
        Assert.AreEqual(test_classname, character.class_name);
        Assert.AreEqual(test_description, character.description);
        
    }

}
