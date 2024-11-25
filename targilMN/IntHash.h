#pragma once
#include "HashTable.h"
#include <string>
using namespace std;

template <class T>
class IntHash : public HashTable<int, T>
{
private:
    // Implement h1 and h2
    int h1(int key) override {
        return key % this->size;
    }

    int h2(int key) override {
        return 1 + (key % (this->size - 1));
    }

public:
    IntHash(int m = 10) : HashTable<int, T>(m) {}
};
