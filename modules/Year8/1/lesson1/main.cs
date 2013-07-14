// Treat this as a class constructor for the lesson
function Lesson1::onAdd( %this )
{
   exec("./scenes/testtown.cs");
   exec("./scenes/garden.cs");
   
   %this.getClassName();
   
   //SetScene(new Scene());
   //new ScriptObject("testtown");
   CreateScene(testtown);
   CentreWindowOnSprite(Player);
}