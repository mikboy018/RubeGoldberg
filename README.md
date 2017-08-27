# RubeGoldberg
Unity High Immersion Project 1 - Udacity VR Nanodegree
Developed for the HTC Vive Only.
Developed in Unity 5.51f1.

Uses:
1) Classic Skybox (Unity Store)
2) Eight-Ball Rack (Unity Store)
3) Fruit Pack (Unity Store)
4) Heavy Wrenches (Unity Store)
5) NewtonVR (Unity Store)
6) SteamVR (Unity Store)
7) COIN 3d model (https://free3d.com/3d-model/coin-4532.html)

Fixed two issues:

1 - Reviewer was able to scale walls. This is not a room-scale game. 
As such, I've created extra invisible walls to serve as additional barriers. 
As long as the player doesn't try to move too far left/right/etc, they will not be able to move through walls. 
I really wish we could have explored using the Vive-Teleport addon, as it is much nicer to use than the 
methods we were taught. https://github.com/Flafla2/Vive-Teleporter

2 - The player was able to just grab the ball and collect the objects. 
I fixed this by ensuring the player had to be in the starting boundary (or throw boundary) 
in order for the ball to score.


By: Mike Boyer

Find this project on Github! 
https://github.com/mikboy018/RubeGoldberg

Background:
This game starts in a simple world, where you can view each of the models you will be using in future levels (in the order you can cycle through them).

Upon a left trigger pull, you begin the first of four levels where you must collect both collectible objects, then reach the goal, without allowing the ball to hit the ground.

Bat frequency is adjusted by the blue lever, the further forward will make it swing more frequently.

Merry-Go-Round speed is adjusted by the green lever, the further forward the faster it will go!