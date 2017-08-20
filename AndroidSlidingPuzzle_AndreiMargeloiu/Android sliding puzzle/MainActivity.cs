using Android.App;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System;
using Android.Views;
using System.Collections;
    
namespace Android_sliding_puzzle
{
    [Activity(Label = "Android_sliding_puzzle", MainLauncher = true, Icon = "@drawable/icon")]

    public class MainActivity : Activity
    {
        #region
        Button resetButton;
        GridLayout mainLayout;

        // lists for storing the tiles and their coordinates
        ArrayList tilesList;
        ArrayList coordinatesList;

        int gameViewWidth;
        int tileWidth;

        // varible to store where is the empty slot at every moment
        Point emptySpot; 
        #endregion
            
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            setGameView();
            makeTilesMethod();
            randomizeMethod();
        }
        
        // method to create the grid layout
        private void makeTilesMethod()
        {
            // the grid is 4 x 4 -> the width of a tile is a quarter of the width of the grid
            tileWidth = gameViewWidth / 4;
            
            // create a counter to keep in mind the number of the tile
            int counter = 1;

            // initialize the lists for storing the coordinates of the tiles
            tilesList = new ArrayList();
            coordinatesList = new ArrayList();

            // we need to create all 16 tiles, they being placed on 4 rows and 4 columns
            for (int row = 0; row < 4; ++row)
            {
                for (int column = 0; column < 4; ++column)
                {
                    // we want to make a tile and add it in our main layout
                    MyTextView textTile = new MyTextView(this);

                    // we want to put a tile on the row 'row' and column 'column'
                    GridLayout.Spec rowSpec = GridLayout.InvokeSpec(row);
                    GridLayout.Spec colSpec = GridLayout.InvokeSpec(column);

                    GridLayout.LayoutParams tileLayoutParams = new GridLayout.LayoutParams(rowSpec, colSpec);

                    // print the number of the tile on it
                    textTile.Text = counter.ToString();
                    textTile.SetTextColor(Color.Black);
                    textTile.TextSize = 40;
                    textTile.Gravity = GravityFlags.Center;  // put the text in the center of the tile

                    // set the width and height of the tile
                    tileLayoutParams.Width = tileWidth - 10;  // (-10) for visibility
                    tileLayoutParams.Height = tileWidth - 10; // (-10) for visibility
                    tileLayoutParams.SetMargins(5, 5, 5, 5);  // for making a nice looking contour


                    // make the changes in the actual textTile
                    textTile.LayoutParameters = tileLayoutParams;
                    textTile.SetBackgroundColor(Color.Green);

                    // keep the coordinates of a tile (as a point in space, where the X coordinate is the column and Y coordiante is the row)
                    Point thisLocation = new Point(column, row);
                    // add the coordiante of this point in the coordinatesList
                    coordinatesList.Add(thisLocation);
                    // add the tile in the list, to use it later
                    tilesList.Add(textTile);

                    // remember the position if the tile
                    textTile.xPos = thisLocation.X;
                    textTile.yPos = thisLocation.Y;

                    // assign a method to execute when we toch the button
                    textTile.Touch += TextTile_Touch;

                    // add the tile in the main layout
                    mainLayout.AddView(textTile);

                    // increase the counter to the next number
                    counter = counter + 1;
                }
            }

            // remove the 16th tile -> tilesList start from the position 0 (not 1 as expected), so the 16th element is on the position 15
            mainLayout.RemoveView((MyTextView)tilesList[15]);
            // remove the 16th tile also from our list
            tilesList.RemoveAt(15);
        }

