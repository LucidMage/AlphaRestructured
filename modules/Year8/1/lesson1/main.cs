// Treat this as a class constructor for the lesson
function Lesson1::onAdd( %this )
{
   // Load Scenes
   exec("./scenes/testtown.cs");
   exec("./scenes/garden.cs");
   exec("./scenes/testart.cs");
   
   //CreateScene(testtown);
   //CreateScene(garden);
   //CreateScene(testart);
   
   %startScene = testart;
   
   //SetScene(new Scene());
   //new ScriptObject("testtown");
   LoadScene(%startScene);
   CentreWindowOnSprite(Player);
}