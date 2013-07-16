function createProfile()
{
   // Create Player Character
   %player = new CompositeSprite()
   {
   };
   
   %profile = new ScriptObject()
   {
      name = "Test";
      password = "guest";
      year = 8;
      gender = "male";
      character = %player;
   };
}