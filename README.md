# Xamarin-Sliding-Puzzle

**Android sliding puzzle in Xamarin**

Following this tutorial you will create your own very first Android
application. There are no prerequisited to build a great app and you
will create a nice looking sliding puzzle following an easy-to-follow
approach. I will explain at every stage what we are trying to achive and
how to code each element used.

**Take a look, this is what you’ll create!**

![](media/image1.png){width="3.679588801399825in"
height="6.033333333333333in"}

This tutorial is a more detailed reproduction of the course Xamarin
Android Sliding Puzzle C\#
(<https://www.udemy.com/xamarin-android-sliding-puzzle-csharp>) by Amir
J. The code is fully rewritten and commented by myself after his
guidance. Still, the idea of the application belongs to him.

1.  ![](media/image2.png){width="5.0in"
    height="3.454834864391951in"}Let’s create a new Androd project.
    Click on **File -&gt; New -&gt; Project**. Them in the left menu go
    to **Templates -&gt; Visual C\# -&gt; Android** and select Black App
    (Android). Give it the name “Android sliding puzzle” and we are good
    to go.

2.  Now we want to create our first button, one that will shuffle the
    puzzle. In the Solution explorer (right) go to **Android sliding
    puzzle -&gt; Resources -&gt; layout -&gt; Main.axml**. This file is
    resposable for the appearance of our application, so here we need to
    add all the buttons. If you don’t see the Android screen, **be sure
    that you have made all the updates to Xamarin** **and you are in the
    Designer tab** (bottom-left corner).

![](media/image3.png){width="7.5in" height="4.072222222222222in"}

1.  ![](media/image4.png){width="6.941666666666666in"
    height="3.660416666666667in"}In order to add layout buttons, be sure
    that you have the toolbox activated. **Go to View -&gt; Toolbox and
    check it**. Now, a menu will all kind of buttons should have
    appeared. Now look for a ‘Grid layout’ object and drag and drop one
    on the screen.

2.  Now look for a ‘Button’ and also drag and drop it on the screen. We
    need to change the ID’s of the two elements we have just created, in
    order to easily access them in the future. Double click on the grid
    and in the Properties menu (right side) change the property ‘id’ to
    be **‘@+id/gameGridLayoutId’**.

    The same thing, click on the button and change it’s ‘id’ property to
    be **‘@+id/resetButtonId’**. Now change the text property to be
    ‘Reset’. Change the background property to be \#FF8C00. Save the
    file and now your app should look like:

> ![](media/image5.png){width="6.641666666666667in"
> height="3.6098687664041993in"}

1.  **Let’s start coding!** Go in the MainActivity.cs file and be sure
    that you have the following code written.

![](media/image6.png){width="8.35763888888889in"
height="2.316666666666667in"}

1.  ![](media/image7.png){width="8.558333333333334in"
    height="3.5124660979877516in"}We need to get the Grid and button
    back in the main program, in order to make changes to them. So let’s
    do that by making the following changes in the MainActivity.cs

2.  ![](media/image8.png){width="8.5in" height="5.986805555555556in"}Our
    app should work on multiple Android devices, independent on their
    screen size. So our grid should change the size according to the
    screen size. Make the following changes in your code.

![](media/image9.png){width="8.508654855643044in"
height="0.5916666666666667in"}**TIP: If you want to check in real time
how your app look like, run it on the virtual device.**

1.  ![](media/image10.png){width="7.866666666666666in"
    height="2.7618055555555556in"}![](media/image11.png){width="8.5in"
    height="6.184977034120735in"}Let’s move on to creating the tiles of
    the grid! As you saw on the first page, the grid is 4 x 4, meaning
    that it has 16 tiles in total. Let’s firstly try to make the
    top-left tile and then we’ll do the others!

**Run your app the virtual device to be sure it’s working.**

1.  We now need to extend the grid to be 4 x 4, not just one tile. So we
    need to iterate on each row and column and create a tile and put it
    there. So we’ll use two ‘for loops’ which will do exactly that (will
    go on every row and every column) and put a tile there.

> ![](media/image12.png){width="7.208333333333333in"
> height="4.529166666666667in"}Because we want our app to look great and
> be downloaded by many people, we’ll also leave some space between the
> tiles so they now intercalate. Now make the following changes in the
> code.

![](media/image13.png){width="2.9583333333333335in"
height="0.1451388888888889in"}

![](media/image14.png){width="6.916666666666667in"
height="4.295138888888889in"}

1.  Now let’s put some text on each tile, such as the number of tile
    which is from 1 to 16. To do that, we need to take a counter and
    increase it after every tile is made, so the on the new tile it will
    be increased to the next value.

> Firstly, add ‘using Android.Views;’ on top of your file.

![](media/image15.png){width="3.1354166666666665in"
height="1.2916666666666667in"}

> ![](media/image16.png){width="7.5in"
> height="5.615972222222222in"}Secondly, let’s write the counter number
> of every tile. Whenever you get lost in the code, take a look in the
> left side on the rows number and be sure that you are looking at the
> same rows

**This how out app should look like until now**

![](media/image17.png){width="3.3495089676290464in"
height="5.541666666666667in"}

1.  We want to randomize the tiles now, so that each new game is unique.
    For each tile, we need to randomly choose a position where to put
    that tile. We’ll store the positions of the tiles in a list (also
    called ArrayList), think of it like a list where for each tile
    number you also write the final position. Then we’ll remove the tile
    16^th^, because we need one free space for tiles to move

Firstly, add this line on top of the code:
![](media/image18.png){width="3.05in" height="0.22569444444444445in"}

![](media/image19.png){width="7.813753280839895in"
height="4.1506944444444445in"}Create the lists for storing information
about the tile and their coordiantes. (pay attention to the lines of the
code)![](media/image20.png){width="3.6333333333333333in"
height="1.1811712598425197in"}

![](media/image21.png){width="7.983333333333333in"
height="3.778038057742782in"}

![](media/image22.png){width="1.4333333333333333in"
height="0.15925962379702538in"}

1.  We now want to shuffle the tiles when the games start, so that each
    new game will be different and challanging! We’ll create a method
    randomizeMethod() for doing that. All the necessary comments are
    inside the code.

![](media/image23.png){width="2.7666666666666666in"
height="0.22291666666666668in"} Add this line at the beginning of the
code:

Next write the code for randomising the puzzle.

![](media/image24.png){width="5.808333333333334in"
height="1.4222222222222223in"}

![](media/image25.png){width="7.741666666666666in"
height="4.407731846019248in"}

1.  Now let’s suffle the game everytime the Reset button is pressed. We
    need to create a method before the setGameView methon and set the
    button to call it at every press.

![](media/image26.png){width="7.5in" height="3.6326388888888888in"}

**And now everytime we press the Reset button, the puzzle shuffles.
Yuhuuu!**

![](media/image27.png){width="2.033333333333333in"
height="3.345833333333333in"}![](media/image28.png){width="2.0395833333333333in"
height="3.35625in"}![](media/image29.png){width="2.0453937007874017in"
height="3.35in"}

1.  Our goal now remains to make the tiles move when we touch them. More
    specifically, if a tile is situated near the empty tile, it should
    swap its position with the empty tile.

> In order to do that, we need to know where each tile is situated,
> right? So that when we click on it to change its position to the empty
> tiles’s one. Add the new code under the setGameView() method.
>
> ![](media/image30.png){width="8.207638888888889in"
> height="4.516666666666667in"}

1.  We now transformed the tile TextView into MyTextView, so we need to
    make additional changes in the code: where we wrote TextView, we
    need to change to MyTextView.

1^st^ change in makeTilesMethod()

![](media/image31.png){width="7.5in" height="1.13125in"}

2^nd^ change also in makeTilesMethod()

> ![](media/image32.png){width="9.16424978127734in"
> height="0.29444444444444445in"}

3^rd^ change in the randomizeMethod()

![](media/image33.png){width="6.85in" height="0.5632217847769029in"}

1.  Now, we need to make a small change. We told that when we touch on a
    tile, it should move, right? Yes, but we didn’t implement it yet, so
    let’s do that! Add the following code in the two for-loops from the
    makeTilesMethod().

> ![](media/image34.png){width="8.220376202974629in"
> height="2.6952187226596673in"}

And also in the foreach from the randomizeMethod(), let’s remember the
location of the tiles.

> ![](media/image35.png){width="7.5in" height="4.361805555555556in"}

1.  Now let’s create the function that moves the tile when it’s touched.
    We’ll create it before the class MyTextView.

![](media/image36.png){width="7.5in" height="3.5930555555555554in"}

1.  We need to remember where is the empty tile, right? So let’s firstly
    declare a varible to keep this information.

> ![](media/image37.png){width="4.721527777777778in"
> height="1.9333333333333333in"}
>
> ![](media/image38.png){width="6.558333333333334in"
> height="3.798827646544182in"}Then, after the foreach from the
> randomizeMethod() finishes, we’ll memorize where the empty tile is.

1.  This is the last step until having a fully functional application!
    We just need to move the tiles when they are pressed. So, if a tile
    is touched and it is near the empty space, we’ll move it there.

> ![](media/image39.png){width="8.354166666666666in"
> height="7.09375in"}How do we check this condition? We just have to
> compute the distance between the touched tile and the empty place,
> similar with what you’ve learned at school. The code speaks from
> itself
>
> **Congratulations! You have built your first Android application!**
>
> Now go and show it to your parents and friends, they would not believe
> you made it. But you know it wasn’t that hard, right?

