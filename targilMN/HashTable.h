#pragma once
#include <iostream>
using namespace std;

enum state { EMPTY, FULL, DELETED };

template<class K, class T>
class HashTable
{
protected:
	class Item
	{
	public:
		T data;			//The record information
		K key;			//The record key
		state flag;		//An indicator for the vacancy of the cell
		//Constructors
		Item() { flag = EMPTY; }
		Item(K k, T d) { data = d; key = k; flag = FULL; }
	};

	int size;
	Item* table;
	// TODO: Add any additional required attributes
	int numItems; // Number of items in the table

	// TODO: Add here the declaration of the functions h1, h2.
	int h1(K key); // Primary hash function
	int h2(K key); // Secondary hash function

	// TODO: Based on the functions, define the hash function, using double hashing
	int hash(K key, int i); // Double hashing function

public:
	HashTable(int m = 10);
	~HashTable();
	// TODO: add here the declaration of the functions insert, search and remove.
	void insert(K key, T data);  //i did
	T search(K key);   //i did
	void remove(K key);   //i did

	void print();
};
///////////////////////////////////////////////
template<class K, class T >
HashTable<K, T>::HashTable(int m)
{
	// TODO: implement
	size = m;
	table = new Item[size];
	numItems = 0; // Initialize the number of items
}

template<class K, class T>
HashTable<K, T>::~HashTable()
{
	delete[] table;
}

// TODO: implement here the functions hash, insert, search and remove.
template<class K, class T>
int HashTable<K, T>::h1(K key)
{
	return key % size; // Example primary hash function
}

template<class K, class T>
int HashTable<K, T>::h2(K key)
{
	return 1 + (key % (size - 1)); // Example secondary hash function
}

template<class K, class T>
int HashTable<K, T>::hash(K key, int i)
{
	return (h1(key) + i * h2(key)) % size; // Double hashing
}

template<class K, class T>
void HashTable<K, T>::insert(K key, T data)
{
	int i = 0;
	int j;
	do {
		j = hash(key, i);
		if (table[j].flag != FULL) {
			table[j] = Item(key, data);
			numItems++;
			return;
		}
		i++;
	} while (i != size);
	throw overflow_error("Hash table overflow");
}

template<class K, class T>
T HashTable<K, T>::search(K key)
{
	int i = 0;
	int j;
	do {
		j = hash(key, i);
		if (table[j].flag == EMPTY) {
			return T(); // Return default value if not found
		}
		if (table[j].flag == FULL && table[j].key == key) {
			return table[j].data;
		}
		i++;
	} while (i != size);
	return T(); // Return default value if not found
}

template<class K, class T>
void HashTable<K, T>::remove(K key)
{
	int i = 0;
	int j;
	do {
		j = hash(key, i);
		if (table[j].flag == EMPTY) {
			return; // Item not found
		}
		if (table[j].flag == FULL && table[j].key == key) {
			table[j].flag = DELETED;
			numItems--;
			return;
		}
		i++;
	} while (i != size);
}

template<class K, class T>
inline void HashTable<K, T>::print()
{
	for (int i = 0; i < size; i++)
		if (table[i].flag == FULL)
			cout << i << ":\t" << table[i].key << '\n';
}



