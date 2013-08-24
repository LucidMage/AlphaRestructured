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
   
   //	Set Starting Scene
   %startScene = testart;
   
   //	Setup Objectives
   %this.objective[0] = "Explore the town";
   %this.objective[1] = "Find the three gems";
   %this.currentObjective = 0;
   
   //SetScene(new Scene());
   //new ScriptObject("testtown");
   LoadScene(%startScene);
   CentreWindowOnSprite(Player);
   
   Canvas.pushDialog(InGameGUI);
}