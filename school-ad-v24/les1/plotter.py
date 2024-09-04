import matplotlib.pyplot as plt
import numpy as np
import math

def determine_complexity(Npoints, funcOutput):
    # Normalize the funcOutput for comparison
    funcOutput = np.array(funcOutput)
    
    # Candidate complexities
    complexities = {
        "O(1)": np.ones_like(Npoints),
        "O(log N)": np.array([math.log2(x) if x > 1 else 1 for x in Npoints]),
        "O(N)": np.array([x for x in Npoints]),
        "O(N log N)": np.array([x * math.log2(x) if x > 1 else x for x in Npoints]),
        "O(N^2)": np.array([x ** 2 for x in Npoints]),
        "O(N^3)": np.array([x ** 3 for x in Npoints]),
    }

    # Calculate error (sum of squared differences) for each complexity
    errors = {}
    for key, complexity_values in complexities.items():
        # Normalize both the output and the complexity values
        normalized_func = funcOutput / funcOutput[0]  # Normalize the function output
        normalized_complexity = complexity_values / complexity_values[0]  # Normalize the candidate complexity
        error = np.sum((normalized_func - normalized_complexity) ** 2)  # Sum of squared differences
        errors[key] = error

    # Find the complexity with the minimum error
    best_fit = min(errors, key=errors.get)
    
    return best_fit

# Get user input for two Ns flag
isTwoNs = input("two Ns? (yes/no): ").strip().lower() == 'yes'
step = 0

if not isTwoNs:
    step = int(input("step?"))

# Get user input for data (list of observed values for each corresponding 2^n)
data = input("Enter the time data for each operation (comma-separated list): ")
data = list(map(float, data.split(',')))  # Parse data
count = len(data)

# Generate Npoints (either 1, 2, 3,... or powers of 2)
Npoints = np.array([int(math.pow(2, n)) for n in range(1, count + 1)]) if isTwoNs else np.array([x * step for x in range(1, count + 1)])

# Convert the input data into a numpy array
Tpoints = np.array(data)

# Plot the time complexity data for the function
plt.plot(Npoints, Tpoints, label="Function's Time Complexity", marker='o')

# Plot O(N^3) for comparison
ON3_points = np.array([x**3 for x in Npoints])
plt.plot(Npoints, ON3_points, label="O(N^3)", linestyle='--')

# Plot O(N^2) for comparison
ON2_points = np.array([x**2 for x in Npoints])
plt.plot(Npoints, ON2_points, label="O(N^2)", linestyle='--')

# Plot O(N log_2(N)) for comparison
ONlogN_points = np.array([x * math.log2(x) if x > 1 else x for x in Npoints])
plt.plot(Npoints, ONlogN_points, label="O(N log_2(N))", linestyle='--')

# Plot O(N) for comparison
ON_points = np.array([x for x in Npoints])
plt.plot(Npoints, ON_points, label="O(N)", linestyle='--')

# Plot O(log_2(N)) for comparison
OlogN_points = np.array([math.log2(x) if x > 1 else 1 for x in Npoints])
plt.plot(Npoints, OlogN_points, label="O(log_2(N))", linestyle='--')

# Add titles and labels
plt.title("Time Complexity Comparison")
plt.xlabel("Number of Operations (2^n)")
plt.ylabel("Time")

# Set plot limits to avoid extreme scaling
x_min, x_max = min(Npoints), max(Npoints)
y_min, y_max = min(Tpoints), max(Tpoints)

plt.xlim(x_min - 0.1 * x_min, x_max + 0.1 * x_max)  # Adding 10% padding
plt.ylim(y_min - 0.1 * y_min if y_min > 0 else 0, y_max + 0.1 * y_max)  # Adding 10% padding

# Add a legend to distinguish the plots
plt.legend()

# Try to determine the complexity
try:
    complexity = determine_complexity(Npoints, Tpoints)
    print(f"Determined complexity: {complexity}")
except Exception as e:
    print(f"Could not determine complexity: {e}")

# Show the plot
plt.grid(True, which="both", linestyle='--', linewidth=0.5)
plt.tight_layout()
plt.show()
