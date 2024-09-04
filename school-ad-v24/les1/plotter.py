import matplotlib.pyplot as plt
import numpy as np
import math

# x = n (number of operations)
# y = t (time complexity data)

# Get user input for data (list of observed values for each corresponding 2^n)
data = eval(input("Enter the time data for each operation (as a list): ")) 
count = len(data)  # Number of data points

# Generate x-axis points (powers of 2: 2^1, 2^2, ..., 2^count)
Npoints = np.array([int(math.pow(2, n)) for n in range(1, count + 1)])

# Convert the input data into a numpy array
Tpoints = np.array(data)

# Plot the time complexity data for the function
plt.plot(Npoints, Tpoints, label="Function's Time Complexity", marker='o')

# Plot O(N) for comparison
ON_points = np.array([x for x in Npoints])
plt.plot(Npoints, ON_points, label="O(N)", linestyle='--')

# Plot O(N^2) for comparison
ON2_points = np.array([x*x for x in Npoints])
plt.plot(Npoints, ON2_points, label="O(N^2)", linestyle='--')

# Plot O(N^3) for comparison
ON3_points = np.array([x*x*x for x in Npoints])
plt.plot(Npoints, ON3_points, label="O(N^3)", linestyle='--')

# Plot O(log_2(N)) for comparison
OlogN_points = np.array([math.log2(x) for x in Npoints])
plt.plot(Npoints, OlogN_points, label="O(log_2(N))", linestyle='--')

# Plot O(N log_2(N)) for comparison
ONlogN_points = np.array([x * math.log2(x) for x in Npoints])
plt.plot(Npoints, ONlogN_points, label="O(N log_2(N))", linestyle='--')

# Add titles and labels
plt.title("Time Complexity Comparison")
plt.xlabel("Number of Operations (2^n)")
plt.ylabel("Time")

# Set a logarithmic scale for better visualization of large data points
plt.xscale("log")
plt.yscale("log")

# Add a legend to distinguish the plots
plt.legend()

# Show the plot
plt.grid(True, which="both", linestyle='--', linewidth=0.5)
plt.tight_layout()
plt.show()
