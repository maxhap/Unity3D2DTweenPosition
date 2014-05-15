Unity3D2DTweenPosition
======================

Unity3D 2D TweenPosition with phyics

#Features
1. Allows for linked movements in different directions
2. Reacts to other game objects using Unity3D RigidBody2D and Physics2D material 

Project contains a short demo of how to implement a TweenScript that uses the RigidBody2D physics to effect other game objects.
This can be used for effectly similar to; a moving platform or object projectile

Proect setup for moving platform
In order to use the script in your project complete the following steps;

1. Add the script to your Unity3D project
2. Add floor Game Object
3. Add Other Game Object
2. Add a Collider and RigidBody2D to the floor object and Other Game Objects 
3. Set the Floor objects RigidBody2D as Kinematics 
4. Create a Physics2D Material and assign it to the Floor Objects Collider matterial 
5. Add the TweenPosition2D Script to the floor as a componenet in the editor
6. Under the TweenPosition2D tab of the floors Inspector increase Array size to desired movement lengths
7. If you want to loop the tween then enable loop 
8. Enable play on start to start the animation when the obejct is created

#Note
Your first position in the position array will probably be the objects current position in the editor, not the first position to tween to.
