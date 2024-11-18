## Project Overview
PlagueSimulator2D is a simulation game designed to model the growth and spread of a pandemic across multiple continents. The simulation features various parameters, such as temperature, moisture, and plague characteristics, that influence how the disease spreads. Players interact with the game by controlling factors like the contagiousness, lethality, and speed of the plague, as well as managing airplane movements that can spread the disease between cities. The game visualizes the effects of the plague, showing changes in population, sickness, and death across the globe. It also logs simulation data and generates reports for analysis.

## Core Classes

### 1. AirPlaneMaster
- **Purpose**: Manages the behavior of airplanes in the simulation, specifically controlling airplane movement and whether the airplane is carrying sick passengers.
- **Key Features**:
  - Initializes cities and lists other cities for simulation purposes.
  - Simulates airplanes traveling between cities.
  - The airplane can either be healthy or sick, with a chance to spread the sickness.
  - Controls the speed and direction of the airplane's flight.

### 2. AirplaneMovement
- **Purpose**: Handles the movement of an airplane between cities and tracks the airplane's interactions, such as whether it is carrying sick people.
- **Key Features**:
  - Moves the airplane toward its destination city.
  - If the airplane is carrying sick people, it increments the sick population of the destination city.
  - If the airplane reaches its destination, it is destroyed.

### 3. ApplicationMaster
- **Purpose**: Provides functionality to quit the application.
- **Key Features**:
  - Contains a method `Quit()` that closes the application when invoked.

### 4. CSVWriter
- **Purpose**: Handles writing simulation data to a CSV file.
- **Key Features**:
  - Creates a CSV file with the current date and time as part of the filename.
  - Writes simulation data such as the day, sick populations, and death counts for each continent.
  - Appends new data to the CSV file during the simulation.

### 5. ContinentData
- **Purpose**: Manages the data for each continent, including population, sickness, and death.
- **Key Features**:
  - Tracks the continent's population, healthy people, sick people, and dead people.
  - Changes the continent's color based on the ratio of dead people to the population.
  - Calculates the health, sickness, and death for the population.
  - Displays the continent's data in a menu when clicked.
  - Keeps track of the first sick day and the number of sick people over time.

### 6. MenuMaster
- **Purpose**: Controls the user interface (UI) for the game, including handling sliders for plague parameters and displaying continent data in menus.
- **Key Features**:
  - Sets plague parameters (e.g., temperature, moisture, time to cure) based on slider values.
  - Displays the data of each continent in the UI when clicked (temperature, moisture, population, etc.).
  - Updates the plague parameters in real time.
  - Handles the interaction with the plague’s settings and ensures the UI displays the correct values.

### 7. PlagueData
- **Purpose**: Represents the plague's data, such as its temperature range, moisture range, contagion level, lethality, and time to cure.
- **Key Features**:
  - Controls the properties of the plague that affect the spread and severity of the disease.
  - These values are adjusted through the `MenuMaster`'s sliders, and they influence how the simulation progresses.

### 8. WholeData
- **Purpose**: Manages overall data for the simulation, aggregating data from all continents and controlling global aspects of the simulation.
- **Key Features**:
  - Keeps track of the total sick and dead populations across continents.
  - Can interact with the `CSVWriter` to record data.
  - Controls the global time progression.

### 9. TimeMaster
- **Purpose**: Manages the simulation’s time progression, ensuring the passage of days in the game.
- **Key Features**:
  - Controls the flow of time, and likely accelerates or decelerates the simulation speed based on user input or game logic.

### 10. PlagueSimulation
- **Purpose**: Simulates the spread of the plague and the effects on populations.
- **Key Features**:
  - Uses `PlagueData` to influence how the disease spreads across the world, adjusting to variables such as temperature and moisture.
  - Controls global interactions between cities, including the movement of airplanes and the spread of illness.
  - Likely integrates with other systems, such as the `AirplaneMaster`, to facilitate the global progression of the plague.

---

## Summary
PlagueSimulator2D is a comprehensive simulation of a global pandemic where players manage various aspects of the disease’s spread. The game incorporates dynamic systems such as the movement of airplanes, population health data, and the changing parameters of the plague itself. As the disease spreads, players can adjust settings like the plague's lethality and cure time to observe how different factors influence the global situation. Through real-time adjustments and data collection (saved in CSV format), the simulation allows for an interactive and informative experience of a pandemic’s global impact.
