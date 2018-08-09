#include <vector>
#include <iostream>
#include <cstdlib>
#include <string>
#include <algorithm>

int random_int() {
    return std::rand() % 100;
}

std::string to_string(std::vector<int> vec) {
    std::string vec_string;
    for(int i = 0; i < vec.size(); i++) {
        vec_string += std::to_string(vec[i]);
        if(i % 5 == 0 && i > 0) {
            vec_string += "\n";
        } else {
            vec_string += " ";
        }
    }

    return vec_string;
}

std::string post_sort_report(std::vector<int> vec) {
    std::string report = "Post-sort vector: ";
    report += (std::is_sorted(std::begin(vec), std::end(vec), std::greater<int>()) ? "(sorted)" : "(unsorted)");
    report += "\n";
    report += to_string(vec);
    report += "\n";

    return report;
}

int main() {
    std::srand(time(0));
    std::vector<int> vector;
    for(int i = 0; i < 5; i++) {
        vector.push_back(random_int());
    }
    std::cout << "Pre-sort vector:" << std::endl << to_string(vector) << std::endl;

    for(int i = 1; i < vector.size(); i++) {
        int j = i;
        while(j > 0 && vector[j - 1] < vector[j]) {
            int placeholder = vector[j - 1];
            vector[j - 1] = vector[j];
            vector[j] = placeholder;
            j--;
        }
    }

    std::cout << post_sort_report(vector);

    return 0;
}
