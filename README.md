# MiniStruckd
 This is a small game editor and player built with Unity.


# Builds
- [Android (.apk)](https://github.com/TheEdgeWalker/MiniStruckd/blob/main/UnityTrial.apk)


# Edit Mode
## Top Buttons
### Pick City
 Pick a city to simulate the time and weather in Play Mode.
### AddObject
A Object Picker popup will appear. Choose an object to bring into the game.
### Undo
You can undo the following actions: Add, Remove, Move, Scale, Rotate.
### Play
 Start Play mode. Play mode will NOT start until a city and player GameObject has been chosen.
## Bottom Left
### Camera Joysticks
 You can manipulate the camera position.
 2D Joystick: X, Z axis movement.
 Vertical Joystick: Y axis movement.
## Bottom Right
### Selected Object Joysticks
 You can manipulate the positon, scale, rotation.
 2D Joystick: X, Z axis movement.
 Vertical Joystick: Scale Up/Down.
 Horizontal Joystick: Rotate Left/Right.
### Remove
 'Removes' the selected GameObject from the scene.
### Player Toggle
 Sets the GameObject as the 'Player'.


# Play Mode
## Bottom Left
 You can use the joystick to control the GameObject you have set as the Player.
## Weather System
 If it is raining or snowing in the city you have chosen, rain or snow particle emitters will be attached on top of the player GameObject!


# TODO
- Save/Load system.
  - Serialization/Deserialization of Scene?

# External Libraries
- GraphQL: https://github.com/gazuntype/graphQL-client-unity
- Icons: https://assetstore.unity.com/packages/2d/gui/icons/icons-set-58217
- Models: https://assetstore.unity.com/?q=Supercyan
- Joystick: https://assetstore.unity.com/packages/tools/input-management/joystick-pack-107631
- Weather Effects: https://assetstore.unity.com/packages/tools/particles-effects/time-of-day-weather-system-40374
