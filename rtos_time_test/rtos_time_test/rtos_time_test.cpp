#include <stdio.h>

#include <iostream>
#include <chrono>
using namespace std;
using namespace chrono;

int main()
{
    long sum = 0;

    system_clock::time_point start = system_clock::now();

    for (int i = 0;i < 5000;i++)
    {
        system_clock::time_point now = system_clock::now();
        nanoseconds nano = now - start;
        start = now;
        double result = nano.count()*0.001;
        printf("%0.2f\r\n", result);
    }
}