#include <vector>
#include <iostream>

int main() {
    std::vector<bool> primes(100, true);
    primes[0] = primes[1] = false;

    for(int i = 2; i < primes.size(); i++) {
        if(primes[i]) {
            for(int j = i * 2; j < primes.size(); j = j + i) {
                primes[j] = false;
            }
        }
    }

    for(int i = 0; i < primes.size(); i++) {
        if(primes[i]) {
            std::cout << i << std::endl;
        }
    }
}
