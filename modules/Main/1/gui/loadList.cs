// Load all GUI scripts
exec("./guiprofiles.cs");   //  Need this to create GUI controls
exec("./guiControls.cs");

// TAML
TamlRead("./Dialogue.taml"); // Notice we are just reading in the Taml file, not adding it to the scene  