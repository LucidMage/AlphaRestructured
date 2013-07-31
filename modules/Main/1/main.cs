//  Code called when program starts
function Main::create( %this )
{
   %this.loadPreferences();
   
   // Load Main Scripts
   exec("./global.cs"); // Global Values
   exec("./console.cs");   // Console
   exec("./activity/loadList.cs");  // Load Activity Scripts
   exec("./behaviours/loadList.cs");   // Load Behaviours
   exec("./sprites/loadList.cs");   // Load Sprites

   //exec("./scenewindow.cs");
   exec("./inventory.cs");
   
   //  Load GUI Profiles
   exec("./gui/loadList.cs");   //  Load GUI Scripts

   CreateSceneWindow();
	
	// Load and configure the console.	exec("./scripts/console.cs");  
	TamlRead("./gui/ConsoleDialog.gui.taml"); // Notice we are just reading in the Taml file, not adding it to the scene  
	GlobalActionMap.bind( keyboard, "tilde", toggleConsole );   // Press '`' to open console
    
    // Load and configure the toolbox.
    //Main.add( TamlRead("./gui/ToolboxDialog.gui.taml") );
    
    ScanForYearGroups();
    //LoadActivity("Year8");

   //  Debug
   //  Enable visualization for "collision", "position", and "aabb"
   %scene = GameWindow.getScene();
   %scene.setDebugOn("collision", "position", "aabb");
   
   // Initialize the "cannot render" proxy.
   new RenderProxy(CannotRenderProxy)
   {
      Image = "Assets:CannotRender";
   };
   Main.add( CannotRenderProxy );
}

//  Code called when program ends
function Main::destroy( %this )
{
    destroySceneWindow();
}

function Main::loadPreferences( %this )
{
   // Load the default preferences.
   //exec( "./defaults.cs" );
   
   // Load the last session preferences if available.
   if ( isFile("preferences.cs") )
      exec( "preferences.cs" );   
}