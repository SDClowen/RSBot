#pragma once

#include <iostream>
#include <fstream>

using namespace std;

template <typename T>
void PayloadRead(ifstream& stream, T& dst)
{
	stream.read(reinterpret_cast<char*>(&dst), sizeof(T));
}

void PayloadReadString(ifstream& stream, string& dst)
{
	int nLength;
	PayloadRead(stream, nLength);

	if (nLength > 0) 
	{
		dst.resize(nLength);
		stream.read(&dst[0], nLength);
	}
	else
		dst = "";
}

template <typename T>
void PayloadWrite(ofstream& stream, T& src)
{
	stream.write(reinterpret_cast<char*>(&src), sizeof(T));
}

void PayloadWriteString(ofstream& stream, string& src)
{
	int nLength = src.size();
	PayloadWrite(stream, nLength);

	stream.write(src.c_str(), nLength);
}
