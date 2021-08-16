using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using Assert = UnityEngine.Assertions.Assert;

public class GameTest
{
    /* VERY IMPORTANT. UNIT TESTING DOES NOT WORK WITH PRIVATE ACCESSER
      And for this example in particular, it must return a game object.
      If you find it's not working, try putting in "return gameobject" into your method
      where gameObject is whatever you're trying to instantiate.
      
      The cool thing is, to make things even simpler,
        You coould just use a script that references all your other  scripts in one script
        You just have to remember to go Game.enemyspawner.MethodName()
        And that should do wonders for testing
        
        So when you do this, make sure where your gameassembly defimtion is,
        it should be in the location of your scripts?
        
        at the end of the method of which you want to return a game object
        should return gameObjectName not work.
        use return gameObjectName.gameobject
        
        */

    // set up.teardown phase
    // everytime we run the test, it runs set up first, like awake or start in unity.
   
    public TheGameScript tGS;
    public PlayerController pControl;
    public GUIManager guiManager;
    public EnemySpawner eSpawn;
    public Enemy enemy;// they're aight.
    public GameData gData;
    
    [SetUp]
    public void Setup()
    {
        GameObject gameGo = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/Game"));
        GameObject eSpawn = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefab/Game"));

        //gameGo = tGS.GetComponent<asteroid>();

    }

    // at the end of the test you do this function
    [TearDown]
    public void TearDown()
    {
        Object.Destroy(tGS.gameObject);
        
    }


    //public EnemySpawner enemySpawner = MonoBehaviour.Instantiate(Resources.Load< EnemySpawner>("Prefabs/Enemy"));

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator AstoroidSpawner()
    { // the way i did it was different to Andrews, he allocated one script to reference everything where as this is only doing one scene

        bool spawned;

        // Instantiates based on the directory of the prefab
        // you want to spawn in? Unity doesn't include that thing if it isn't existing in the scene somewhere
        // get a resources folder for things that you don't want to reference?
        // Folder itself isn't special, but Resources dot load is a special application of Resources.
        // Long story short, just make a rsources folder, use .load <> with the object in mind,
        // followed by setting the path > "folder it's located in / asset
        // eg "prefabs/enemy

        EnemySpawner enemySpawner = MonoBehaviour.Instantiate(Resources.Load < EnemySpawner > ("Prefab/EnemySpawner"));
        
        
        // * graba reference to the asteroid itself
        //GameObject gameGo = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        //it may also be beneficial to load the class itself.
        // where game GO is whatever game object you want to test.
        
        
        GameObject asteroid = enemySpawner.Spawning();
        
        
        //gameGo.GetComponent<Camera>();
        //enemySpawner.Spawning();
        
        // testing position
        
        
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        //the game will wait for the time alloted usually by the yield finction.
        
        yield return new WaitForSeconds(2);
        
        //you have to use this below because it will get confused with C#'s assert, so you use this and 
        // refer it to the thing you want to test,
        // * tests if it exits
        UnityEngine.Assertions.Assert.IsNull(asteroid);
        //assert is what you want to actually test the stuff.
        
        //good habit
        Object.Destroy(asteroid);
        
        // assert.ISnull is different and don't do it for this part.



    }
    
    //this type of testing is intergration testing. 
    [UnityTest]
    public IEnumerator HitDetection()
    {
        GameObject asteroid = tGS.enemySpawner.Spawning();
        asteroid.transform.position = tGS.playerController.gameObject.transform.position;
        yield return new WaitForSeconds(3);
        Assert.IsTrue(tGS);
        Object.Destroy(asteroid);

    }
    

}


/*
 *        // Instantiates based on the directory of the prefab
        // you want to spawn in? Unity doesn't include that thing if it isn't existing in the scene somewhere
        // get a resources folder for things that you don't want to reference?
        // Folder itself isn't special, but Resources dot load is a special application of Resources.
        // Long story short, just make a rsources folder, use .load <> with the object in mind,
        // followed by setting the path > "folder it's located in / asset
        // eg "prefabs/enemy
        
        // * graba reference to the asteroid itself
        //GameObject gameGo = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        EnemySpawner enemySpawner = MonoBehaviour.Instantiate(Resources.Load<EnemySpawner>("Prefabs/Game"));
        //it may also be beneficial to load the class itself.
        // where game GO is whatever game object you want to test.
        GameObject asteroid = enemySpawner.Spawning();
        
        //enemySpawner = gameGo.GetComponent<EnemySpawner>();
        //gameGo.GetComponent<Camera>();
        
        
        //enemySpawner.Spawning();
        
        // testing position
        float gameOBJ = gameGo.transform.position.y;
        
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        //the game will wait for the time alloted usually by the yield finction.
        
        yield return new WaitForSeconds(5);
        
        //you have to use this below because it will get confused with C#'s assert, so you use this and 
        // refer it to the thing you want to test,
        // * tests if it exits
        UnityEngine.Assertions.Assert.IsNull(gameGo);
        //assert is what you want to actually test the stuff.

        // good practice to destroy on exit
        Object.Destroy(gameGo.gameObject);

 *
 * 
 */





/*    
  You don't need this c# test area.  
    // A Test behaves as an ordinary method
    [Test]
    public void GameTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }
*/