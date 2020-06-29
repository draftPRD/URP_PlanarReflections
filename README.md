<p align="center"><img width=12.5% src="https://github.com/anfederico/Clairvoyant/blob/master/media/Logo.png"></p>

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](https://opensource.org/licenses/MIT)

## Planar Reflections in Unity's URP

Full .unitypackage here: https://github.com/Macleodsolutions/URP_PlanarReflections/releases/download/v0.2/URP_PlanarReflections.unitypackage
<br>
<br>
Requires Entities Package.
<br>
<br>
FAST, easy to use planar reflections for Unity's Universal Render Pipeline.
Example scenes provided demonstrate ShaderGraph setup and Min/Max settings.
Using DOTS, optimized for the URP. Experimental support for recursive reflections.
Based on the Boat Attack Demo located here: https://github.com/Verasl/BoatAttack

<p align="center"><img width=80% src="https://github.com/Macleodsolutions/WMPortfolio/blob/master/planar1.jpg"></p>

<br>

## Basic Setup (No Recursion, Best Performance)

Assuming the user has no use for recursion, setup can be greatly simplified by simply adding individual
reflection scripts to the main camera, one for each direction you intend to have reflections come from. 
<p align="center"><img width=40% src="https://github.com/Macleodsolutions/WMPortfolio/blob/master/planar2.PNG"></p>
The reflection script ultimately outputs to a global shader property, which needs to be caught on any materials you intent to have reflections.
An example set of shaders designed to replicate the standard unity ones can be found for each corrosponding direction, demonstrating how to recieve the reflection
textures within the shadergraph.

## Basic Example

Using the shader property "_PlanarGround", which is already being caught in the Ground Planar Reflection shader variation, we can easily assign all materials catching
"_PlanarGround" to reflect at a normal angle of 0,1,0, or up.

<br>
<p align="center"><img width=40% src="https://github.com/Macleodsolutions/WMPortfolio/blob/master/planar3.PNG"><img width=43% src="https://github.com/Macleodsolutions/WMPortfolio/blob/master/planar4.PNG">
<br>
Resulting in:
<br>
<p align="center"><img width=80% src="https://github.com/Macleodsolutions/WMPortfolio/blob/master/planar5.jpg"></p>
<br>
Well, the skybox is clearly being reflected, but no objects anywhere in sight. By simply adjusting the "Clip Plane Offset" option,
we can find the optimal reflection offset for your scene.
<br>
<br>
<p align="center"><img width=80% src="https://github.com/Macleodsolutions/WMPortfolio/blob/master/planar6.PNG"></p>
<br>
Now, we have our objects reflecting! Still, something seems off. We have a number of post processing effects available to more closely match
our original objects:
<br>
<br>
<p align="center"><img width=80% src="https://github.com/Macleodsolutions/WMPortfolio/blob/master/planar7.PNG"></p>
<br>
<br>
Excellent! Last but not least, lets talk about multiple reflection angles. Simply set up another Reflection Script on the same camera with
the desired reflection angle, and feed it to a material property with a global shader call. Several direction materials are available in the example scene.
<br>
<br>
<p align="center"><img width=80% src="https://github.com/Macleodsolutions/WMPortfolio/blob/master/planar8.PNG"></p>
<br>
<br>

## Advanced Setup (Recursion, Questionable Performance, Experimental)

If the user does however require recursion, experimental support is provided via the Recursion Control script:
<br>
<br>
<p align="center"><img width=40% src="https://github.com/Macleodsolutions/WMPortfolio/blob/master/planar9.PNG"><img width=40% src="https://github.com/Macleodsolutions/WMPortfolio/blob/master/planar10.PNG"></p>
<br>
<br>
In the first inspector diagram above, we see a Recursive Reflection Control script, with no active layers, but with the
 same settings filled in as in the previous "_PlanarGround" example. 
 <br>
  <br>
 NOTE: At this point it it imperative that "Recursive Reflection" is enabled, and that "Levels Of Recursion" is at least 2.
 <br>
  <br>
 After clicking the first direction icon under step #4 (the direction indicated as the green side of the cube)
we arrive at the second inspector diagram, where the reflection layer is now active. To edit this reflection layer now, you must click the same direction icon again to remove it,
then readd with desired values. This is not optimal behaviour and will be addressed in a future update. 
<br>
  <br>
<p align="center"><img width=80% src="https://github.com/Macleodsolutions/WMPortfolio/blob/master/planar11.PNG"></p>
<br>
  <br>
  Finally, we see the same settings as our previous example, running in a recursive fashion. Even with the advantages that DOTS brings this is still a costly operation.
  <br>
  <br>
  Questions? Feature Requests? PRs? Get it touch! I'm also available at contact@wmacleod.me, and you can check out more of my work at https://www.wmacleod.me
  

