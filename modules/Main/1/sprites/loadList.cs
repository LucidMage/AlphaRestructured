exec("./characters/loadList.cs"); // Load Characters
exec("./items/loadList.cs");   // Load Items
exec("./pushable.cs");   // Load Pushable

//	temporarily here
//$positionArray;	//	Holds sceneobject positions added via TMX
$positionArrayCount = 0;

function SavePosition(%position)
{
	//	A position must have a "Tag" field defined in the TMX taml
	if (%position.Tag !$= "")
	{
		$positionArray[$positionArrayCount] = %position;
		%output = $positionArray[$positionArrayCount].Tag SPC $positionArray[$positionArrayCount].getPosition();
		echo(%position SPC "Position" SPC $positionArrayCount SPC ":" SPC %output);
		$positionArrayCount++;
	}
	else
		echo("Tag empty");
}

function FindPosition(%scene, %tag)
{
	%name = %tag @ "Position";
	%obj = %scene.findObject(%name);
	%position = 0;	//	0 = no sceneobject set in TMX
	
	if (%scene != null)
		%position = %scene.getPosition();
/*
	for (%i = 0; %i < $positionArrayCount; %i++)
		if (%tag == $positionArray[%i].Tag)
			%position = $positionArray[%i];
	*/
	//	Check if position was found
	if (%position == 0)
	{
		error("Sprite Setup: Position not found");
		return 0;
	}
	else
		return %position.getPosition();
}

//	Class assigned to sprites defined in TMX taml
function StartPosition::onAddToScene(%this)
{
	SavePosition(%this);
}