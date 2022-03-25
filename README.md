# Lab2 - Contemporary software development
#### Solution by [Martin](https://github.com/bergstr) & [Daniel](https://github.com/DDaaNNee) 🚀

A simple game created for a lab in the information systems master program at Uppsala university.


The task was to create a game involving circles and squares placed in a coordinate system. When played the user would supply the shapes and then input a coordinate to guess if it is located inside one of the shapes.
Points would then be allocated to the player according to a formula.


The shapes can be supplied by a pretty self explanatory command line argument.

`Lab2.exe "SHAPE, X, Y, LENGTH, POINTS; CIRCLE, 3, 1, 13, 100; CIRCLE, 1, -1, 15, 200; SQUARE, -1, 0, 20, 300; SQUARE, -3, 2, 8, 400;"`


A guess can then be entered like so: `1,0` or so: `(1,0)`


Which would output: `Your score: 6`