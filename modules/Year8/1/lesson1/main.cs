// Treat this as a class constructor for the lesson
function Lesson1::onAdd( %this )
{
   // Load Scenes
   exec("./scenes/testtown.cs");
   exec("./scenes/garden.cs");
   
   CreateScene(testtown);
   CreateScene(garden);
   
   %startScene = testtown;
   
   //SetScene(new Scene());
   //new ScriptObject("testtown");
   LoadScene(%startScene);
   CentreWindowOnSprite(Player);
}