        private void randomizeMethod()
        {
            // take a helper to created random number
            Random myRand = new Random();

            // store a copy of the coordinates list
            ArrayList copyCoordsList = new ArrayList(coordinatesList);

            // take each tile (in the variable any) and shuffle it to a new position 
            foreach (MyTextView any in tilesList)
            {
                // take random coordinates where to put this tile (tile any) 
                int randIndex = myRand.Next(0, copyCoordsList.Count);
                // and store the coordinates in a variable (which is a point in space)
                Point thisRandLoc = (Point)copyCoordsList[randIndex];

                // create a new tile (which is a 1 x 1 part of the whole grid)
                GridLayout.Spec rowSpec = GridLayout.InvokeSpec(thisRandLoc.Y);
                GridLayout.Spec colSpec = GridLayout.InvokeSpec(thisRandLoc.X);
                GridLayout.LayoutParams randLayoutParam = new GridLayout.LayoutParams(rowSpec, colSpec);

                // also keep the location of the tile any
                any.xPos = thisRandLoc.X;
                any.yPos = thisRandLoc.Y;

                // set the appearance of the tile to look similar 
                randLayoutParam.Width = tileWidth - 10;
                randLayoutParam.Height = tileWidth - 10;
                randLayoutParam.SetMargins(5, 5, 5, 5);

                // set the tile position to be the new shuffled position
                any.LayoutParameters = randLayoutParam;

                // remove the coordinate, so we can't use it anymore for another tile
                copyCoordsList.RemoveAt(randIndex);
            }

            // we have deleted 15 out of 16 tiles, so the remaining one is the one that is empty
            emptySpot = (Point)copyCoordsList[0];
        }

        // function to reset the puzzle
        void resetMethod(object sender, System.EventArgs e)
        {
            randomizeMethod();
        }

        private void setGameView ()
        {
            // get the layout elements from the view
            resetButton = FindViewById<Button>(Resource.Id.resetButtonId);
            resetButton.Click += resetMethod;
            mainLayout = FindViewById<GridLayout>(Resource.Id.gameGridLayoutId);

            // get the windth of the Android screen
            gameViewWidth = Resources.DisplayMetrics.WidthPixels;

            // set the numbers of rows and colums of the grid
            mainLayout.ColumnCount = 4;
            mainLayout.RowCount = 4;

            // the grid should be of square size, so the height and width are equal to the windth of the phone
            mainLayout.LayoutParameters = new LinearLayout.LayoutParams(gameViewWidth, gameViewWidth);
            // let the colour of the layout to be gray
            mainLayout.SetBackgroundColor(Color.Gray);
        }

        // function that executes when the tile is touched
        void TextTile_Touch(object sender, View.TouchEventArgs e)
        {
            if (e.Event.Action == MotionEventActions.Up)
            {
                MyTextView thisTile = (MyTextView)sender;

                // just write the position of the tile in the Xamarin console, to see each tile when moves
                Console.WriteLine("\r tile is at: \r x={0} \r y={1}", thisTile.xPos, thisTile.yPos);

                // compute the distace between the tile which was pressed and the empty space
                float xDif = (float)Math.Pow(thisTile.xPos - emptySpot.X, 2);
                float yDif = (float)Math.Pow(thisTile.yPos - emptySpot.Y, 2);
                float dist = (float)Math.Sqrt(xDif + yDif);

                // if the tile was near the empty space
                if (dist == 1)
                {
                    // memorize the current position of the tile
                    Point curPoint = new Point(thisTile.xPos, thisTile.yPos);

                    // we want to put the tile on the place of the empty space
                    GridLayout.Spec rowSpec = GridLayout.InvokeSpec(emptySpot.Y);
                    GridLayout.Spec colSpec = GridLayout.InvokeSpec(emptySpot.X);

                    GridLayout.LayoutParams newLocParams = new GridLayout.LayoutParams(rowSpec, colSpec);

                    // the tile moves in the empty space
                    thisTile.xPos = emptySpot.X;
                    thisTile.yPos = emptySpot.Y;

                    // we set the appearance of the tile
                    newLocParams.Width = tileWidth - 10;
                    newLocParams.Height = tileWidth - 10;
                    newLocParams.SetMargins(5, 5, 5, 5);

                    thisTile.LayoutParameters = newLocParams;

                    // the empty place goes where was the pressed tile before
                    emptySpot = curPoint;
                }
            }
        }

        // add new feature to the TextView, to know it's row and column
        class MyTextView : TextView
        {
            Activity myContext;

            public MyTextView(Activity context) : base(context)
            {
                myContext = context;
            }

            public int xPos { set; get; }
            public int yPos { set; get; }
        }
    }
}

