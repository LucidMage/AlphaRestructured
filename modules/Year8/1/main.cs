function Year8::create( %this )
{
   exec("./lesson1/main.cs");
   
   %this.reset();
}

function Year8::destroy( %this )
{
}

function Year8::reset( %this )
{
   GameScene.clear();
   
   %currentLesson = new ScriptObject(Lesson1);
   //GameScene.add(%currentLesson);
   
   CentreWindowOnSprite(Player);
}