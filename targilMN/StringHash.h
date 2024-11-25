template <class T>
class StringHash : public HashTable<string, T>
{
private:
    // Implement h1 and h2
    int h1(string key) override {
        int hashValue = 0;
        for (int i = 0; i < key.length(); i++) {
            hashValue = (hashValue * 256 + key[i]) % this->size;
        }
        return hashValue;
    }

    int h2(string key) override {
        return 1; // Linear probing
    }

public:
    StringHash(int m = 10) : HashTable<string, T>(m) {}
};