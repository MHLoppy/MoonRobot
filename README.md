# Moon Robot

While studying backend development at uni in 2024, we were given a simple task 
for our first assignment, with an option for a single bonus mark for making 
our solutions as short as possible (without just "cheating" by putting it all 
on one line).

Most assignments were generally pretty boilerplate, so even doing a good 
job of them resulted in something that I usually didn't think was anything 
special, even in cases where my submission was marked highly.

This is one of the few things I ever made in the course of completing uni 
assignments that I thought was actually of some interest independent of an 
academic environment.

You need to run the program with command line arguments. If debugging with 
Visual Studio you can make use of command line arguments using 
[these instructions](https://stackoverflow.com/questions/4791140/how-do-i-start-a-program-with-arguments-when-debugging/4791147#4791147).

## Task sheet

> ### General Instructions
>
> Your task is to implement a Proof of Concept (**POC**) of the Moon robot 
> simulation. The surface of Moon can be presented as a square grid of the 
> size _N_.
>
> You need to create a console application that will simulate a Moon robot 
> moving on a square map of dimensions _N x N_. There are no other obstacles 
> on the map. The robot is free to wander around the surface of the Moon, but 
> must be prevented from falling off the map. Any movement that would result 
> in the robot falling from the table must be ignored by the robot. However, 
> further valid direction commands must still be permitted. Robot should 
> remain operable while on the map.
>
> ### Application Specification
>
> #### Supported Robot Commands
>
> Here is a list of supported direction commands that should be implemented in 
> the POC.
>
> | Command     | Description                                                                                                                               |
> |-------------|-------------------------------------------------------------------------------------------------------------------------------------------|
> | PLACE X,Y,D | the robot on the map at coordinate (X,Y) facing the cardinal direction _D_ out of 4 possible directions: _NORTH_, _EAST_, _SOUTH_, _WEST_ |
> | LEFT        | Turn the robot 90 degrees _LEFT_ without changing its coordinates.                                                                        |
> | RIGHT       | Turn the robot 90 degrees _RIGHT_ without changing its coordinates.                                                                       |
> | MOVE        | Move robot one coordinate in the direction that it's facing.                                                                              |
>
> #### Constraints
>
> 1. The robot **must** ignore all commands until it is dropped on the map. 
> E.g. The robot **must not** move or turn until it is placed on the map.
> 2. The robot **must not** perform any invalid moves. E.g. fall off the map.
> 3. The map **must** be not smaller than 2x2 and no larger than 100x100 
> squares.
> 4. The map **must** be square. E.g. 25x25, but not 10x50.
>
> ### Technology Stack Requirements
> 
> The application must be cross-platfrom and be able to run from the terminal. 
> Please use the latest version of dotnet to create a new console application 
> and use your IDE of choice to accomplish the task.

## Original solution (9 lines, 1,570 characters)

I originally submitted a 9-line solution and moved on to other things for the 
rest of the semester. I believed I could do better but the extra credit was 
a single mark so it wasn't academically efficient to continue working on it.

This solution was the result of two basic ideas: the conditions were merely 
complicated functions (abc inputs mapped to xyz outputs deterministically) 
and the idea of "cheating" by using the equivalent of a dictionary lookup -- 
via hashing -- as I'd learnt about Big O in an earlier unit on data structures.

The "skeleton" of this solution is:

```csharp
var = value;
var;
while (conditions)
{
    if (conditions) var = value;                                    // handle PLACE command
    if (conditions) var = value; else if (conditions) var = value;  // handle LEFT and RIGHT commands
    if (conditions) var = value; else if (conditions) var = value;  // handle MOVE (west) and MOVE (north) commands
    if (conditions) var = value; else if (conditions) var = value;  // handle MOVE (east) and MOVE (south) commands
}
```

Later on we were encouraged to record a video explaining our solutions. I've 
uploaded that original 2024 video: [YouTube](https://youtu.be/ZAdc4IpGYgI).

## Revised Solution (6 lines, 2,765 characters)

Towards the end of the semester I got a brain worm about how it should be 
possible to build on the ideas in my original implementation to further 
condense it down, so opted to take a few days off of the assignments that 
were an academic priority to have another stab at condensing my solution 
further.

The main difference is combining the processing of the LEFT, RIGHT, and MOVE 
commands into a single line.

I also used a self-imposed constraint of avoiding the use of ternary operators 
and any conditional check (on one line) that involved more than an if-else; 
ideally even an if-else would not be allowed on one line.

The "skeleton" of my revised solution is:

```csharp
var = value;
while (conditions)
{
    if (conditions) var = value;    // handle PLACE command (copied from original)
    if (conditions) var = value;    // handle LEFT, RIGHT, and MOVE (all directions) commands 
}
```

Upon completing this implementation I believed it should be possible to 
combine both assignments into one line of code from hell, but I had already 
spent more time than was academically advisable so did not seriously attempt 
to do so.

As with the original, I recorded a video to coincide with my revised solution. 
I've uploaded that original 2024 video: [YouTube](https://youtu.be/MjdA28nMlv0).

## License

- Code and documentation are licensed under the fuck around and find out license (fafol) v0.1 or later.