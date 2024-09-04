import matplotlib.pyplot as plt
import numpy as np
import math

# x = n
# y = t

count = int(input("How many 2^ were done:")) + 1

data = eval(input("Now enter data:")) # screw it

xpoints = np.array([int(math.pow(2, n)) for n in range(1, count + 1)])
print(xpoints)

ypoints = np.array(data)
print(ypoints)

plt.plot(xpoints, ypoints)
plt.show()
