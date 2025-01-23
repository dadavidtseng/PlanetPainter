# Game Metrics

1. **Grid System (256x256 Pixel Grids)**
   1. The game world is divided into grids, each measuring 256x256 pixels.
   2. The player moves at a speed of 0.5 units of the identity vector per second, scaled by delta Seconds.
   3. The player’s color changes or is lost immediately upon stepping into special grid tiles such as painter boxes or water boxes.
2. **Painting Mechanic and Progression**
   1. The Grid Meter tracks the player's painting progress across all grids.
   2. As the player paints the grids, the meter gradually fills.
   3. Once all grids are painted, the player achieves 100% completion, represented by the appearance of four mushrooms (one mushroom per 25% progress).
3. **Door and Switch Color System**
   1. Switch Interaction:
      1. When the player collides with a switch and presses the interact button, the switch changes to the player's current color.
   2. Door-Switch Linking:
      1. Each door is linked to a specific switch.
      2. If a switch is painted a color that matches its linked door, the door unlocks.
      3. If the switch's color changes to something else, the door locks again.
   3. Door Interaction:
      1. To open an unlocked door, the player must collide with the door and press the interact button.
   4. Level Completion:
      1. The level ends once all doors are unlocked.
