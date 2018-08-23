# GreyArea

The core mechanics of this game are moving & attacking. Moving includes left & right, jump, double jump  & the stealth strategy. Attacking is limited to shooting & pushing in this prototype but that could be extended more if future iterations. Currently the game has no "end" as there is just one level, so players just die & respawn. Ultimately each player would have a set number of lives & one player would be the winner once they defeat the other player & they would return to the level select menu. 

This prototype only shows one level, but the idea is that the players could choose from a series of different levels, with different light/darnkess combinations & different layouts (think Starwhal), even with the possibility of a level creator. When creating the level I just watned an approximately even amount of black/what space, & lots of platforms all ranging in distance & size. Of course for other levels we could experiment with things like having only one or two platforms for mode combat heavy playing, or even a maze like level where stealth is more important. This is a multiplayer game so no level progression as such, but the players could progress through the game by unlocking outfits, weapons, new maps etc. 


The main scripts are the two player scrips, they control all of the movement, shooting & spawning of players, but the bullets have their own script. There is also a script for each powerup, & one for the shadows which has methods that are called/triggered by the powerup scripts in order to change the background. 

Character movement was coded by me in the player scripts rather than using Unity's vector physics as I find this gives more freedom. Build in gravity is used though, but increased significantly. It probably would have been better to make one player class & have two player objects, but I wanted the freedom to have each player have unique abilities, eg black is more defensive but shoots slower & white takes more damage but has a rapid fire. In the end though, I decided for the prototype the players should be uqual, so there isn't too much point in having two scripts. 

Each powerup also has a separate script as even though the current two power ups are similar, each other one would probably be more different so I thought it made sense to create them all separately & then they can be stored in a data structure & chosen to spawn at random. 

The most interesting part of the prototype for me was coding the function to make sure players could jump off one side of the screen & appear on the other. This is something i've never done before in Unity so it was pretty interesting, particularly when I found out about a Unity method called OnBecameInvisible() . I found the most efficient way to do it was to convert world positon to viewport position (ranging 0-1 on x & y axis) & just check which way it went out after OnBecameInvisible was called. This did make it a little tricky to test as I couldn't see the characters when they were invisible obviously, so I had to debug by watching the X & Y positions in the inspector. 

POWERUPS
Powerups are shown by pressing P. Obviously in the final game these would appear randomly throughout the level, but for protorype purposes they are just triggered on cue.
Also they are both the same shape as I'm not getting marked to make assets!
Left powerup is "disco", this can also be activated by pressing O if you're just in a boogie mood.
Right powerup just inverts the background colours once.
Originally there was a powerup that inverted the other playes controls, but when playtesting this turned out to be too difficult.
In future iterations, there will be more powerups for different weapons, abilities, & disabilites to the opponent. 

MOVEMENT
P1 WAD to move, Q to , S to show (turn grey)
P2 arrows to move, /? to shoot, down to show (turn grey)
You can jump off one side of the screen & appear on the other, but falling down the gaps in the floor will result in death (respawn)
(Make sure game is always in 16:9)

Each player gets 10 health (called lives in the script), but they're pretty glitchy (you hit yourself sometimes, or do double damage to opponent) this is the one thing I would have liked to have refined further.

All assets made by me.
See moodboard for the kind of art I would like to implement further! 
